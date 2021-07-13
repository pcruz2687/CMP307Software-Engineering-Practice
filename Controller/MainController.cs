using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class MainController
    {
        IMainView _view;
        UserModel _user;
        Security _security;

        // an overloaded constructor that expects a view object
        // so that it can access the variables within that view
        public MainController(IMainView view)
        {
            _view = view;
            _security = new Security(_view);
            view.set_controller(this);
            
        }

        // get all the registered users from the database
        public void get_users_table()
        {
            DataTable users = new DataTable();
            _user = new UserModel();
            _user.set_all_users(_view.user_id.ToString());

            users = _user.get_users_table();
            _view.display_users(users);
        }
        
        // get all the messages from the database between two users
        public void get_all_messages()
        {
            _user.set_message(_view.user_id, _view.receiver_id);

            _view.display_messages(_user.get_all_messages(), _security);
        }

        // store the message in the database
        public void send_message()
        {
            if (String.IsNullOrEmpty(_view.message))
            {
                return;
            }
            else if (_view.message.Length > 0 && _view.message.Trim().Length == 0)
            {
                return;
            }


            // if tagged as important, add the <IMPORTANT> string
            if (_view.important)
            {
                // encrypt the message before storing in the database
                _security.encrypt(_view.message);
                _user.send_message(_view.user_id, _view.receiver_id, "<IMPORTANT>" + _security.get_enc_msg());
            }
            else
            {
                // encrypt the message before storing in the database
                _security.encrypt(_view.message);
                _user.send_message(_view.user_id, _view.receiver_id, _security.get_enc_msg());
            }
            // clear the message input box
            _view.message = "";
            // invoke the display_messages function to update the View message log
            _view.display_messages(_user.get_all_messages(), _security);
        }

        //remove the user from the database
        public void logout()
        {
            _user.remove_user(_view.user_id);

            if (_user.get_remove_status())
            {
                _view.close_window();
            }   
        }

        // delete unimportant messages older than 6 months
        public void delete_messages()
        {
            _user.delete_old_message();
        }

        // a class for encryption and decryption of messages
        public sealed class Security
        {
            string enc_msg;
            string dec_msg;
            // the hash used for creating the key
            private string hash1 = "d0g3f1n@nc1aL";

            IMainView _view;

            // an overloaded constructor that expects the same view objects from the MainController
            // so that it can access the messages that need decryption
            public Security(IMainView view)
            {
                _view = view;
            }

            // invoked by the MainController to encrypt messages
            public void encrypt(string message)
            {
                // add the user ID and receiver ID and concatenate it with the hash to create a unique key for the conversation
                hash1 = Convert.ToInt32(_view.user_id) + Convert.ToInt32(_view.receiver_id) + hash1;
                byte[] data = UTF8Encoding.UTF8.GetBytes(_view.message);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash1));
                    using (TripleDESCryptoServiceProvider trip_des = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })

                    {
                        ICryptoTransform transform = trip_des.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        enc_msg = Convert.ToBase64String(results, 0, results.Length);
                    }
                }
                hash1 = "d0g3f1n@nc1aL";
            }
            
            // return the encrypted message
            public string get_enc_msg()
            {
                return enc_msg;
            }

            // invoked to decrypt the messages before it is displayed to the user
            public void decrypt(string message)
            {
                // add the user ID and receiver ID and concatenate it with the hash to create the unique key to decrypt the messages
                hash1 = Convert.ToInt32(_view.receiver_id) + Convert.ToInt32(_view.user_id) + hash1;
                byte[] data = Convert.FromBase64String(message);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash1));
                    using (TripleDESCryptoServiceProvider trip_des = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })

                    {
                        ICryptoTransform transform = trip_des.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        dec_msg = UTF8Encoding.UTF8.GetString(results);
                    }
                }
                hash1 = "d0g3f1n@nc1aL";
            }

            // return the decrypted message
            public string get_dec_msg()
            {
                return dec_msg;
            }
        }


    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserModel
    {
        private string connection_string = "<INSERT SERVER/PW HERE>";

        private Dictionary<string, Dictionary<string, object>> _account;
        private DataTable users_table;
        private DataTable messages_table;
        private bool removed_status;

        // authenticate the user details when logging in
        public void connect(string user, string pw)
        {
            MySqlConnection conn;

            var account = new Dictionary<string, Dictionary<string, object>>();

            string user_id;
            string name;

            try
            {
                // will return an empty dictionary if the user is already logged in a different machine
                if (check_if_already_connected(user))
                {
                    _account = account;
                    return;
                }

                conn = new MySqlConnection(connection_string);
                conn.Open();

                Debug.WriteLine(user);
                Debug.WriteLine(pw);
                Debug.WriteLine("Connection Open");
                string query = "SELECT user_id, name FROM doge_financial_accounts WHERE BINARY username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@username", user);
                cmd.Parameters.AddWithValue("@password", pw);

                MySqlDataReader rdr = cmd.ExecuteReader();

                // adds the query results to the generic dictionary
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        account.Add("user", new Dictionary<string, object>()
                        {
                            { "user_id", rdr[0] },
                            { "name", rdr[1] },
                        });
                    }
                }
                else
                {
                    rdr.Close();
                    conn.Close();
                    _account = account;
                }

                user_id = account["user"]["user_id"].ToString();
                name = account["user"]["name"].ToString();

                // call the method for updating the online users on the database
               add_connected_user(user_id, name);

                if (conn != null)
                {
                    rdr.Close();
                    conn.Close();
                }
                _account = account;
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
                _account = account;
            }
        }

        // if a user is not already logged in, add it to the connected users table
        public void add_connected_user(string user_id, string name)
        {
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connection_string);
                conn.Open();
                string query = "INSERT INTO doge_financial_connected VALUES (@user_id, @name)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();

                if (conn != null)
                {
                    conn.Close();
                    return;
                }
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
                return;
            }
        }

        // checks if the user is already logged in if it exists in the connected users table
        public bool check_if_already_connected(string username)
        {
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connection_string);
                conn.Open();
                string query = "SELECT doge_financial_connected.user_id FROM doge_financial_connected INNER JOIN doge_financial_accounts WHERE doge_financial_accounts.username = @username AND doge_financial_accounts.user_id = doge_financial_connected.user_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@username", username);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    if (conn != null)
                    {
                        rdr.Close();
                        conn.Close();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
                return false;
            }
        }

        // return the logged in account using a dictionary containing the user_id and name
        public Dictionary<string, Dictionary<string, object>> get_account()
        {
            return _account;
        }

        // gets all the registered users from the database
        public void set_all_users(string user_id)
        {
            MySqlConnection conn;

            DataTable table = null;
            MySqlDataAdapter adapter;
            conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();
                string query = "SELECT user_id, username, name FROM doge_financial_accounts WHERE user_id <> " + user_id;
                MySqlCommand cmd = new MySqlCommand(query, conn);

                adapter = new MySqlDataAdapter(query, conn);
                table = new DataTable();

                adapter.Fill(table);

                users_table = table;
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
                users_table = table;
            }
        }

        // return all of the registered users found in the database
        public DataTable get_users_table()
        {
            return users_table;
        }

        // gets all the messages between two users from the database
        public void set_message(string sender_id, string receiver_id)
        {
            MySqlConnection conn;

            DataTable table = null;
            MySqlDataAdapter adapter;
            conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();
                string query = "SELECT (SELECT doge_financial_accounts.name FROM doge_financial_accounts WHERE doge_financial_accounts.user_id = doge_financial_messages.sender_id) as sender, message AS messages, date FROM doge_financial_messages WHERE doge_financial_messages.sender_id = '" + sender_id + "' AND doge_financial_messages.receiver_id = '" + receiver_id + "' OR doge_financial_messages.sender_id = '" + receiver_id + "' AND doge_financial_messages.receiver_id = '" + sender_id + "'";


                adapter = new MySqlDataAdapter(query, conn);
                table = new DataTable();

                adapter.Fill(table);
                messages_table = table;
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
                messages_table = table;
            }
        }

        // return all the messages between two users
        public DataTable get_all_messages()
        {
            return messages_table;
        }

        // store the message in the database
        public void send_message(string sender_id, string receiver_id, string message)
        {
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connection_string);
                conn.Open();
                string query = "INSERT INTO doge_financial_messages (sender_id, receiver_id, message) VALUES (@sender_id, @receiver_id, @message)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@sender_id", sender_id);
                cmd.Parameters.AddWithValue("@receiver_id", receiver_id);
                cmd.Parameters.AddWithValue("@message", message);
                cmd.ExecuteNonQuery();

                if (conn != null)
                {
                    conn.Close();
                    return;
                }
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
                return;
            }
        }

        // remove logged in user from database
        public void remove_user(string user_id)
        {
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connection_string);
                conn.Open();
                string query = "DELETE FROM doge_financial_connected WHERE user_id = @user_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.ExecuteNonQuery();

                if (conn != null)
                {
                    conn.Close();
                }
                removed_status = true;
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
                removed_status = true;
            }
        }

        // return the removed user status
        public bool get_remove_status()
        {
            return removed_status;
        }


        // delete unimportant messages older than 6 months
        public void delete_old_message()
        {
            MySqlConnection conn;

            conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();
                string query = "DELETE FROM doge_financial_messages WHERE date < (NOW() - INTERVAL 6 MONTH) AND message NOT LIKE '%<IMPORTANT>%'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                if (conn != null)
                {
                    conn.Close();
                    return;
                }
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}

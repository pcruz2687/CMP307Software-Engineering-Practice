using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class LoginController
    {
        ILoginView _view;
        UserModel _user;
        
        // an overloaded constructor that expects a view object
        public LoginController(ILoginView view)
        {
            _view = view;
            view.set_controller(this);
        }

        // authenticate the user
        public void connect(string user, string pw)
        {
            Dictionary<string, Dictionary<string, object>> account = new Dictionary<string, Dictionary<string, object>>();
            _user = new UserModel();
            _user.connect(user, pw);
            account = _user.get_account();

            // if the user exists, pass the user_id name to Main messaging window
            if (account.Count > 0)
            {
                string user_id = account["user"]["user_id"].ToString();
                string name = account["user"]["name"].ToString();
                account.Clear();
                _view.show_main(user_id, name);
            }
            else
            {
                _view.display_error();
                return;
            }
        }
    }
}
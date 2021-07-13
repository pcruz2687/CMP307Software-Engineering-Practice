using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class Login : Form, ILoginView
    {
        public Login()
        {
            InitializeComponent();
        }

        LoginController _controller;

        // a LoginController object is passed in to be used as the controller for loggin in
        public void set_controller(LoginController controller)
        {
            _controller = controller;
        }

        // Grab the username and password and attempt to connect
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this._controller.connect(tbUsername.Text, tbPassword.Text);
        }

        // Invoked by the controller to create a the main messaging window
        // and pass it into the MainController so that the controller
        // can access any relevant variables to pass into the UserModel
        public void show_main(string user_id, string name)
        {
            Main f2 = new Main(user_id, name);
            this.Hide();

            MainController main = new MainController(f2);

            f2.ShowDialog();
            this.Close();
            this.Dispose(true);
        }

        // Invoked by the controller when a user is already logged in or
        // wrong user details
        public void display_error()
        {
            MessageBox.Show("Account already logged in or invalid username or password");
        }
    }
}

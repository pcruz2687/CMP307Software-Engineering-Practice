using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;
using Controller;
using Model;

namespace MessageApplicationMVC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // The view is used by the controller to update the display
            // and access any relevant variables to pass into the UserModel
            Login view = new Login();
            LoginController controller = new LoginController(view);
            view.ShowDialog();
        }
    }
}

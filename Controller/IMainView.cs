using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    // Main messaging window interface
    public interface IMainView
    {
        void set_controller(MainController controller);
        void display_users(DataTable users);
        void display_messages(DataTable messages, MainController.Security security);
        void close_window();

        string user_id { get; }
        string receiver_id { get; set; }
        string message { get; set; }
        bool important { get; set; }
    }
}

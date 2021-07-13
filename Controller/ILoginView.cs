using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    // Login window interface
    public interface ILoginView
    {
        void set_controller(LoginController controller);
        void show_main(string user_id, string name);
        void display_error();
    }
}

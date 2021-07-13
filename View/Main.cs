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
    public partial class Main : Form, IMainView
    {
        public Main(string user_id, string name)
        {
            InitializeComponent();
            _user_id = user_id;
            _name = name;
            row_count = 0;
        }

        string _user_id;
        string _name;
        string _receiver_id;
        int row_count;

        MainController _controller;
        MainController.Security _security;

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            _controller.send_message();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _controller.logout();
        }

        // accessed by the controller for getting the user ID
        public string user_id
        {
            get { return _user_id; }
        }

        // sets the receiver ID to current selection from the list box
        // accessed by the controller to get the receiver ID
        public string receiver_id
        {
            get { return _receiver_id; }
            set { _receiver_id = (((DataRowView)lbUsers.SelectedItem).Row[0]).ToString(); }
        }

        // sets the message to the current value of the input box
        // accessed by the controller to get the message
        public string message
        {
            get { return tbSendMessage.Text; }
            set { this.tbSendMessage.Text = value; }
        }

        // sets current value of the important tag to the current value of the check box
        // accessed by the controller to see if a message is important or not
        public bool important
        {
            get { return cbImportantTag.Checked; }
            set { this.cbImportantTag.Checked = value; }
        }

        // sets the controller for this form
        public void set_controller(MainController controller)
        {
            _controller = controller;
            lblUsername.Text = _name;
            // gets the list of registered users within the system
            _controller.get_users_table();
            // delete unimportant messages older than 6 months
            _controller.delete_messages();
        }

        // invoked by the controller to display the list of registered users
        public void display_users(DataTable users)
        {
            lbUsers.DataSource = users;
            lbUsers.DisplayMember = "name";
            lbUsers.ValueMember = "user_id";

            // invokes refresh_message_log every second to update the message log for new messages
            Timer timer = new Timer();
            timer.Tick += new EventHandler(refresh_message_log);
            timer.Interval = (1000) * (1);
            timer.Enabled = true;
            timer.Start();
        }

        // invoked every second to get all the messages
        public void refresh_message_log(object sender, EventArgs e)
        {
            _controller.get_all_messages();
        }

        // invoked by the controller to display all of the messages between two users
        public void display_messages(DataTable messages, MainController.Security security)
        {
            _security = security;
            string[] separatingStrings = { "<IMPORTANT>" };
            string[] words;
            
            // only clear and add the new messages if the row count has changed
            // this means a new message is sent or received
            if (messages.Rows.Count > row_count)
            {
                row_count = messages.Rows.Count;
                lbMessageLog.Items.Clear();
                foreach (DataRow row in messages.Rows)
                {
                    // split the message if it contains the <IMPORTANT> tag
                    words = row["messages"].ToString().Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

                    if (row["messages"].ToString().StartsWith("<IMPORTANT>"))
                    {
                        foreach (var word in words)
                        {
                            // decrypt the message before adding to the message log
                            _security.decrypt(word);
                            lbMessageLog.Items.Add(row["sender"] + ": <IMPORTANT> " + _security.get_dec_msg());
                        }
                    }
                    else
                    {
                        foreach (var word in words)
                        {
                            // decrypt the message before adding to the message log
                            _security.decrypt(word);
                            lbMessageLog.Items.Add(row["sender"] + ": " + _security.get_dec_msg());
                        }
                    }
                }
            }
            else
            {
                return;
            }

            // event for changing colours of the important messages
            lbMessageLog.DrawMode = DrawMode.OwnerDrawFixed;
            lbMessageLog.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);

            // keep vertical scroll to the bottom,
            lbMessageLog.TopIndex = lbMessageLog.Items.Count - 1;
        }

        private void listBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            // highlight the messages that are tagged as important
            if (lbMessageLog.Items[e.Index].ToString().StartsWith(lblUsername.Text + ": <IMPORTANT>") || lbMessageLog.Items[e.Index].ToString().StartsWith((((DataRowView)lbUsers.SelectedItem).Row[2]).ToString() + ": <IMPORTANT>"))
            {
                // colour the string in green if it is important
                e.Graphics.DrawString(lbMessageLog.Items[e.Index].ToString(), e.Font, Brushes.SpringGreen, new System.Drawing.PointF(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                // colour the string in black if it is not important
                e.Graphics.DrawString(lbMessageLog.Items[e.Index].ToString(), e.Font, Brushes.White, new System.Drawing.PointF(e.Bounds.X, e.Bounds.Y));
            }
            e.DrawFocusRectangle();
        }

        // change the message log conversation to the selected user
        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbMessageLog.Items.Clear();
            row_count = 0;
            _receiver_id = (((DataRowView)lbUsers.SelectedItem).Row[0]).ToString();
            _controller.get_all_messages();
        }

        // return to the login window when logged out
        public void close_window()
        {
            this.Hide();
            this.Dispose(true);
            this.Close();
            Login view = new Login();
            LoginController controller = new LoginController(view);
            view.ShowDialog();
        }

        // removes the user from the database if the application is closed using the X button
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
           _controller.logout();
        }
    }
}

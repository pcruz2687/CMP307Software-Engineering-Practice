namespace MessageApplicationMVC
{
    partial class UsersView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbMessageLog = new System.Windows.Forms.ListBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cbImportantTag = new System.Windows.Forms.CheckBox();
            this.lblMessageLog = new System.Windows.Forms.Label();
            this.lblConnectedUsers = new System.Windows.Forms.Label();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.tbSendMessage = new System.Windows.Forms.TextBox();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMessageLog
            // 
            this.lbMessageLog.FormattingEnabled = true;
            this.lbMessageLog.HorizontalExtent = 2000;
            this.lbMessageLog.HorizontalScrollbar = true;
            this.lbMessageLog.Location = new System.Drawing.Point(201, 99);
            this.lbMessageLog.Name = "lbMessageLog";
            this.lbMessageLog.Size = new System.Drawing.Size(813, 342);
            this.lbMessageLog.TabIndex = 40;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(30, 54);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 13);
            this.lblUsername.TabIndex = 39;
            // 
            // cbImportantTag
            // 
            this.cbImportantTag.AutoSize = true;
            this.cbImportantTag.Location = new System.Drawing.Point(201, 473);
            this.cbImportantTag.Name = "cbImportantTag";
            this.cbImportantTag.Size = new System.Drawing.Size(102, 17);
            this.cbImportantTag.TabIndex = 38;
            this.cbImportantTag.Text = "Tag as imporant";
            this.cbImportantTag.UseVisualStyleBackColor = true;
            // 
            // lblMessageLog
            // 
            this.lblMessageLog.AutoSize = true;
            this.lblMessageLog.Location = new System.Drawing.Point(198, 80);
            this.lblMessageLog.Name = "lblMessageLog";
            this.lblMessageLog.Size = new System.Drawing.Size(55, 13);
            this.lblMessageLog.TabIndex = 37;
            this.lblMessageLog.Text = "Messages";
            // 
            // lblConnectedUsers
            // 
            this.lblConnectedUsers.AutoSize = true;
            this.lblConnectedUsers.Location = new System.Drawing.Point(30, 80);
            this.lblConnectedUsers.Name = "lblConnectedUsers";
            this.lblConnectedUsers.Size = new System.Drawing.Size(34, 13);
            this.lblConnectedUsers.TabIndex = 36;
            this.lblConnectedUsers.Text = "Users";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(939, 445);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 35;
            this.btnSendMessage.Text = "&Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            // 
            // tbSendMessage
            // 
            this.tbSendMessage.Location = new System.Drawing.Point(201, 447);
            this.tbSendMessage.Name = "tbSendMessage";
            this.tbSendMessage.Size = new System.Drawing.Size(732, 20);
            this.tbSendMessage.TabIndex = 34;
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(30, 99);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(116, 342);
            this.lbUsers.TabIndex = 33;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(30, 447);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 32;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 544);
            this.Controls.Add(this.lbMessageLog);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.cbImportantTag);
            this.Controls.Add(this.lblMessageLog);
            this.Controls.Add(this.lblConnectedUsers);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.tbSendMessage);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.btnLogout);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMessageLog;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.CheckBox cbImportantTag;
        private System.Windows.Forms.Label lblMessageLog;
        private System.Windows.Forms.Label lblConnectedUsers;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox tbSendMessage;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.Button btnLogout;
    }
}


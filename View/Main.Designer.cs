namespace View
{
    partial class Main
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
            this.lbMessageLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.lbMessageLog.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessageLog.ForeColor = System.Drawing.Color.White;
            this.lbMessageLog.FormattingEnabled = true;
            this.lbMessageLog.HorizontalExtent = 2000;
            this.lbMessageLog.HorizontalScrollbar = true;
            this.lbMessageLog.ItemHeight = 15;
            this.lbMessageLog.Location = new System.Drawing.Point(199, 80);
            this.lbMessageLog.Name = "lbMessageLog";
            this.lbMessageLog.Size = new System.Drawing.Size(813, 334);
            this.lbMessageLog.TabIndex = 40;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(24, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(43, 21);
            this.lblUsername.TabIndex = 39;
            this.lblUsername.Text = "asdf";
            // 
            // cbImportantTag
            // 
            this.cbImportantTag.AutoSize = true;
            this.cbImportantTag.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.cbImportantTag.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbImportantTag.ForeColor = System.Drawing.Color.White;
            this.cbImportantTag.Location = new System.Drawing.Point(199, 454);
            this.cbImportantTag.Name = "cbImportantTag";
            this.cbImportantTag.Size = new System.Drawing.Size(123, 21);
            this.cbImportantTag.TabIndex = 38;
            this.cbImportantTag.Text = "Tag as imporant";
            this.cbImportantTag.UseVisualStyleBackColor = true;
            // 
            // lblMessageLog
            // 
            this.lblMessageLog.AutoSize = true;
            this.lblMessageLog.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(116)))), ((int)(((byte)(224)))));
            this.lblMessageLog.Location = new System.Drawing.Point(195, 48);
            this.lblMessageLog.Name = "lblMessageLog";
            this.lblMessageLog.Size = new System.Drawing.Size(73, 20);
            this.lblMessageLog.TabIndex = 37;
            this.lblMessageLog.Text = "Messages";
            // 
            // lblConnectedUsers
            // 
            this.lblConnectedUsers.AutoSize = true;
            this.lblConnectedUsers.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectedUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(116)))), ((int)(((byte)(224)))));
            this.lblConnectedUsers.Location = new System.Drawing.Point(24, 48);
            this.lblConnectedUsers.Name = "lblConnectedUsers";
            this.lblConnectedUsers.Size = new System.Drawing.Size(44, 20);
            this.lblConnectedUsers.TabIndex = 36;
            this.lblConnectedUsers.Text = "Users";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessage.ForeColor = System.Drawing.Color.Black;
            this.btnSendMessage.Location = new System.Drawing.Point(937, 426);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 35;
            this.btnSendMessage.Text = "&Send";
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // tbSendMessage
            // 
            this.tbSendMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSendMessage.Location = new System.Drawing.Point(199, 428);
            this.tbSendMessage.Name = "tbSendMessage";
            this.tbSendMessage.Size = new System.Drawing.Size(732, 20);
            this.tbSendMessage.TabIndex = 34;
            // 
            // lbUsers
            // 
            this.lbUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.lbUsers.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsers.ForeColor = System.Drawing.Color.White;
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.ItemHeight = 15;
            this.lbUsers.Location = new System.Drawing.Point(28, 80);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(116, 334);
            this.lbUsers.TabIndex = 33;
            this.lbUsers.SelectedIndexChanged += new System.EventHandler(this.lbUsers_SelectedIndexChanged);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(60)))), ((int)(((byte)(57)))));
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(28, 428);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 32;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1041, 506);
            this.Controls.Add(this.lbMessageLog);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.cbImportantTag);
            this.Controls.Add(this.lblMessageLog);
            this.Controls.Add(this.lblConnectedUsers);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.tbSendMessage);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Doge Financial Messaging System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
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
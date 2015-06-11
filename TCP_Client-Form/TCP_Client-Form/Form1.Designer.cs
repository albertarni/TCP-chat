namespace TCP_Client_Form
{
    partial class Form1
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
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.richTextBoxReceive = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createChatRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinChatRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonLeaveRoom = new System.Windows.Forms.Button();
            this.listBoxChatRoom = new System.Windows.Forms.ListBox();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(12, 206);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(259, 34);
            this.textBoxSend.TabIndex = 1;
            this.textBoxSend.TextChanged += new System.EventHandler(this.textBoxSend_TextChanged);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(357, 37);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(74, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(438, 37);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(71, 23);
            this.buttonDisconnect.TabIndex = 3;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(277, 209);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(71, 31);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "SEND";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(421, 11);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(88, 20);
            this.textBoxUserName.TabIndex = 6;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(354, 14);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(61, 13);
            this.labelUsername.TabIndex = 5;
            this.labelUsername.Text = "Username :";
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.HorizontalScrollbar = true;
            this.listBoxUsers.Location = new System.Drawing.Point(6, 6);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(100, 147);
            this.listBoxUsers.TabIndex = 9;
            // 
            // richTextBoxReceive
            // 
            this.richTextBoxReceive.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBoxReceive.Location = new System.Drawing.Point(12, 27);
            this.richTextBoxReceive.Name = "richTextBoxReceive";
            this.richTextBoxReceive.Size = new System.Drawing.Size(336, 160);
            this.richTextBoxReceive.TabIndex = 10;
            this.richTextBoxReceive.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sendFileToolStripMenuItem,
            this.saveFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(515, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createChatRoomToolStripMenuItem,
            this.joinChatRoomToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.fileToolStripMenuItem.Text = "Chat room";
            // 
            // createChatRoomToolStripMenuItem
            // 
            this.createChatRoomToolStripMenuItem.Name = "createChatRoomToolStripMenuItem";
            this.createChatRoomToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.createChatRoomToolStripMenuItem.Text = "Create chat room";
            this.createChatRoomToolStripMenuItem.Click += new System.EventHandler(this.createChatRoomToolStripMenuItem_Click);
            // 
            // joinChatRoomToolStripMenuItem
            // 
            this.joinChatRoomToolStripMenuItem.Name = "joinChatRoomToolStripMenuItem";
            this.joinChatRoomToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.joinChatRoomToolStripMenuItem.Text = "Join chat room";
            this.joinChatRoomToolStripMenuItem.Click += new System.EventHandler(this.joinChatRoomToolStripMenuItem_Click);
            // 
            // sendFileToolStripMenuItem
            // 
            this.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            this.sendFileToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.sendFileToolStripMenuItem.Text = "Send file";
            this.sendFileToolStripMenuItem.Click += new System.EventHandler(this.sendFileToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(378, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(120, 185);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxUsers);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(112, 159);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Users";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonLeaveRoom);
            this.tabPage2.Controls.Add(this.listBoxChatRoom);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(112, 159);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonLeaveRoom
            // 
            this.buttonLeaveRoom.Location = new System.Drawing.Point(6, 130);
            this.buttonLeaveRoom.Name = "buttonLeaveRoom";
            this.buttonLeaveRoom.Size = new System.Drawing.Size(100, 23);
            this.buttonLeaveRoom.TabIndex = 14;
            this.buttonLeaveRoom.Text = "Leave chat room";
            this.buttonLeaveRoom.UseVisualStyleBackColor = true;
            this.buttonLeaveRoom.Click += new System.EventHandler(this.buttonLeaveRoom_Click);
            // 
            // listBoxChatRoom
            // 
            this.listBoxChatRoom.FormattingEnabled = true;
            this.listBoxChatRoom.Location = new System.Drawing.Point(6, 6);
            this.listBoxChatRoom.Name = "listBoxChatRoom";
            this.listBoxChatRoom.Size = new System.Drawing.Size(100, 121);
            this.listBoxChatRoom.TabIndex = 13;
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.saveFileToolStripMenuItem.Text = "Save file";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 255);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.richTextBoxReceive);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.RichTextBox richTextBoxReceive;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createChatRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joinChatRoomToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxChatRoom;
        private System.Windows.Forms.Button buttonLeaveRoom;
        private System.Windows.Forms.ToolStripMenuItem sendFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
    }
}


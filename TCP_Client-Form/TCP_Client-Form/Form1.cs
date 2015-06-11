using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;

namespace TCP_Client_Form
{
    public partial class Form1 : Form
    {
        private Connection connection;
        private bool isConnected;
        private Thread thread;
        private string userName;
        private List<string> chatRooms;
        private string roomName = "";
        private string fileName;
        private string fileExt;
        private string fileData;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            connection = new Connection();
            isConnected = false;
            buttonSend.Enabled = false;
            buttonConnect.Enabled = false;
            buttonDisconnect.Enabled = false;
            buttonLeaveRoom.Enabled = false;
            richTextBoxReceive.ReadOnly = true;
            richTextBoxReceive.BackColor = System.Drawing.SystemColors.Window;
            listBoxUsers.Items.Add("All");
            chatRooms = new List<string>();


            thread = new Thread((ThreadStart)delegate
            {
                while (isConnected)
                {
                    if (connection.isDataAvailable())
                    {
                        receiveMessages();
                    }
                    Thread.Sleep(1000);
                }
            });
        }

        private void receiveMessages()
        {
            MessageType message = connection.receive();


            if (message.messageType == Protocol.LOGIN)
            {
                string userNameStr = message.message;
                listBoxUsers.Invoke(new UpdateTextCallback(UpdateUserNames), userNameStr);

            }
            else if (message.messageType == Protocol.LOGIN_CHATROOM)
            {
                string userNameStr = message.message;
                listBoxChatRoom.Invoke(new UpdateTextCallback(UpdateChatRoomList), userNameStr);
            }
            else if (message.messageType == Protocol.LOGOUT)
            {
                //int index = listBoxUsers.FindStringExact(message.message);
                listBoxUsers.Items.Remove(message.message);
            }
            else if (message.messageType == Protocol.LOGOUT_CHATROOM)
            {
                listBoxChatRoom.Items.Remove(message.message);
            }
            else if (message.messageType == Protocol.SEND_USERNAME_LIST)
            {
                string[] userNames = message.getUserNames();
                for (int i = 0; i < userNames.Length; i++)
                {
                    listBoxUsers.Invoke(new UpdateTextCallback(UpdateUserNames), userNames[i]);
                }
            }
            else if (message.messageType == Protocol.SEND_CHATROOM_LIST)
            {
                string[] userNames = message.getUserNames();
                for (int i = 0; i < userNames.Length; i++)
                {
                    listBoxChatRoom.Invoke(new UpdateTextCallback(UpdateChatRoomList), userNames[i]);
                }
            }
            else if (message.messageType == Protocol.MESSAGE_ALL)
            {
                message.getUserName();
                string userNameStr = message.userName;
                string messageStr = message.message;

                richTextBoxReceive.Invoke(new UpdateTextCallback(UpdateText1), userNameStr);
                richTextBoxReceive.Invoke(new UpdateTextCallback(UpdateText2), messageStr);
            }
            else if (message.messageType == Protocol.MESSAGE_PRIVATE)
            {
                message.getUserName();
                string userNameStr = message.userName;
                string messageStr = message.message;

                richTextBoxReceive.Invoke(new UpdateTextCallback(UpdateText1), userNameStr);
                richTextBoxReceive.Invoke(new UpdateTextCallback(UpdateText2), messageStr);
            }
            else if (message.messageType == Protocol.CHATROOM_NAME)
            {
                chatRooms.Add(message.message);
            }
            else if (message.messageType == Protocol.MESSAGE_CHATROOM)
            {
                message.getUserName();
                string userNameStr = message.userName;
                string messageStr = message.message;

                richTextBoxReceive.Invoke(new UpdateTextCallback(UpdateText1), userNameStr);
                richTextBoxReceive.Invoke(new UpdateTextCallback(UpdateText2), messageStr);
            }
            else if (message.messageType == Protocol.SEND_FILE)
            {
                
                string[] result = Regex.Split(message.message, Protocol.FILE_DELIM);
                fileName = result[0];
                fileExt = result[1];
                fileData = result[2];
           
            }

            
        }

        private void UpdateText1(string text)
        {
            // Set the textbox text.
            richTextBoxReceive.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
            richTextBoxReceive.SelectionColor = Color.Blue;
            richTextBoxReceive.AppendText(text + " :  ");
        }

        private void UpdateText2(string text)
        {
            // Set the textbox text.
            richTextBoxReceive.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);
            richTextBoxReceive.SelectionColor = Color.Black;
            richTextBoxReceive.AppendText(text + Environment.NewLine);
        }

        private void UpdateUserNames(string text)
        {
            // Set the textbox text.
            listBoxUsers.Items.Add(text);
        }

        private void UpdateChatRoomList(string text)
        {
            listBoxChatRoom.Items.Add(text);
        }


        public delegate void UpdateTextCallback(string text);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (connection.connect())
            {
                isConnected = true;
                thread.Start();

                userName = textBoxUserName.Text.ToString();
                connection.sendMessage(Protocol.LOGIN, userName);
                buttonDisconnect.Enabled = true;
                buttonConnect.Enabled = false;
            }                
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            /*
            if (connection.disconnect())
            {
                MessageBox.Show("disconnected");
                isConnected = false;
                thread.Abort();
                buttonDisconnect.Enabled = false;
                buttonConnect.Enabled = true;
            }
            */
            connection.sendMessage(Protocol.LOGOUT, userName);

            thread.Abort();
            isConnected = false;
            buttonDisconnect.Enabled = false;
            buttonConnect.Enabled = true;        
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string message = textBoxSend.Text.ToString();
            
            try
            {
                string text = listBoxUsers.SelectedItem.ToString();

                if (text == "All")
                {
                    if (roomName.Length == 0)
                        connection.sendMessage(Protocol.MESSAGE_ALL, message);
                    else
                    {
                        string msg = roomName + Protocol.CHAT_ROOM_DELIM + message;
                        connection.sendMessage(Protocol.MESSAGE_CHATROOM, msg);
                    }
                }
                else
                {
                    string msg = text + Protocol.USERNAME_LIST_DELIM + message;

                    connection.sendMessage(Protocol.MESSAGE_PRIVATE, msg);
                    UpdateText1(userName);
                    UpdateText2(message);
                }
            }
            catch (Exception ex) {
                if (roomName.Length == 0)
                    connection.sendMessage(Protocol.MESSAGE_ALL, message);
                else
                {
                    string msg = roomName + Protocol.CHAT_ROOM_DELIM + message;
                    connection.sendMessage(Protocol.MESSAGE_CHATROOM, msg);
                }
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isConnected)
                connection.sendMessage(Protocol.LOGOUT, userName);
            thread.Abort();
        }

        private void textBoxSend_TextChanged(object sender, EventArgs e)
        {
            string s = textBoxSend.Text.ToString();
            if (s.Length != 0)
                buttonSend.Enabled = true;
            else
                buttonSend.Enabled = false;
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            string s = textBoxUserName.Text.ToString();
            if (s.Length != 0)
                buttonConnect.Enabled = true;
            else
                buttonConnect.Enabled = false;
        }

        private void createChatRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new CreateChatRoom())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string roomName = form.roomName;
                    connection.sendMessage(Protocol.CREATE_CHAT_ROOM, roomName);
                }
            }
        }

        private void joinChatRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new JoinChatRoom(chatRooms))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    roomName = form.roomName;
                    connection.sendMessage(Protocol.JOIN_CHAT_ROOM,roomName);
                    tabControl1.TabPages[1].Text = roomName;
                    buttonLeaveRoom.Enabled = true;
                }
            }
        }

        private void buttonLeaveRoom_Click(object sender, EventArgs e)
        {
            buttonLeaveRoom.Enabled = false;
            connection.sendMessage(Protocol.LOGOUT_CHATROOM,roomName);
            roomName = "";
            tabControl1.TabPages[1].Text = roomName;

            listBoxChatRoom.Items.Clear();
        }

        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                string who = listBoxUsers.SelectedItem.ToString();
                if (who != "" && who != "All")
                {
                    FileDialog fd = new OpenFileDialog();
                    if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        connection.sendFile(who,fd.FileName);
                    }
                }
            }
            catch (Exception ex) { }

        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(fileData);


            FileDialog fd = new SaveFileDialog();
            fd.FileName = fileName;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream file = File.OpenWrite(fd.FileName + fileExt);
                file.Write(bytes, 0, bytes.Length);
            }

        }


    }
}

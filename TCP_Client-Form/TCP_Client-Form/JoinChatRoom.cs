using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Client_Form
{
    public partial class JoinChatRoom : Form
    {
        public string roomName;

        public JoinChatRoom(List<string> chatRooms)
        {
            InitializeComponent();
            button1.Enabled = false;

            foreach (string room in chatRooms)
            {
                listBox1.Items.Add(room);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.roomName = listBox1.SelectedItem.ToString();
            this.Close();
        }
    }
}

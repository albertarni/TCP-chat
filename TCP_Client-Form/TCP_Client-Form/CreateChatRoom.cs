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
    public partial class CreateChatRoom : Form
    {
        public string roomName;

        public CreateChatRoom()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void CreateChatRoom_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.roomName = textBox1.Text.ToString();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = textBox1.Text.ToString();
            if (s.Length != 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}

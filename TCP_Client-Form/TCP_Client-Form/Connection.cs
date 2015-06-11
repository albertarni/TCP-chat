using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;

namespace TCP_Client_Form
{
    class Connection
    {

        private byte[] sendBuf;
        private byte[] recvBuf;
        private TcpClient connection;
        private static string serverIp = "127.0.0.1";
        private static int serverPort = 27015;
        private IPAddress ip;
        private IPEndPoint iep;
        private NetworkStream stream;

        public Connection()
        {
            sendBuf = new byte[1024];
            recvBuf = new byte[1024];

            connection = new TcpClient();
            ip = IPAddress.Parse(serverIp);
            iep = new IPEndPoint(ip, serverPort);
        }

        public bool connect()
        {
            try
            {
                connection.Connect(iep);
                stream = connection.GetStream();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("kapcsolodas sikertelen");
                return false;
            }
        }

        public void sendMessage(string messageType, string message)
        {
            sendBuf = Encoding.ASCII.GetBytes(messageType + Protocol.MESSAGE_DELIM + message);

            try {
                stream.Write(sendBuf,0,sendBuf.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show("kuldes sikertelen");
            }
        }

        public void sendFile(string who, string fName)
        {
            byte[] fileData = File.ReadAllBytes(fName);
            if (fileData.Length > 850 * 1024)
            {
                MessageBox.Show("A fajl nem lehet nagyobb 850 kb-nal");
                return;
            }
            string fileExt = Path.GetExtension(fName);
            string fileName = Path.GetFileName(fName);

            string message = who + Protocol.USERNAME_LIST_DELIM + fileName + 
                Protocol.FILE_DELIM + fileExt + Protocol.FILE_DELIM +
                Encoding.ASCII.GetString(fileData);

            sendMessage(Protocol.SEND_FILE, message);

            /*
            FileDialog fd = new SaveFileDialog();
            fd.FileName = fileName;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream file = File.OpenWrite(fd.FileName + ext);
                file.Write(bytes, 0, bytes.Length);
            }
            */
            

        }

        public MessageType receive()
        {
            try {
                stream.Read(recvBuf, 0, recvBuf.Length);

                string message = Encoding.ASCII.GetString(recvBuf);
                string messageTrimmed = "";

                for (int i = 0; i < message.Length; i++)
                {
                    if (message.ElementAt(i) == '\0' || message.ElementAt(i) == '\n')
                        break;
                    messageTrimmed += message.ElementAt(i);
                }
                return new MessageType(messageTrimmed);
            }
            catch (Exception e)
            {
                //MessageBox.Show("fogadas sikertelen");
                return null;
            }
        }

        public bool disconnect()
        {
            try
            {
                stream.Close();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("szetkapcsolodas sikertelen");
                return false;
            }
        }

        public bool isDataAvailable()
        {
            if (stream.DataAvailable) return true;
            else return false;
        }


    }
}

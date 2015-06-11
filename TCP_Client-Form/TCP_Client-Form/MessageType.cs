using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TCP_Client_Form
{
    class MessageType
    {
        public string messageType;
        public string message;
        public string userName;

        public MessageType(string receivedString)
        {
            string[] result = Regex.Split(receivedString, Protocol.MESSAGE_DELIM);

            messageType = result[0];
            message = result[1];
        }

        public string[] getUserNames()
        {
            string[] result = Regex.Split(message, Protocol.USERNAME_LIST_DELIM);
            return result;
        }

        public void getUserName()
        {
            string[] result = Regex.Split(message, Protocol.USERNAME_LIST_DELIM);
            userName = result[0];
            message = result[1];
        }

        public string getReceiver()
        {
            string[] result = Regex.Split(message, Protocol.USERNAME_LIST_DELIM);
            userName = result[0];
            string receiver = result[1];
            message = result[2];

            return receiver;
        }
    }
}

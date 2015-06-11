using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client_Form
{
    class Protocol
    {
        public static string MESSAGE_ALL = "MSG-ALL";
        public static string MESSAGE_PRIVATE = "MSG-PRIV";
        public static string MESSAGE_CHATROOM = "MSG-ROOM";
        public static string LOGIN = "IN";
        public static string LOGOUT = "OUT";
        public static string SEND_USERNAME_LIST = "USERS";
        
        public static string MESSAGE_DELIM = "#";
        public static string USERNAME_LIST_DELIM = "!";
        public static string CHAT_ROOM_DELIM = "%";
        public static string FILE_DELIM = "&";

        public static string CREATE_CHAT_ROOM = "CRT-ROOM";
        public static string CHATROOM_NAME = "MSG-ROOM-NAME";
        public static string JOIN_CHAT_ROOM = "JOIN";
        public static string SEND_CHATROOM_LIST = "ROOM-LIST";
        public static string LOGIN_CHATROOM = "IN-ROOM";
        public static string LOGOUT_CHATROOM = "OUT-ROOM";

        public static string SEND_FILE = "FILE";
    }
}

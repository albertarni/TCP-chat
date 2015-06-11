#ifndef PROTOCOL_H
#define PROTOCOL_H

#include <cstdlib>
#include <iostream>
#include <stdlib.h>
#include <string>

using namespace std;

class Protocol {
public:
	const string MESSAGE_ALL = "MSG-ALL";
	const string MESSAGE_PRIVATE = "MSG-PRIV";
	const string MESSAGE_CHATROOM = "MSG-ROOM";
	const string LOGIN = "IN";
	const string LOGOUT = "OUT";
	const string SEND_USERNAME_LIST = "USERS";

	const string MESSAGE_DELIM = "#";
	const string USERNAME_LIST_DELIM = "!";
	const string CHAT_ROOM_DELIM = "%";
	const string FILE_DELIM = "&";

	const string CREATE_CHAT_ROOM = "CRT-ROOM";
	const string CHATROOM_NAME = "MSG-ROOM-NAME";
	const string JOIN_CHAT_ROOM = "JOIN";
	const string SEND_CHATROOM_LIST = "ROOM-LIST";
	const string LOGIN_CHATROOM = "IN-ROOM";
	const string LOGOUT_CHATROOM = "OUT-ROOM";

	const string SEND_FILE = "FILE";
};
#endif
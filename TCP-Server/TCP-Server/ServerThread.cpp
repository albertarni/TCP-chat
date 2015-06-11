#include "ServerThread.h"

typedef map<string, vector<ServerThread*> > ::iterator MapIt;

ServerThread::ServerThread(SOCKET AcceptSocket, vector<ServerThread*> *threads,
	map<string, vector<ServerThread*> > *chatRooms, CRITICAL_SECTION *criticalSection)
{

	this->AcceptSocket = AcceptSocket;
	this->threads = threads;
	this->chatRooms = chatRooms;
	this->criticalSection = criticalSection;

}

void ServerThread::run()
{

	while (true)
	{
		memset(RecvBuf, '\0', sizeof(RecvBuf));
		
		if (recv(AcceptSocket, RecvBuf, BufLen, 0) == SOCKET_ERROR){
			break;
		}
		else
		{
			EnterCriticalSection(criticalSection);


			printf("Receiving datagrams...\n");

			string str(RecvBuf);
			MessageType message(str);
			
			//////////////////////////////////////////////////////////////////////
			if (message.messaegType == protocol.LOGIN){
				userName = message.message;
				login();			
			}
			else if (message.messaegType == protocol.LOGOUT){
				logout(message.message);
			}
			//////////////////////////////////////////////////////////////////////
			else if (message.messaegType == protocol.MESSAGE_ALL){
				sendMessageAll(message.message);
			}
			/////////////////////////////////////////////////////////////////////
			else if (message.messaegType == protocol.MESSAGE_PRIVATE){
				char delim = protocol.USERNAME_LIST_DELIM.at(0);

				stringstream ss(message.message);
				string who;
				string msg;
				getline(ss, who, delim);
				getline(ss, msg, delim);

				sendMessagePrivate(who,msg);
			}
			//////////////////////////////////////////////////////////////////
			else if (message.messaegType == protocol.CREATE_CHAT_ROOM){
				createChatRoom(message.message);
				sendChatRoomName(message.message);
			}
			//////////////////////////////////////////////////////////////////
			else if (message.messaegType == protocol.JOIN_CHAT_ROOM){
				joinChatRoom(message.message);
			}
			//////////////////////////////////////////////////////////////////
			else if (message.messaegType == protocol.MESSAGE_CHATROOM){
				char delim = protocol.CHAT_ROOM_DELIM.at(0);

				stringstream ss(message.message);
				string roomName;
				string msg;
				getline(ss, roomName, delim);
				getline(ss, msg, delim);
				
				sendMessageChatRoom(roomName, msg);
			}
			/////////////////////////////////////////////////////////////////
			else if (message.messaegType == protocol.LOGOUT_CHATROOM){
				leaveChatRoom(message.message);
			}
			/////////////////////////////////////////////////////////////////
			else if (message.messaegType == protocol.SEND_FILE){
				char delim = protocol.USERNAME_LIST_DELIM.at(0);

				stringstream ss(message.message);
				string who;
				string msg;

				getline(ss, who, delim);
				getline(ss, msg, delim);

				sendFile(who, msg);
			}
			
			LeaveCriticalSection(criticalSection);
		}
	}
}

void ServerThread::login(){
	//felhasznalo nev kikuldese mindenkinek
	for (auto it = threads->begin(); it != threads->end(); it++){
		SOCKET acceptSocket = (*it)->AcceptSocket;
		char recvbuf[1024];
		string s = protocol.LOGIN + protocol.MESSAGE_DELIM + userName;
		strcpy(recvbuf, s.c_str());
		if ((*it)->userName != userName)
			send(acceptSocket, recvbuf, BufLen, 0);
	}

	//felhasznalonevek lekerdezese
	vector<string> userNames;
	for (auto it = threads->begin(); it != threads->end(); it++){
		string name = (*it)->userName;
		userNames.push_back(name);
	}

	char buf[1024];
	string s = protocol.SEND_USERNAME_LIST + protocol.MESSAGE_DELIM;
	s += userNames[0];
	for (int i = 1; i < userNames.size(); i++){
		if (userName != userNames[i])
			s += protocol.USERNAME_LIST_DELIM + userNames[i];
	}
	strcpy(buf, s.c_str());

	//felhasznaloi nevlista elkuldese
	if (userNames.size() > 1)
		send(AcceptSocket, buf, BufLen, 0);
}

void ServerThread::logout(string userName){
	for (auto it = threads->begin(); it != threads->end(); it++){
		SOCKET socket = (*it)->AcceptSocket;

		char recvbuf[1024];
		string s = protocol.LOGOUT + protocol.MESSAGE_DELIM + userName;
		strcpy(recvbuf, s.c_str());

		if (send(socket, recvbuf, BufLen, 0) == SOCKET_ERROR){
			closesocket((*it)->AcceptSocket);
			(*it)->stop();
		}
	}
}

void ServerThread::sendMessageAll(string message){
	for (auto it = threads->begin(); it != threads->end(); it++){
		SOCKET socket = (*it)->AcceptSocket;


		char recvbuf[1024];
		string s = protocol.MESSAGE_ALL + protocol.MESSAGE_DELIM + userName 
			+ protocol.USERNAME_LIST_DELIM + message;
		strcpy(recvbuf, s.c_str());

		if (send(socket, recvbuf, BufLen, 0) == SOCKET_ERROR){
			closesocket((*it)->AcceptSocket);
			(*it)->stop();
		}
		else{
			printf("Sending a datagram...\n");
		}
	}
}

void ServerThread::sendMessagePrivate(string who,string message){
	for (auto it = threads->begin(); it != threads->end(); it++){
		if ((*it)->userName == who){
			SOCKET socket = (*it)->AcceptSocket;

			char recvbuf[1024];
			string s = protocol.MESSAGE_PRIVATE + protocol.MESSAGE_DELIM + userName
				+ protocol.USERNAME_LIST_DELIM + message;
			strcpy(recvbuf, s.c_str());

			if (send(socket, recvbuf, BufLen, 0) == SOCKET_ERROR){
				closesocket((*it)->AcceptSocket);
				(*it)->stop();
				break;
			}
			else{
				printf("Sending a datagram...\n");
			}
		}
	}
}

void ServerThread::sendFile(string who, string message){
	for (auto it = threads->begin(); it != threads->end(); it++){
		if ((*it)->userName == who){
			SOCKET socket = (*it)->AcceptSocket;

			char recvbuf[1024];
			string s = protocol.SEND_FILE + protocol.MESSAGE_DELIM + message;
			strcpy(recvbuf, s.c_str());

			if (send(socket, recvbuf, BufLen, 0) == SOCKET_ERROR){
				closesocket((*it)->AcceptSocket);
				(*it)->stop();
				break;
			}
			else{
				printf("Sending a datagram...\n");
			}
		}
	}
}

void ServerThread::sendMessageChatRoom(string roomName, string message){
	MapIt iter = chatRooms->find(roomName);
	if (iter != chatRooms->end()){
		for (auto it = iter->second.begin(); it != iter->second.end(); it++){
			SOCKET socket = (*it)->AcceptSocket;

			char recvbuf[1024];
			string s = protocol.MESSAGE_CHATROOM + protocol.MESSAGE_DELIM + userName
				+ protocol.USERNAME_LIST_DELIM + message;
			strcpy(recvbuf, s.c_str());

			if (send(socket, recvbuf, BufLen, 0) == SOCKET_ERROR){
				closesocket((*it)->AcceptSocket);
				(*it)->stop();
			}
		}
	}
}

void ServerThread::createChatRoom(string roomName){
	for (auto it = threads->begin(); it != threads->end(); it++){
		if ((*it)->userName == userName){
			chatRooms->insert(make_pair(roomName, vector<ServerThread*>()));

			break;
		}
	}
}

void ServerThread::joinChatRoom(string roomName){
	MapIt iter = chatRooms->find(roomName);
	if (iter != chatRooms->end()){
		//ServerThread* thread = new ServerThread(AcceptSocket, &it->second, chatRooms, criticalSection);
		iter->second.push_back(this);


		//felhasznalo nev kikuldese mindenkinek a chatszobaban
		for (auto it = iter->second.begin(); it != iter->second.end(); it++){
			SOCKET socket = (*it)->AcceptSocket;
			char recvbuf[1024];
			string s = protocol.LOGIN_CHATROOM + protocol.MESSAGE_DELIM + userName;
			strcpy(recvbuf, s.c_str());
			if ((*it)->userName != userName)
				send(socket, recvbuf, BufLen, 0);
		}

		//felhasznalonevek lekerdezese
		vector<string> userNames;
		for (auto it = iter->second.begin(); it != iter->second.end(); it++){
			string name = (*it)->userName;
			userNames.push_back(name);
		}

		char buf[1024];
		string s = protocol.SEND_CHATROOM_LIST + protocol.MESSAGE_DELIM;
		s += userNames[0];
		for (int i = 1; i < userNames.size(); i++){
			if (userName != userNames[i])
				s += protocol.USERNAME_LIST_DELIM + userNames[i];
		}
		strcpy(buf, s.c_str());

		//felhasznaloi nevlista elkuldese
		if (userNames.size() > 1)
			send(AcceptSocket, buf, BufLen, 0);

	}
}

void ServerThread::leaveChatRoom(string roomName){
	MapIt iter = chatRooms->find(roomName);
	if (iter != chatRooms->end()){
		for (auto it = iter->second.begin(); it != iter->second.end(); it++){
			SOCKET socket = (*it)->AcceptSocket;
			char recvbuf[1024];
			string s = protocol.LOGOUT_CHATROOM + protocol.MESSAGE_DELIM + userName;
			strcpy(recvbuf, s.c_str());

			if (send(socket, recvbuf, BufLen, 0) == SOCKET_ERROR){
				closesocket((*it)->AcceptSocket);
				(*it)->stop();
			}
			if ((*it)->userName == userName){
				closesocket((*it)->AcceptSocket);
				(*it)->stop();
			}
		}
	}
}

void ServerThread::sendChatRoomName(string roomName){
	for (auto it = threads->begin(); it != threads->end(); it++){
		SOCKET socket = (*it)->AcceptSocket;

		char recvbuf[1024];
		string s = protocol.CHATROOM_NAME + protocol.MESSAGE_DELIM + roomName;
		strcpy(recvbuf, s.c_str());

		if (send(socket, recvbuf, BufLen, 0) == SOCKET_ERROR){
			closesocket((*it)->AcceptSocket);
			(*it)->stop();
			break;
		}
	}
}
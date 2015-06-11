#ifndef SERVERTHREAD_H
#define SERVERTHREAD_H
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include "winsock2.h"
#include <vector>
#include <string>
#include <sstream>
#include <map>

#include "SysThread.h"
#include "MessageType.h"
#include "Protocol.h"
using namespace std;

class ServerThread : public SysThread
{
private:
	SOCKET AcceptSocket;
	char RecvBuf[1024];
	char SendBuf[1024];
	int BufLen = 1024;
	vector<ServerThread*> *threads;
	map<string, vector<ServerThread*> > *chatRooms;
	CRITICAL_SECTION *criticalSection;
	string userName;
	Protocol protocol;
	void login();
	void logout(string userName);
	void sendMessageAll(string message);
	void sendMessagePrivate(string who, string message);
	void sendMessageChatRoom(string roomName, string message);
	void createChatRoom(string roomName);
	void sendChatRoomName(string roomName);
	void joinChatRoom(string roomName);
	void leaveChatRoom(string roomName);
	void sendFile(string who,string message);
public:
	ServerThread(SOCKET AcceptSocket, vector<ServerThread*> *threads, 
		map<string, vector<ServerThread*> > *chatRooms, CRITICAL_SECTION* criticalSection);
	virtual void run();

};
#endif
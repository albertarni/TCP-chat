#ifndef TCPSERVER_H
#define TCPSERVER_H
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include "winsock2.h"
#include <string>
#include <vector>
#include <map>

#include "ServerThread.h"

using namespace std;

class TcpServer
{
private:
	string host;
	int port;
	WSADATA wsaData;
	SOCKET ListenSocket;
	sockaddr_in service;
	SOCKET AcceptSocket;
	vector<ServerThread*> threads;
	CRITICAL_SECTION criticalSection;
	map<string, vector<ServerThread*> > chatRooms;
public:
	TcpServer(string host, int port);
	void init();
	void runServer();

};
#endif
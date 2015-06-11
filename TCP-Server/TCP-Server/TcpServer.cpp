#include "TcpServer.h"

TcpServer::TcpServer(string host, int port)
{
	this->host = host;
	this->port = port;

	init();
}

void TcpServer::init()
{
	// Initialize Winsock.
	int iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != NO_ERROR) {
		printf("Error at WSAStartup()\n");
		return;
	}

	// Create a SOCKET for listening for
	// incoming connection requests.
	ListenSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (ListenSocket == INVALID_SOCKET) {
		printf("Error at socket(): %ld\n", WSAGetLastError());
		WSACleanup();
		return;
	}

	// The sockaddr_in structure specifies the address family,
	// IP address, and port for the socket that is being bound.
	service.sin_family = AF_INET;
	service.sin_addr.s_addr = inet_addr(host.c_str());
	service.sin_port = htons(port);
	if (bind(ListenSocket, (SOCKADDR*)&service, sizeof(service)) == SOCKET_ERROR) {
		printf("bind() failed.\n");
		closesocket(ListenSocket);
		WSACleanup();
		return;
	}

	// Listen for incoming connection requests.
	// on the created socket
	if (listen(ListenSocket, 1) == SOCKET_ERROR) {
		printf("Error listening on socket.\n");
		closesocket(ListenSocket);
		WSACleanup();
		return;
	}

	InitializeCriticalSection(&criticalSection);
}

void TcpServer::runServer()
{
	while (1){
		printf("Waiting for client to connect...\n");

		AcceptSocket = accept(ListenSocket, NULL, NULL);
		if (AcceptSocket == INVALID_SOCKET) {
			printf("accept failed: %d\n", WSAGetLastError());
			closesocket(ListenSocket);
			WSACleanup();
			return;
		}
		else{
			printf("Client connected.\n");
		}

		ServerThread* thread = new ServerThread(AcceptSocket, &threads,&chatRooms ,&criticalSection);
		threads.push_back(thread);

		thread->start();
	}

	// Clean up and quit.
	printf("Exiting.\n");
	WSACleanup();
}


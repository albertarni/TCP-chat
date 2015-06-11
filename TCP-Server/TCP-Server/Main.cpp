#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include "TcpServer.h"

using namespace std;


void main() {

	TcpServer server("192.168.0.101", 22000);
	server.runServer();

	system("pause");
	return;
}

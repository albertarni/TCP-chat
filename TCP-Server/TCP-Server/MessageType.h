#ifndef MESSAGETYPE_H
#define	MESSAGETYPE_H

#include <cstdlib>
#include <iostream>
#include <stdlib.h>
#include <string>
#include <sstream>
#include <vector>

#include "Protocol.h"

using namespace std;

class MessageType {
public:
	MessageType(string receivedString);
	string messaegType;
	string message;
	string userName;
};
#endif





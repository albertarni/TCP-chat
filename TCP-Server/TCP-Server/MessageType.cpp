#include "MessageType.h"

MessageType::MessageType(string receivedString){
	Protocol protocol;
	char delim = protocol.MESSAGE_DELIM.at(0);
	vector<string> result;
	
	stringstream ss(receivedString);
	string word;
	while (getline(ss, word, delim)){
		result.push_back(word);
	}

	messaegType = result[0];
	message = result[1];
	
}

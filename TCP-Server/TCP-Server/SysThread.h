#ifndef SYSTHREAD_H
#define SYSTHREAD_H

#include <cstdlib>
#include <iostream>
#include <string>
#include <limits.h>
#include <windows.h>

using namespace std;

class SysThread
{
public:
	static const unsigned int INFINIT_WAIT;

	SysThread(void);
	virtual ~SysThread();
	virtual bool start(void);
	virtual bool stop(unsigned int timeout = 0);
	inline volatile bool& isRunning(void){
		return m_bRunning;
	}
	inline volatile bool& isExited(void){
		return m_bExited;
	}

protected:
	//Ezt a metodust a származtatott 
	//osztályban felül kell írni.Ide kell beírni az utasítás szekvenciát
	//amit a szálunk végre kell hajtson
	virtual void run(void);

private:
	friend DWORD WINAPI runStub(LPVOID mthread);
	volatile bool m_bRunning;
	volatile bool m_bExited;
	HANDLE m_thread;
};

#endif
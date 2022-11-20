#include "pch.h"
#include "CoppeliaSimInterface.h"

#include <iostream>
#include <stdio.h>
#include <string>
#include <chrono>
#include <windows.h>

extern "C" {
#include "remoteApi/extApi.h"
}



CoppeliaSimInterface::CoppeliaSimInterface(int portnb)
{
	this->portNb = portnb;
	int pioneerHandleVar;
	int leftMotorHandleVar;
	int rightMotorHandleVar;
	clientID = simxStart((simxChar*)"127.0.0.1", portNb, true, true, 2000, 5);
	dw("Remote API client started. Client ID: " + std::to_string(clientID));

	//Retrieving object handles
	if (simxGetObjectHandle(clientID, "Pioneer_p3dx", (simxInt*) &pioneerHandleVar, simx_opmode_blocking) != 0) {
		dw("Could not retreive handle of Pioneer.");
		extApi_sleepMs(5000);
	}
	else {
		this->pioneerHandle = pioneerHandleVar;
		dw("Pioneer Handle kesz.");
	}

	if (simxGetObjectHandle(clientID, "Pioneer_p3dx_rightMotor", (simxInt*) &rightMotorHandleVar, simx_opmode_blocking) != 0) {
		dw("Could not retreive handle of Pioneer Right Motor.");
		extApi_sleepMs(5000);
	}
	else {
		this->rightMotorHandle = rightMotorHandleVar;
		dw("Right Motor Handle kesz.");
	}

	if (simxGetObjectHandle(clientID, "Pioneer_p3dx_leftMotor", (simxInt*) &leftMotorHandleVar, simx_opmode_blocking) != 0) {
		dw("Could not retreive handle of Pioneer Left Motor.");
		extApi_sleepMs(5000);
	}
	else {
		this->leftMotorHandle = leftMotorHandleVar;
		dw("Left Motor Handle kesz.");
	}



	simxSynchronous(clientID, true); //turn on stepped mode
	simxStartSimulation(clientID, simx_opmode_blocking); //Starting simulation
}

void CoppeliaSimInterface::dw(std::string text)
{
#ifdef DEBUG_MODE_ON_KONCZ
	std::cout << text << std::endl;
#endif
}

void CoppeliaSimInterface::SimIteration()
{
	//Executes next iteration, and puts the new values into attributes.
	float tempLin[3];
	float tempAng[3];
	int pingTime;
	simxSynchronousTrigger(clientID); //Next step of simulation
	simxGetPingTime(clientID, &pingTime); //Ensure that the step is over
	this->pingTime = pingTime;
	simxGetObjectVelocity(clientID, pioneerHandle, &tempLin[0], &tempAng[0], simx_opmode_blocking);
	pioneer_vx = tempLin[0];
	pioneer_vy = tempLin[1];
	pioneer_vz = tempLin[2];
	pioneer_valpha = tempAng[0];
	pioneer_vbeta = tempAng[1];
	pioneer_vgamma = tempAng[2];
	pioneer_v = sqrt(pioneer_vx*pioneer_vx + pioneer_vy*pioneer_vy + pioneer_vz*pioneer_vz);
	//Sleep(100);
	return;
}


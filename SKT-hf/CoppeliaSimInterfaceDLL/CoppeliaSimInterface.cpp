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
	int consoleHandleVar;
	int pioneerHandleVar;
	int leftMotorHandleVar;
	int rightMotorHandleVar;
	clientID = simxStart((simxChar*)"127.0.0.1", portNb, true, true, 2000, 5);
	dw("Remote API client started. Client ID: " + std::to_string(clientID));

	//Opening Auxiliary console
	simxAuxiliaryConsoleOpen(clientID, "Remote API console", 30, 01101, NULL, NULL, NULL, NULL, &consoleHandleVar, simx_opmode_blocking);
	this->consoleHandle = consoleHandleVar;
	simxAuxiliaryConsoleShow(clientID, consoleHandle, 1, simx_opmode_blocking);
	dw("Auxiliary console opened!");
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "Hello from the other side! \n", simx_opmode_blocking);
	
	//Retrieving object handles
	if (simxGetObjectHandle(clientID, "Pioneer_p3dx", (simxInt*) &pioneerHandleVar, simx_opmode_blocking) != 0) {
		dw("Could not retreive handle of Pioneer.");
		simxAuxiliaryConsolePrint(clientID, consoleHandle, "Could not retreive handle of Pioneer. \n", simx_opmode_blocking);
		extApi_sleepMs(5000);
	}
	else {
		this->pioneerHandle = pioneerHandleVar;
		dw("Pioneer Handle kesz.");
		simxAuxiliaryConsolePrint(clientID, consoleHandle, "Pioneer Handle kesz. \n", simx_opmode_blocking);
	}

	if (simxGetObjectHandle(clientID, "Pioneer_p3dx_rightMotor", (simxInt*) &rightMotorHandleVar, simx_opmode_blocking) != 0) {
		dw("Could not retreive handle of Pioneer Right Motor.");
		simxAuxiliaryConsolePrint(clientID, consoleHandle, "Could not retreive handle of Pioneer Right Motor. \n", simx_opmode_blocking);
		extApi_sleepMs(5000);
	}
	else {
		this->rightMotorHandle = rightMotorHandleVar;
		dw("Right Motor Handle kesz.");
		simxAuxiliaryConsolePrint(clientID, consoleHandle, "Right Motor Handle kesz. \n", simx_opmode_blocking);
	}

	if (simxGetObjectHandle(clientID, "Pioneer_p3dx_leftMotor", (simxInt*) &leftMotorHandleVar, simx_opmode_blocking) != 0) {
		dw("Could not retreive handle of Pioneer Left Motor.");
		simxAuxiliaryConsolePrint(clientID, consoleHandle, "Could not retreive handle of Pioneer Left Motor. \n", simx_opmode_blocking);
		extApi_sleepMs(5000);
	}
	else {
		this->leftMotorHandle = leftMotorHandleVar;
		dw("Left Motor Handle kesz.");
		simxAuxiliaryConsolePrint(clientID, consoleHandle, "Left Motor Handle kesz. \n", simx_opmode_blocking);
	}

	//...ultrasonic sensor handles
	for (int i = 0; i < 16; i++)
	{
		char sensorName[33] = "Pioneer_p3dx_ultrasonicSensor";
		char strI[2];
		sprintf(strI, "%d", i+1); //a deprecated nevek nem 0-tol, hanem 1-tol vannak szamozva!!!
		strcat(sensorName, strI);
		int sensorHandleVar;
		if (simxGetObjectHandle(clientID, sensorName, (simxInt*)&sensorHandleVar, simx_opmode_blocking) != 0) {
			dw("Could not retreive handle of Pioneer Ultrasonic Sensor.");
			simxAuxiliaryConsolePrint(clientID, consoleHandle, "Could not retreive handle of Pioneer Ultrasonic Sensor. \n", simx_opmode_blocking);
			extApi_sleepMs(5000);
		}
		else {
			this->sensorHandles[i] = sensorHandleVar;
			dw("Ultrasonic Sensor Handle kesz.");
			simxAuxiliaryConsolePrint(clientID, consoleHandle, "Ultrasonic Sensor Handle kesz. \n", simx_opmode_blocking);
		}
	}


	simxSynchronous(clientID, true); //turn on stepped mode
	//simxStartSimulation(clientID, simx_opmode_blocking); //Starting simulation
}

//gyors konzol kiiras debug modban
void CoppeliaSimInterface::dw(std::string text)
{
#ifdef DEBUG_MODE_ON_KONCZ
	std::cout << text << std::endl;
#endif
}

void CoppeliaSimInterface::SimIteration()
{
	//Executes next iteration, and puts the new values into attributes.
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "New iteration step started... \n", simx_opmode_blocking);
	float tempLin[3];
	float tempAng[3];
	int pingTime;
	float tempOri[3];
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
	simxGetObjectOrientation(clientID, pioneerHandle, -1, &tempOri[0], simx_opmode_blocking);
	pioneer_Oalpha = tempOri[0];
	pioneer_Obeta = tempOri[1];
	pioneer_Ogamma = tempOri[2];

	//proximity sensors' data for Hammas Atti's visualization
	simxUChar detectionState;
	float detectedPoint[3];
	for (int i = 0; i < 16; i++)
	{
		simxReadProximitySensor(clientID, sensorHandles[i], &detectionState, &detectedPoint[0], NULL, NULL, simx_opmode_blocking);
		if (detectionState == 1)
		{
			this->sensorVisualizer[i] = sqrt(detectedPoint[0] * detectedPoint[0] + detectedPoint[1] * detectedPoint[1] + detectedPoint[2] * detectedPoint[2]);
				
		}
		else
		{
			this->sensorVisualizer[i] = 1;
		}
	}
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "...iteration step calculation finished! \n", simx_opmode_blocking);
	//Sleep(100);
	return;
}

void CoppeliaSimInterface::GetPioneerControl()
{
	//taking over control of Pioneer
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "Taking over Pioneer control... \n", simx_opmode_blocking);
	simxSetInt32Signal(clientID, "controlledByUser", 1, simx_opmode_blocking);
	simxSetJointTargetVelocity(clientID, leftMotorHandle, 0.0f, simx_opmode_oneshot);
	simxSetJointTargetVelocity(clientID, rightMotorHandle, 0.0f, simx_opmode_oneshot);
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "...control taken over successfully! \n", simx_opmode_blocking);
}
void CoppeliaSimInterface::ReleasePioneerControl()
{
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "Releasing Pioneer Control... \n", simx_opmode_blocking);
	simxSetInt32Signal(clientID, "controlledByUser", 0, simx_opmode_blocking);
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "...control released successfully! \n", simx_opmode_blocking);
}

void CoppeliaSimInterface::SetPioneer_vleftmotor(float v)
{
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "Setting v left... \n", simx_opmode_blocking);
	simxSetJointTargetVelocity(clientID, leftMotorHandle, v, simx_opmode_oneshot);
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "...v left is set! \n", simx_opmode_blocking);
}
void CoppeliaSimInterface::SetPioneer_vrightmotor(float v)
{
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "Setting v right... \n", simx_opmode_blocking);
	simxSetJointTargetVelocity(clientID, rightMotorHandle, v, simx_opmode_oneshot);
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "...v right is set! \n", simx_opmode_blocking);
}

void CoppeliaSimInterface::StopSimulation()
{
	simxStopSimulation(clientID, simx_opmode_blocking);
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "Simulation stopped! \n", simx_opmode_blocking);
}
void CoppeliaSimInterface::PauseSimulation()
{
	simxPauseSimulation(clientID, simx_opmode_blocking);
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "Simulation paused! \n", simx_opmode_blocking);
}
void CoppeliaSimInterface::StartSimulation()
{
	simxStartSimulation(clientID, simx_opmode_blocking);
	simxAuxiliaryConsolePrint(clientID, consoleHandle, "Simulation started! \n", simx_opmode_blocking);
}


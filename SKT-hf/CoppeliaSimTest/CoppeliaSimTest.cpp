//------- elso szarnyprobalgatasok------------
// fasz1.ttt-hez!

#include <iostream>
#include <stdio.h>
#include <string>
#include <chrono>
#include <windows.h>
//#include "stdafx.h"

extern "C" {
#include "remoteApi/extApi.h"
}



int main(int argc, char* argv[]) {

	const int portNb = 19997;

	int clientID = simxStart((simxChar*)"127.0.0.1", portNb, true, true, 2000, 5);
	std::cout << "Remote API client started. Client ID: " << clientID << std::endl;

	int cube1Handle;
	if (simxGetObjectHandle(clientID, "Cuboid_1", &cube1Handle, simx_opmode_blocking) != 0) {
		std::cout << "Could not retreive handle of cuboid1." << std::endl;
		extApi_sleepMs(5000);
		return 0;
	}



	if (clientID != -1)
	{
		simxFloat cube1VelLin[3]; //velocity; x y z component
		simxFloat cube1VelAng[3]; //angular velocity; alpha beta gamma
		simxInt pingTime = 0;
		simxInt myTestVar = 0;

		simxSynchronous(clientID, true); //turn on stepped mode
		simxStartSimulation(clientID, simx_opmode_blocking);

		
		for (int i = 0; i < 200; i++)
		{
			simxSynchronousTrigger(clientID); //Next step of simulation
			simxGetPingTime(clientID, &pingTime); //Ensure that the step is over
			simxGetObjectVelocity(clientID, cube1Handle, &cube1VelLin[0], &cube1VelAng[0], simx_opmode_blocking);
			simxGetIntegerSignal(clientID, "myTestVar", &myTestVar, simx_opmode_blocking);
			printf("Velocity: X:%1.2f Y:%1.2f Z:%1.2f  ||| i:%d  Ping:%d ms TestVar:%d \n", cube1VelLin[0], cube1VelLin[1], cube1VelLin[2], i, pingTime, myTestVar);
			//Sleep(100);
		}
		
		simxStopSimulation(clientID, simx_opmode_blocking);
		extApi_sleepMs(500);
		simxFinish(clientID);
	}

	return(0);
}

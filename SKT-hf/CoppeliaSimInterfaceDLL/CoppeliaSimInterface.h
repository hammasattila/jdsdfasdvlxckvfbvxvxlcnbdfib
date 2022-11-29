#pragma once

//#define DEBUG_MODE_ON_KONCZ
#include <iostream>
#include <string>

class CoppeliaSimInterface
{
public:
	int portNb = 19997;
	int clientID;
	int pioneerHandle;
	int leftMotorHandle, rightMotorHandle;

	int pingTime;
	float pioneer_vx, pioneer_vy, pioneer_vz, pioneer_valpha, pioneer_vbeta, pioneer_vgamma; //velocity and angular velocity components
	float pioneer_v; //eredo sebesseg (halado mozgas)
	float pioneer_Oalpha, pioneer_Obeta, pioneer_Ogamma; //orientation components (Euler-angle)
	
public:
	CoppeliaSimInterface(int portnb);
	static void dw(std::string text);
	void SimIteration();
	void GetPioneerControl();
	void ReleasePioneerControl();
	void SetPioneer_vleftmotor(float v);
	void SetPioneer_vrightmotor(float v);
	void StopSimulation();
	void PauseSimulation();
	void StartSimulation();
};

extern "C" __declspec(dllexport) void* csharp_CoppeliaSimInterface(int portnb) {
	return (void*) new CoppeliaSimInterface(portnb);
}
extern "C" __declspec(dllexport) void csharp_SimIteration(CoppeliaSimInterface* a) {
	a->SimIteration();
	return;
}
extern "C" __declspec(dllexport) float csharp_GetPioneer_vx(CoppeliaSimInterface* a) {
	return a->pioneer_vx;
}
extern "C" __declspec(dllexport) float csharp_GetPioneer_vy(CoppeliaSimInterface * a) {
	return a->pioneer_vy;
}
extern "C" __declspec(dllexport) float csharp_GetPioneer_vz(CoppeliaSimInterface * a) {
	return a->pioneer_vz;
}
extern "C" __declspec(dllexport) float csharp_GetPioneer_valpha(CoppeliaSimInterface * a) {
	return a->pioneer_valpha;
}
extern "C" __declspec(dllexport) float csharp_GetPioneer_vbeta(CoppeliaSimInterface * a) {
	return a->pioneer_vbeta;
}
extern "C" __declspec(dllexport) float csharp_GetPioneer_vgamma(CoppeliaSimInterface * a) {
	return a->pioneer_vgamma;
}
extern "C" __declspec(dllexport) float csharp_GetPioneer_v(CoppeliaSimInterface * a) {
	return a->pioneer_v;
}
extern "C" __declspec(dllexport) int csharp_GetPingTime(CoppeliaSimInterface * a) {
	return a->pingTime;
}
extern "C" __declspec(dllexport) float csharp_GetPioneer_Oalpha(CoppeliaSimInterface * a) {
	return a->pioneer_Oalpha;
}
extern "C" __declspec(dllexport) float csharp_GetPioneer_Obeta(CoppeliaSimInterface * a) {
	return a->pioneer_Obeta;
}
extern "C" __declspec(dllexport) float csharp_GetPioneer_Ogamma(CoppeliaSimInterface * a) {
	return a->pioneer_Ogamma;
}
extern "C" __declspec(dllexport) void csharp_GetPioneerControl(CoppeliaSimInterface * a) {
	return a->GetPioneerControl();
}
extern "C" __declspec(dllexport) void csharp_ReleasePioneerControl(CoppeliaSimInterface * a) {
	return a->ReleasePioneerControl();
}
extern "C" __declspec(dllexport) void csharp_SetPioneer_vleftmotor(CoppeliaSimInterface * a, float v) {
	a->SetPioneer_vleftmotor(v);
	return;
}
extern "C" __declspec(dllexport) void csharp_SetPioneer_vrightmotor(CoppeliaSimInterface * a, float v) {
	a->SetPioneer_vrightmotor(v);
	return;
}
extern "C" __declspec(dllexport) void csharp_StopSimulation(CoppeliaSimInterface * a) {
	a->StopSimulation();
	return;
}
extern "C" __declspec(dllexport) void csharp_PauseSimulation(CoppeliaSimInterface * a) {
	a->PauseSimulation();
	return;
}
extern "C" __declspec(dllexport) void csharp_StartSimulation(CoppeliaSimInterface * a) {
	a->StartSimulation();
	return;
}

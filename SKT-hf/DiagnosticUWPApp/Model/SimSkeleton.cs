using System;
using System.Runtime.InteropServices;

namespace DiagnosticUWPApp.Model
{
    public class SimSkeleton
    {
        public static IntPtr Simulation;
        private const int portNumber = 19997;
        private static object syncObject;

        public SimSkeleton()
        {
            syncObject = new Object();
            SimInterfaceInit();
        }

        public static void SimInterfaceInit()
        {
            Simulation = csharp_CoppeliaSimInterface(portNumber);
        }

        public static void StartSimulation()
        {
            lock (syncObject)
            {
                csharp_StartSimulation(Simulation);
            }
        }

        public static void StopSimulation()
        {
            lock (syncObject)
            {
                csharp_StopSimulation(Simulation);
            }
        }

        public static void SimIteration()
        {
            lock (syncObject)
            {
                csharp_SimIteration(Simulation);
            }
        }

        public static void GetControl()
        {
            lock (syncObject)
            {
                csharp_GetPioneerControl(Simulation);
            }
        }

        public static void ReleaseControl()
        {
            lock (syncObject)
            {
                csharp_ReleasePioneerControl(Simulation);
            } 
        }

        public static (float velocity, float orientation, int pingTime) GetData()
        {
            float v, o;
            int p;
            
            v = csharp_GetPioneer_v(Simulation);
            o = csharp_GetPioneer_Ogamma(Simulation);
            p = csharp_GetPingTime(Simulation);

            return (v, o, p);
        }

        public static float GetSensorData(int sensorNb)
        {
            return csharp_GetSensorVisualizerValue(Simulation, sensorNb);
        }

        public static void SetWheelSpeed(float leftWheelSpeed, float rightWheelSpeed)
        {
            lock (syncObject)
            {
                csharp_SetPioneer_vleftmotor(Simulation, leftWheelSpeed);
                csharp_SetPioneer_vrightmotor(Simulation, rightWheelSpeed);
            }
        }

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr csharp_CoppeliaSimInterface(int portnb);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void csharp_SimIteration(IntPtr a);

        //---------------- Pioneer robot velocity components ------------------------
        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float csharp_GetPioneer_vx(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float csharp_GetPioneer_vy(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float csharp_GetPioneer_vz(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float csharp_GetPioneer_valpha(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float csharp_GetPioneer_vbeta(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float csharp_GetPioneer_vgamma(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float csharp_GetPioneer_v(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int csharp_GetPingTime(IntPtr a);

        //------------ Orientation -------------------------------
        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float csharp_GetPioneer_Oalpha(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float csharp_GetPioneer_Obeta(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float csharp_GetPioneer_Ogamma(IntPtr a);

        //------------ Sensors -------------------------------
        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float csharp_GetSensorVisualizerValue(IntPtr a, int sensorNb);

        //------------- Getting and Releasing control of Pioneer--------------
        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void csharp_GetPioneerControl(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void csharp_ReleasePioneerControl(IntPtr a);

        //Setting the Velocity of Pioneer's left and right motor
        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void csharp_SetPioneer_vleftmotor(IntPtr a, float v);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void csharp_SetPioneer_vrightmotor(IntPtr a, float v);

        //Stopping, Pausing and Starting Simulation
        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void csharp_StopSimulation(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void csharp_PauseSimulation(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void csharp_StartSimulation(IntPtr a);
    }
}

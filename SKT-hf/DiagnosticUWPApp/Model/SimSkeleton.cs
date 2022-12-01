using DiagnosticUWPApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticUWPApp.Model
{
    public class SimSkeleton
    {
        public static IntPtr Simulation;

        public SimSkeleton(int portNumber)
        {
            Simulation = csharp_CoppeliaSimInterface(portNumber);
        }

        public static void StartSimulation()
        {
            csharp_StartSimulation(Simulation);
        }

        public static void StopSimulation()
        {
            csharp_StopSimulation(Simulation);
        }

        public static void SimIteration()
        {
            csharp_SimIteration(Simulation);
        }

        public static void GetControl()
        {
            csharp_GetPioneerControl(Simulation);
        }

        public static void ReleaseControl()
        {
            csharp_ReleasePioneerControl(Simulation);
        }

        public static float GetVelocity()
        {
            return csharp_GetPioneer_v(Simulation);
        }

        public static float GetOrientation()
        {
            return csharp_GetPioneer_Ogamma(Simulation);
        }

        public static int GetPingTime()
        {
            return csharp_GetPingTime(Simulation);
        }

        public static void SetWheelSpeed(float leftWheelSpeed, float rightWheelSpeed)
        {
            csharp_SetPioneer_vleftmotor(Simulation, leftWheelSpeed);
            csharp_SetPioneer_vrightmotor(Simulation, rightWheelSpeed);
        }

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern IntPtr csharp_CoppeliaSimInterface(int portnb);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern void csharp_SimIteration(IntPtr a);

        //---------------- Pioneer robot velocity components ------------------------
        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_vx(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_vy(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_vz(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_valpha(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_vbeta(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_vgamma(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_v(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern int csharp_GetPingTime(IntPtr a);

        //------------ Orientation -------------------------------
        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_Oalpha(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_Obeta(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_Ogamma(IntPtr a);

        //------------- Getting and Releasing control of Pioneer--------------
        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern void csharp_GetPioneerControl(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern void csharp_ReleasePioneerControl(IntPtr a);

        //Setting the Velocity of Pioneer's left and right motor
        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern void csharp_SetPioneer_vleftmotor(IntPtr a, float v);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern void csharp_SetPioneer_vrightmotor(IntPtr a, float v);

        //Stopping, Pausing and Starting Simulation
        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern void csharp_StopSimulation(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern void csharp_PauseSimulation(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern void csharp_StartSimulation(IntPtr a);
    }
}

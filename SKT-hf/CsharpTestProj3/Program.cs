using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace CsharpTestProj3
{
    internal class Program
    {

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr csharp_CoppeliaSimInterface(int portnb);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void csharp_SimIteration(IntPtr a);
        //---------------- Pioneer robot sebessegkomponensei ------------------------

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float csharp_GetPioneer_vx(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float csharp_GetPioneer_vy(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float csharp_GetPioneer_vz(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float csharp_GetPioneer_valpha(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float csharp_GetPioneer_vbeta(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float csharp_GetPioneer_vgamma(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float csharp_GetPioneer_v(IntPtr a); //<--------- v eredo

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int csharp_GetPingTime(IntPtr a);

        //------------ Orientacio -------------------------------
        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float csharp_GetPioneer_Oalpha(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float csharp_GetPioneer_Obeta(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float csharp_GetPioneer_Ogamma(IntPtr a); //<--------- z-tengely koruli forgatas

        //------------- Getting and Releasing control of Pioneer--------------
        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void csharp_GetPioneerControl(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void csharp_ReleasePioneerControl(IntPtr a);

        //Setting the Velocity of Pioneer's left and right motor
        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void csharp_SetPioneer_vleftmotor(IntPtr a, float v);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void csharp_SetPioneer_vrightmotor(IntPtr a, float v);

        //Stopping, Pausing and Starting Simulation
        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void csharp_StopSimulation(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void csharp_PauseSimulation(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void csharp_StartSimulation(IntPtr a);

        //Pioneer robot proximity szenzor ertekei (szenzorok szamozasa 0...15):
        [DllImport("CoppeliaSimInterfaceDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float csharp_GetSensorVisualizerValue(IntPtr a, int sensorNb);



        static void Main(string[] args)
        {
            IntPtr b = csharp_CoppeliaSimInterface(19997);
            csharp_StartSimulation(b);
            
            for (int i = 0;i<50;i++)
            {
                csharp_SimIteration(b);
                Console.WriteLine(csharp_GetPioneer_v(b) + " " + csharp_GetPioneer_Oalpha(b) + " " + csharp_GetPioneer_Obeta(b) + " " + csharp_GetPioneer_Ogamma(b) + " Sensor4 data:" + csharp_GetSensorVisualizerValue(b, 4));
            }
            csharp_GetPioneerControl(b);
            csharp_SetPioneer_vleftmotor(b, 4);
            csharp_SetPioneer_vrightmotor(b, 4);
            Console.WriteLine("Pioneer control taken over.. ---------------------------------------------");
            for (int i = 0; i < 20; i++)
            {
                csharp_SimIteration(b);
                Console.WriteLine(csharp_GetPioneer_v(b) + " " + csharp_GetPioneer_Oalpha(b) + " " + csharp_GetPioneer_Obeta(b) + " " + csharp_GetPioneer_Ogamma(b) + " Sensor4 data:" + csharp_GetSensorVisualizerValue(b, 4));
            }
            csharp_ReleasePioneerControl(b);
            Console.WriteLine("Pioneer control released.. -----------------------------");
            for (int i = 0; i < 50; i++)
            {
                csharp_SimIteration(b);
                Console.WriteLine(csharp_GetPioneer_v(b) + " " + csharp_GetPioneer_Oalpha(b) + " " + csharp_GetPioneer_Obeta(b) + " " + csharp_GetPioneer_Ogamma(b) + " Sensor4 data:" + csharp_GetSensorVisualizerValue(b, 4));
            }

            csharp_StopSimulation(b);
            Console.WriteLine("Simulation stopped.");
        }
    }
}

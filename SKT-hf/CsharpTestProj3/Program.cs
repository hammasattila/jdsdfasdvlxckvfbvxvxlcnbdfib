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

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern IntPtr Create(int x);
        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern int AttemptAdd(IntPtr a, int y);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern IntPtr csharp_CoppeliaSimInterface(int portnb);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern void csharp_SimIteration(IntPtr a);

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

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_Oalpha(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_Obeta(IntPtr a);

        [DllImport("CoppeliaSimInterfaceDLL.dll")]
        public static extern float csharp_GetPioneer_Ogamma(IntPtr a);



        static void Main(string[] args)
        {
            //IntPtr a = Create(5);
            //Console.WriteLine(AttemptAdd(a,10));
            //Console.WriteLine("\n miliméteres a faszod");

            IntPtr b = csharp_CoppeliaSimInterface(19997);
            Console.WriteLine("\n siker \n");

            
            for (int i = 0;i<500;i++)
            {
                csharp_SimIteration(b);
                Console.WriteLine(csharp_GetPioneer_v(b) + " " + csharp_GetPioneer_Oalpha(b) + " " + csharp_GetPioneer_Obeta(b) + " " + csharp_GetPioneer_Ogamma(b) );
                //Console.WriteLine(csharp_GetPingTime(b));
            }
            
        }
    }
}

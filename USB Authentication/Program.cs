using System;
using System.Linq;
using System.Management;
using System.Threading;

namespace USB_Authentication
{
    class Program
    {
        private static string _correctHash = @"0KaAzt8SEPe2Cxha5RBqrpdOLvuPoGc9n66x5pOmrG7MyXUfCkhHhf7lGQq0bL0trhTdZMewxWwbMxM+aTdCug==";
        static void Main(string[] args)
        {
            Console.Title = "Secure USB Authentication";

            while (true)
            {
                Console.Clear();

                if (USBDevice.GetUSBDevices().Any(x => x.ToString() == _correctHash))
                    break;
                
                Console.WriteLine("Awaiting Authentication USB Device...");                    
                Thread.Sleep(1000);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Successfully Authenticated...");
            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Nuclear
    {
        public delegate void DelAlertMessage();
        public DelAlertMessage AlertMessages;

        public void StartCountDown()
        {
            Console.WriteLine("Nuclear will be launched in 10 seconds.");
        }

        public void CountingSeconds()
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine(i);
            }
        }

        public void NuclearLaunchDetected()
        {
            Console.WriteLine("Nuclear launch detected.");
        }

        public void LaunchNuclearMissile()
        {
            AlertMessages();
        }
    }
}

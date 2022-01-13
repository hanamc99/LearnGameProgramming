using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Scv
    {
        public delegate void DelTest(int i);

        public Scv()
        {

        }

        public void Gather(DelTest DelegateMethod)
        {
            DelegateMethod(5);
        }
    }
}

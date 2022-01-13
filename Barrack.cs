using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Barrack
    {
        public delegate Marine DelCreateSoldierUnit(string name);

        public Marine CreateSoldierUnit(DelCreateSoldierUnit callback, string unitName)
        {
            return callback(unitName);
        }

        public Marine CreateMarine(string name)
        {
            return new Marine(name);
        }
    }
}

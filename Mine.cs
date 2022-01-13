using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Mine
    {
        private int damage;
        public Position pos;

        public Mine()
        {
            this.damage = 2;
        }

        public void MineInstalled(Position posi)
        {
            this.pos = posi;
            Console.WriteLine("({0}, {1}) 좌표에 마인 설치 완료.", this.pos.x, this.pos.y);
        }

        public int Explode()
        {
            Console.WriteLine("마인이 폭발합니다!");
            return this.damage;
        }
    }
}

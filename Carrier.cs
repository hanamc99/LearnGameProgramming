using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class Carrier : Unit
    {
        public Interceptor[] interceptorRoom;
        private int hp;

        public Carrier(string name) : base(name)
        {
            this.unitType = eUnitType.Carrier;
            this.hp = 10;
            this.interceptorRoom = new Interceptor[8];
        }

        public Unit BuildInterceptor()
        {
            int index;
            for (index = 0; index < interceptorRoom.Length; index++)
            {
                if (interceptorRoom[index] == null)
                {
                    break;
                }
            }
            if (index == interceptorRoom.Length)
            {
                Console.WriteLine("수용량 초과!");
                return null;
            }
            interceptorRoom[index] = new Interceptor(index + 1 + "번째");
            
            Console.WriteLine("{0}, {1} Build Complete.", interceptorRoom[index].unitType, interceptorRoom[index].Name);
            return interceptorRoom[index];
        }

        public override void Attack(Unit attacker, ref Unit target, string weapon)
        {
            Console.WriteLine("{0}, {1}에게 공격 명령.", this.Name, target.Name);
            foreach(Interceptor itct in interceptorRoom)
            {
                if(itct != null)
                {
                    itct.Attack(itct, ref target, "z");
                }
            }
        }

        public override Unit Hit(Unit sender, int damage, int hp, string bloodColor, Unit target)
        {
            this.hp -= damage;
            base.Hit(sender, damage, this.hp, "z", target);
            if(this.hp > 0)
            {
                return this;
            }
            base.Destroy();
            DestroyInterceptors();
            return null;
        }

        public void DestroyInterceptors()
        {
            for(int i = 0; i < interceptorRoom.Length; i++)
            {
                interceptorRoom[i] = null;
            }
        }
    }
}

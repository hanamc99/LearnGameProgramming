using System;
using System.Collections.Generic;
using System.Text;

namespace helloworldConsoleApp1
{
    class App2
    {


        /*public Action action1;

        public App2()
        {

        }

        public void Clicked()
        {
            action1();
        }

        /*public Action action1;
        public Func<int> function1;

        public App2()
        {
            action1 = SayHello;
            action1();
            function1 = returnOne;
            Console.WriteLine(function1());
        }

        public int returnOne()
        {
            return 1;
        }

        public void SayHello()
        {
            Console.WriteLine("hi");
        }

        /*public delegate void Deleg(string m, ref int i);
        public int num = 1;

        public App2()
        {
            App class1 = new App();

            Deleg delme = class1.Method1;
            delme += class1.Method2;
            Deleg delme2 = this.DelegateMethod;

            Deleg del3 = delme + delme2;

            del3 -= DelegateMethod;
            del3("Asdf", ref num);
            Console.WriteLine(del3.GetInvocationList().GetLength(0));
            Console.WriteLine(num);
        }
        public void DelegateMethod(string m, ref int i)
        {
            Console.WriteLine(m);
            i++;
        }

        /*public delegate void DelHi();
        public App2()
        {
            DelHi Hi = SayHello;
            Hi();
        }

        public void SayHello()
        {
            Console.WriteLine("Hello World!");
        }
        /*public App2()
        {
            Scv scv = new Scv();
            scv.Gather(GatherMinerals);
        }

        public void GatherMinerals(int amount)
        {
            Console.WriteLine("{0}개의 미네랄을 수집했습니다.", amount);
        }*/
    }
}

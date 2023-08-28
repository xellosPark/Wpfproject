using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defProject.Class
{
    delegate void DelegateType(string Message);

    class A
    {
        public event DelegateType EventHandler;

        public void Func(string Message)
        {
            EventHandler(Message);
        }
    }

    class B
    {
        public void PrintA(string Message)
        {
            Console.WriteLine(Message);
        }
        public void PrintB(string Message)
        {
            Console.WriteLine(Message);
        }
    }
    class DelegateEvt
    {
        public DelegateEvt()
        {
            A Test1 = new A();
            B Test2 = new B();

            Test1.EventHandler += new DelegateType(Test2.PrintA);
            Test1.EventHandler += new DelegateType(Test2.PrintB);
            Test1.Func("Good!!!");
            Test1.EventHandler -= Test2.PrintB;
            Test1.Func("Hi~~!");
            Test1.EventHandler -= Test2.PrintA;

            Test1.EventHandler += Test2.PrintA;
            Test1.EventHandler += Test2.PrintB;

            Test1.Func("Hello World");

            // 출력값
            // Good!!!   
            // Good!!!

            // Hi~~!

            // Hello World
            // Hello World

        }
    }
}

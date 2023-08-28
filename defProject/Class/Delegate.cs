using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace defProject
{

 
    public class Delegate:MainWindow
    {
        delegate void MyDelegate();
        delegate int AddDelegate(int a, int b);
        delegate int MyDelegate2();
        delegate int CalDelegate(int a, int b);
        
        
        // 무명 메서드
        delegate void RunDelegate(int p);
        delegate int Expr(int a, int b);
        int num = 100;
        double aaa = 11.11;

        public Delegate()
        {
            MyDelegate myDelegate;
            myDelegate = FuncTest;
            myDelegate();

            AddDelegate addDelegate = Add;
            addDelegate(1, 2);
            var addOp = new CalDelegate(Add);
            Calc(6, 3, addOp);
            Calc(6, 3, Substract);

            // 무명 메서드
            RunDelegate r = delegate (int p) { MessageBox.Show(p.ToString()); };
            r(123);

            Expr expr = delegate (int a, int b)
            {
                return 2 * a + b;
            };
            int result = expr(1, 2);

        }

        void Calc(int a, int b, CalDelegate calc)
        {
            int res = calc.Invoke(a, b);
            Console.WriteLine("사용함수 : {0}", calc.Method);
            Console.WriteLine($"f({a},{b}) = {res}");
        }



        public void FuncTest()
        {
            ShowMenu(GetAge_Korea);
            ShowMenu(GetAge_Japan);
        }
//         public void FuncTest(int a, int b)
//         {
// 
//         }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Substract(int a, int b)
        {
            return a / b;
        }


        void ShowMenu(MyDelegate2 GetAge)
        {
            int age = GetAge();
            
            if (age >= 20)
            {
              
            }
            else
            {

            }
        }


        //         public void ShowMenu()
        //         {
        //             int age = GetAge_Korea();
        // 
        //            if ("Korea" == "Korea")
        //                 age = GetAge_Korea();
        //             else
        //                 age = GetAge_Japan();
        // 
        // 
        //             if(age >= 20)
        //             {
        // 
        //             }
        //             else
        //             {
        // 
        //             }
        //         }
        public void ShowMenu_Japan()
        {
            int age = GetAge_Japan();
            if (age >= 20)
            {

            }
            else
            {

            }
        }

        public int GetAge_Korea()
        {
            //DB에서 현재 고객의 생년월일을 가져온다.
            // 현재 일시 - 생년월일 빼준다. + 1

            return 0;
        }

        public int GetAge_Japan()
        {
            //DB에서 현재 고객의 생년월일을 가져온다.
            // 현재 일시 - 생년월일 빼준다. + 1

            return 0;
        }

       

    }



    public class A
    {
        public void PrintA()
        {
            Console.WriteLine("PrintA");
        }

        public void PrintB()
        {
            Console.WriteLine("PrintB");
        }
    }

    public class Program
    {

        public delegate void DelegateType();
        public A T1;
        DelegateType DelTpye;// = T1.PrintA;
        public Program()
        {
            T1 = new A();
            DelTpye = T1.PrintA;
            
            DelegateType DelFunc = T1.PrintA;
            DelFunc += T1.PrintB;
            DelFunc();
            DelFunc -= T1.PrintB;
            DelFunc();

            // 결과값
            // PrintA
            // PrintB
            // PrintA

        }

    }

    
}

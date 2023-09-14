using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defProject.LambadaEx
{
    class LambadaEx
    {
        delegate void MyDelegate(string Name, int age);

        delegate string Message(string message);
        public LambadaEx()
        {
            // 람다식 문법 : (입력 매개변수) => { 실행문장 로직 }
            MyDelegate student = (name, age) =>
            {
                Console.WriteLine("이름 : {0}, 나이 : {1}", name, age);
            };
            student("최범게", 27);

            Message message = (str) => { return str; };

            Console.WriteLine("이름 : {0}", message("최두호"));
        }
    }

    // 매개변수목록 => 식
    class LambadaEx1
    {
        delegate int Calc(int a, int b);
        delegate void DoSomething();
        delegate string Concat(string[] args);
        delegate void HelloFunc();
        public LambadaEx1()
        {
            // 두 개의 int를 입력받아 하나의 int를 반환하는 익명메소드
            Calc calc0 = (int a, int b) => a + b;
            Calc calc1 = (a, b) => a + b;
            Calc calc2 = delegate (int a, int b)
            {
                return a + b;
            };

            Console.WriteLine("{0}", calc0(3, 8));
            Console.WriteLine("{0}", calc1(2, 5));
            Console.WriteLine("{0}", calc2(4, 6));

            // 오류발생 델리게이트 변경해야 한다.
            //public void HelloFunc = () => Console.WriteLine("안녕하세요");

            HelloFunc Hello = () => Console.WriteLine("안녕하세요");

            DoSomething Test = () =>
            {
                Console.WriteLine("테스트1");
                Console.WriteLine("테스트2");
                Console.WriteLine("테스트3");
            };

            Test();

            Concat concat = (arr) =>
            {
                string result = string.Empty;
                foreach (string temp in arr)
                {
                    result += temp;
                }
                return result;
            };

//             List<int> nlist = new List<int> { 1, 2, 3, 4 };
//             string[] array = nlist.Select(x => x.ToString()).ToArray();

            List<string> list = new List<string> { "1", "2", "3", "4" };
            string[] args = list.ToArray();
            Console.WriteLine(concat(args));
        }
    }

    class LambadaExFunc
    {
        
        public LambadaExFunc()
        {
            //Func<out TResult>() return
            Func<int> test = () => 10;  // 입력 매개변수는 없고 10 반환
            Console.WriteLine(test);
            Func<int, int> test1 = (a) => a * 10;  // a를 입력받아 a*10 출력
            Console.WriteLine(test1(3));  // 30 출력
            Func<double, double, double> test2 = (a, b) => { return a / b; };
            Console.WriteLine(test2(22,7));  // 3.142857.. 출력

            //Action <in T > (T arg) void
            Action act1 = () => Console.WriteLine("act1");
            act1();  // act1 출력
            int result = 0;
            Action<int> act2 = (x) => result = x * x;  // Action 대리자는 반환을 하지 않으므로 따로 변수에 저장
            act2(3);
            Console.WriteLine(result);  // 9 출력

            Action<double, double> act3 = (a, b) =>
            {
                double pi = a / b;
                Console.WriteLine(pi);
            };
            act3(22.0, 7.0);  // 3.14... 출력
        }
    }

    class LambadaEx3
    {
        public LambadaEx3()
        {
            // 메소드를 비롯해 인덱서, 생성자, 종료자는 공통된 특징이 있습니다.모두 클래스의 멤버로서 본문이 중괄호로 이루어져 있다는 점입니다.
            // 이러한 멤버의 본문을 식 만으로 구현하는 것이 가능합니다. 구현 방법은 다음과 같습니다.
            // 멤버 => 식

            //public LambadaEx3() => Console.WriteLine("생성자");
            //~LambadaEx3() => Console.WriteLine("종료자");

           // List<string> list = new List<string>();
           // int Capacity => list.Capacity; // 읽기 전용 속성
           //string this[int index] => list[index];  // 읽기 전용 인덱서

        }
       // public void Add(string name) => list.Add(name);
        //public void Remove(string name) => list.Remove(name);

    }
}

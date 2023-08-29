using defProject.DelegateEx;
using defProject.FileManager;
using defProject.PartialManger;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace defProject
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

// 30개의 버튼을 추가합니다.
//             for (int i = 1; i <= 50; i++)
//             {
//                 Button button = new Button();
//                 button.Content = "버튼 " + i;
//                 button.Click += Button_Click;
//                 buttonPanel.Children.Add(button);
//             }

            //Button button = new Button();
            //button.Content = "버튼 " + 61;
            
            //button.Click += new System.EventHandler(함수 이름)
            //buttonPanel.Children.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
//             if (sender is Button clickedButton)
//             {
//                 //MessageBox.Show(clickedButton.Content + "이 클릭되었습니다.");
//                 int buttonNumber = int.Parse(clickedButton.Content.ToString());
//                 switch (buttonNumber)
//                 {
//                     case 0:
//                         MessageBox.Show("버튼 0이 클릭되었습니다.");
//                         break;
//                     case 1:
//                         MessageBox.Show("버튼 1이 클릭되었습니다.");
//                         break;
//                     case 2:
//                         MessageBox.Show("버튼 2이 클릭되었습니다.");
//                         break;
//                 }
//             }
        }

        private void Delegate_Click(object sender, RoutedEventArgs e)
        {
            Delegate d = new Delegate();
            
        }

        private void DelegateEvt_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Dynamic_Click(object sender, RoutedEventArgs e)
        {
            dynamic a = "aaaa";

            var str =  a.GetType();
            MessageBox.Show(str.ToString());

            a = 123;
            str = a.GetType();
            MessageBox.Show(str.ToString());

            //Object vs dynamic
            object i = 10;
            i = (int)i + 20; //i = i + 20; 캐스팅 오류 발생 타입 오류
            MessageBox.Show(i.ToString());

            i = "Hello";
            string s = ((string)i).ToString(); //string s = i.ToString(); 캐스팅 오류 발생
            MessageBox.Show(s);
            // dynamic 컴파일시에 자료형을 결정한다. dynamic 인테리세스는 미지원 (어시스트 기능)
            dynamic d = 10;
            d = d + 20;
            d = "Hello";
            string ss = d.ToUpper();
            MessageBox.Show(ss);

            Class1 test = new Class1();
            //test.Test();
        }

        static void ExpandoTest()
        {
            dynamic person = new ExpandoObject();
            person.Name = "kim";
            person.Age = 10;

            person.DisplayData = (Action)(() =>
            {
                Console.WriteLine($"{person.Name}: {person.Age}");
            });
        }

        private void Event_Click(object sender, RoutedEventArgs e)
        {
            FileCopyDlg fileDlg = new FileCopyDlg();
            fileDlg.Show();
        }

        private void Partial_Click(object sender, RoutedEventArgs e)
        {
            PartiaDlg pdlg = new PartiaDlg();
            pdlg.Show();
        }

        private void DelegateUI_Click(object sender, RoutedEventArgs e)
        {
            DelDlg delDlg = new DelDlg();
            delDlg.Show();
        }
    }

    class Class1
    {
//         public void Test()
//         {
//             decimal t = new { Name = "kim", Age = 25 };
//             new Class2().Run(t);
//         }
    }

    class Class2
    {
        public void Run(dynamic t)
        {
            Console.WriteLine(t.Name);
            Console.WriteLine(t.Age);
        }

    }
}

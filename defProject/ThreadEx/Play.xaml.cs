using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace defProject.ThreadEx
{
    /// <summary>
    /// Play.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Play : Window
    {
        public delegate int delMessage(object sender, string strResult);  // delgate 선언
        public event delMessage eventdelMessage;

        private string strPlayerName = string.Empty;

        public string StrPlayerName { get => strPlayerName; set => strPlayerName = value; }

        Thread _thread = null;
        bool _bThreadStop = false;  // Thread Stop을 위한 Flag 생성

        public Play()
        {
            InitializeComponent();
        }
        public Play(string strPlayerName)   
        {
            InitializeComponent();

            lblPlayerName.Content = StrPlayerName = strPlayerName;

        }

        public void fThreadStart()
        {
            //_thread = new Thread(new ThreadStart(Run));   // ThreadStart 델리게이트 타입 객체를 생성 후 함수를 넘김

            _thread = new Thread(Run);   // 컴파일러에서 델리게이트 객체를 추론해서 생성 후 생성 후 함수를 넘김 (new ThreadStart 생략)

            //_thread = new Thread(delegate () { Run(); });   // 익명메소드를 사용하여 생성 후 함수를 넘김

            _thread.Start();
        }

        private void Run()
        {
            // UI Control이 자신이 만들어진 Thread가 아닌 다른 Thread에서 접근할 경우 Cross Thread가 발생
            //CheckForIllegalCrossThreadCalls = false;   // Thread 충돌에 대한 예외 처리를 무시 (Cross Thread 무시)
            try
            {
                int ivar = 0;
                Random rd = new Random();

                // UI 스레드에서 프로그래스바 값을 업데이트합니다.
                //Dispatcher.Invoke(() => proBar.Value = ivar);

                while ((Dispatcher.Invoke(() => proBar.Value)) < 100 && _bThreadStop == false)
                {
                    // UI 스레드 체크: 호출한 스레드가 작업 스레드인지 확인
                    if (Dispatcher.CheckAccess())
                    {
                        // UI 스레드인 경우
                        proBar.Value = ivar; // 이 부분은 e 변수에 대한 정보가 없어서 수정이 필요할 수 있습니다.
                        lblProcess.Content = $"{ivar} %";
                    }
                    else
                    {
                        // UI 스레드가 아닌 경우 Dispatcher.Invoke를 사용하여 UI 업데이트
                        Dispatcher.Invoke(() =>
                        {
                        // ivar 값 업데이트

                        ivar = rd.Next(1, 11);
                        //pbarPlayer.Value = ()
                        if (proBar.Value + ivar > 100)
                            {
                                proBar.Value = 100;
                            }
                            else
                            {
                                proBar.Value = proBar.Value + ivar;
                            }
                            lblProcess.Content = string.Format("진행 상황 표시 : {0}%", proBar.Value);
                        });
                    }
                    // 작업 스레드를 잠시 대기
                    Thread.Sleep(300);
                }

                if (_bThreadStop)
                {
                    eventdelMessage(this, "중도 포기...(Thread Stop)");
                }
                else
                {
                    eventdelMessage(this, "완주!! (Thread Complete)");
                }
            }

            catch (ThreadInterruptedException exInterrupt)  //ThreadInterrupt 발생되면 Thread join 상태 catch 걸림
            {
                exInterrupt.ToString();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void ThreadAbort()
        {
            if (_thread.IsAlive)   // Thread가 동작 중 일 경우  (Thread 실행중 확인)
            {
                _thread.Abort();  // Thred를 강제 종료
            }
        }

        public void ThreadJoin()
        {
            if (_thread.IsAlive)
            {
                bool bThreadEnd = _thread.Join(3000); //3초에 뒤에 쓰레드 종료확인 thread 사용중인경우 진행후 3초뒤에 또확인
            }
        }

        public void ThreadInterrupt()
        {
            if (_thread.IsAlive)
            {
                _thread.Interrupt();
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            //hreadInterrupt();
            if (_thread.IsAlive)
            {
                _bThreadStop = true;
            }
        }
    }
}

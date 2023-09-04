using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace defProject.ThreadEx
{
    /// <summary>
    /// ThreadDlg.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ThreadDlg : Window
    {
        public int initialValue { get; set; } = 0;

        private enum enumPlayer
        {
            아이린,
            슬기,
            웬디,
            조이,
            예리,
        }

        int _locationX = 0;
        int _locationY = 0;

        public ThreadDlg()
        {
            InitializeComponent();

            _locationX = (int)this.Left;
            _locationY = (int)this.Top;
        }

        private void numCout_Spin(object sender, Xceed.Wpf.Toolkit.SpinEventArgs e)
        {
            Xceed.Wpf.Toolkit.ButtonSpinner spinner = (Xceed.Wpf.Toolkit.ButtonSpinner)sender;
            string currentSpinValue = (string)spinner.Content;

            initialValue = String.IsNullOrEmpty(currentSpinValue) ? 0 : Convert.ToInt32(currentSpinValue);

            if (e.Direction == Xceed.Wpf.Toolkit.SpinDirection.Increase)
            { initialValue++; }
            else
            { initialValue--; }

            spinner.Content = initialValue.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _locationX = (int)this.Left + (int)this.Width;
            _locationY = (int)this.Top;

            string currentSpinValue = (string)numCout.Content;
            initialValue = String.IsNullOrEmpty(currentSpinValue) ? 0 : Convert.ToInt32(currentSpinValue);

            for (int i = 0; i < initialValue; i++)
            {
                Play pl = new Play(((enumPlayer)i).ToString());

                // 위치 설정
                pl.Left = _locationX;
                pl.Top = _locationY + pl.Height * i;

                // 이벤트 핸들러 등록
                pl.eventdelMessage += Pl_eventdelMessage;

                // 창을 표시
                pl.Show();

                // 작업 시작
                pl.fThreadStart();
            }
        }

        private int Pl_eventdelMessage(object sender, string strResult)
        {
            if (Dispatcher.CheckAccess())
            {
                // 현재 스레드가 UI 스레드인 경우
                Play oPlayerForm = sender as Play;
                lboxResult.Items.Add(string.Format("Player : {0}, Text : {1}", oPlayerForm.StrPlayerName, strResult));
            }
            else
            {
                // 다른 스레드에서 UI 업데이트를 수행해야 하는 경우
                Dispatcher.Invoke(() =>
                {
                    Play oPlayerForm = sender as Play;
                    lboxResult.Items.Add(string.Format("Player : {0}, Text : {1}", oPlayerForm.StrPlayerName, strResult));
                });
            }
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace defProject.FileManager
{
    /// <summary>
    /// FileCopyDlg.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FileCopyDlg : Window
    {
        public FileCopyDlg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(CopyFile);
            t.Start();
        }

        private void CopyFile()
        {
            FileCopy fm = new FileCopy();
            //가입
            fm.InProgress += Fm_InProgress;
            
            fm.Copy("src.mp4", "dest.mp4");
        }

//         private void Fm_InProgress1(object sender, double e)
//         {
//             Debug.WriteLine("Progress {0}", e);
//         }

        private void Fm_InProgress(object sender, double e)
        {
            // UI 스레드 체크: 호출한 쓰레드가 작업 쓰레드인지 확인
            if (Dispatcher.CheckAccess())
            {
                // UI 스레드인 경우
                this.proBar.Value = (int)e; 
                this.txet1.Text = $"{(int)e} %";
            }
            else
            {
                // UI 스레드가 아닌 경우
                Dispatcher.Invoke(new Action<object, double>(Fm_InProgress), sender, e);
            }
        }
    }
}

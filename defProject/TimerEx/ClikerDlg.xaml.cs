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
using System.Windows.Threading;

namespace defProject.TimerEx
{
    /// <summary>
    /// Cliker.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClikerDlg : Window
    {
        bool _bStart = false;
        DispatcherTimer _Timer = null;
        double _dNumber = 1;
        public ClikerDlg()
        {
            InitializeComponent();
            
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!_bStart)
            {
                _Timer = new DispatcherTimer();
                TimeSpan tsTime = new TimeSpan();
                tsTime = new TimeSpan(0, 0, 0, 0, 5);

                _Timer.Interval = tsTime;
                _Timer.Tick += _Timer_Tick;

                _Timer.Start();

                btnStart.Content = "Running";
                _bStart = true;
            }
            else
            {
                _Timer.Stop();
                _Timer = null;

                btnStart.Content = "Start";
                _bStart = false;
            }
        }

        private void _Timer_Tick(object sender, EventArgs e)
        {
            _dNumber = _dNumber * 2;
            //lblNumber.Content = _dNumber.ToString();
            if (double.IsInfinity(_dNumber))
            {
                return;
            }

            lblNumber.Content = string.Format("{0:n0}",_dNumber);
            lblNumberString.Content = fDoubleToStringNumber(_dNumber);
        }

        private string fDoubleToStringNumber(double dNumber)
        {
            string sResult = string.Empty;
            string sNumber = string.Empty;
            string sDlgit  = string.Empty;
            // Split('+') 승수만 찾기 
            string[] sNumberList = (dNumber.ToString()).Split('+');

            double dkeepNumber = 0;

            if (sNumberList.Length < 2)
            {

            }
            else
            {
                dkeepNumber = double.Parse(sNumberList[0].ToString().Replace("E","")) * 1000;
                string.Format("{0:n0}", dkeepNumber);
                
            }
            sResult = String.Format("{0}{1}", sNumber, "a");

            return sResult;
        }

        enum enumString
        {
            a, b, c, d, e, f, g, h, i, j,
        }


    }
}

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

namespace defProject.LinqEx
{
    /// <summary>
    /// LinqExDlg.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LinqExDlg : Window
    {
        public int initialValue { get; set; } = 0;
        public int initialValue2 { get; set; } = 0;


        enum EnumName
        {
            슬라임,가고일,골렘,코볼트,고블린,고스트,언데드,노움,드래곤,웜,서큐버스,데빌,만티코어,바실리스트,
        }
        enum EnumAttribute
        {
            불,물,바람,번개,어둠,빛,땅,나무,
        }


        public LinqExDlg()
        {
            InitializeComponent();
        }

        private void numCout_Spin1(object sender, Xceed.Wpf.Toolkit.SpinEventArgs e)
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

        private void numCout_Spin2(object sender, Xceed.Wpf.Toolkit.SpinEventArgs e)
        {
            Xceed.Wpf.Toolkit.ButtonSpinner spinner = (Xceed.Wpf.Toolkit.ButtonSpinner)sender;
            string currentSpinValue = (string)spinner.Content;

            initialValue2 = String.IsNullOrEmpty(currentSpinValue) ? 0 : Convert.ToInt32(currentSpinValue);

            if (e.Direction == Xceed.Wpf.Toolkit.SpinDirection.Increase)
            { initialValue2++; }
            else
            { initialValue2--; }

            spinner.Content = initialValue2.ToString();

        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            DataTableCreate(); // Data Table 생성
            EnemyCreate(); // 정보 생성
        }

        private void EnemyCreate()
        {
            
        }

        private void DataTableCreate()
        {

        }
    }
}

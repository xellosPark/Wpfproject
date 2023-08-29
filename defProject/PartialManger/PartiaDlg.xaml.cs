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


namespace defProject.PartialManger
{
    /// <summary>
    /// PartiaDlg.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PartiaDlg : Window
    {
        cData _Data = new cData();
        public int initialValue { get; set; } = 0;
        public PartiaDlg()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //Enum 형태를 배열로 변경
            EnumItem[] ei = (EnumItem[])Enum.GetValues(typeof(EnumItem));

            foreach (var item in ei)
            {
                combo1.Items.Add(item.ToString());
            }

            foreach (EnumRate item2 in (EnumRate[])Enum.GetValues(typeof(EnumRate)))
            {
                combo2.Items.Add(item2.ToString());
                
            }

            
            string currentSpinValue = (string)numCout.Content;
            initialValue = String.IsNullOrEmpty(currentSpinValue) ? 0 : Convert.ToInt32(currentSpinValue);

        }

        private void Btn_Close(object sender, RoutedEventArgs e)
        {
            _Data.fDataResult();

            if (combo1.Text != null)
            {
                _Data.StrItem = combo1.Text;
            }
            else
            {
                MessageBox.Show("물건을 선택을 내용이 없습니다.");
            }
            //Enum사용시 Parse 문자열 -> 숫자 형식으로 변환
            _Data.IRate = (int)Enum.Parse(typeof(EnumRate), combo2.Text);
            //_Data.IRate = int.Parse(combo2.Text);
            _Data.ICount = (int)initialValue;

           
            if (!String.IsNullOrEmpty(_Data.StrErrorName))
            {
                tboxErrorMsg.Foreground = Brushes.Red;
                tboxErrorMsg.Text = _Data.StrErrorName;
            }

            double dPrice = _Data.fItemPrice();
            iboxitem.Items.Add(_Data.fResult(dPrice));

            _Data.DTotalPrice = dPrice;
            tboxResult.Text = _Data.DTotalPrice.ToString() + "원";
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
    }
}

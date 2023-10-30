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

namespace defProject.ExceptionEx
{
    /// <summary>
    /// defExceptionExDlg.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class defExceptionExDlg : Window
    {
        public defExceptionExDlg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //FormatException
                //int iCheck = int.Parse(testBox1.Text);
                int iCheck = 0;
                if (int.TryParse(testBox1.Text, out iCheck))
                {
                    int.Parse(testBox1.Text);
                }
                else
                {
                    label1.Content = "Data Form이 맞지 않습니다.";
                }

                // ArgumentException 
                string strTest = string.Empty;
                List<string> LStringCheck = new List<string>();
                LStringCheck.Add("Test1");

//                 for (int i = 0; i < 2; i++)
//                 {
//                     strTest = LStringCheck[i];
//                 }

                foreach (string outrText in LStringCheck)
                {
                    strTest = outrText;
                }

                //NullReferenceException
                List<object> LObject = null;

                if (LObject != null)
                {
                    object oRet = LObject[0];
                }

                //InvalidCastException
                object oCheck = "fgdfg";
                //int iCastCheck = (int)oCheck;

                if(oCheck is int)
                {
                    int iCastCheck = (int)oCheck;
                }



            }
            catch (FormatException ex)
            {
                label1.Content = ex.ToString();
            }
            catch (ArgumentException ex)
            {
                label1.Content = ex.ToString();
            }
            catch (NullReferenceException ex)
            {
                label1.Content = ex.ToString();
            }
            catch (InvalidCastException ex)
            {
                label1.Content = ex.ToString();
            }
            // 위에 조건이 안 걸림경우에 SystemException ex 이동
            catch (SystemException ex)
            {
                label1.Content = ex.ToString();
            }
            // 모든 오류를 감시한다.맨 마지막에 설정 (부모임)
            catch (Exception ex)
            {
                label1.Content = ex.ToString();
            }
            finally
            {
                label1.Content = "함수를 완료하기 전 실행";
            }
        }
    }
}

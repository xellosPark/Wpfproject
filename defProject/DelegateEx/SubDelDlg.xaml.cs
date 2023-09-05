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

namespace defProject.DelegateEx
{
    /// <summary>
    /// SubDelDlg.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SubDelDlg : Window
    {
        public delegate int delPizzaComplete(string strResult, int iTime);
        public event delPizzaComplete eventdelPizzaComplete; // event 선언

        private bool bOrderComplete = false;  // 제작이 완료 됬는지 확인 하는 Flag (부모 Form에서 timer로 체크할때 사용)
        // 캡슐화
        public bool BOrderComplete { get => bOrderComplete; set => bOrderComplete = value; }

        //public event EventHandler
        public SubDelDlg()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        internal void fPizzrCheck(Dictionary<string, int> dPizzaOrder)
        {
            BOrderComplete = false;

            int iTotalTime = 0;
//             foreach (KeyValuePair<string, int> oOrder in dPizzaOrder)
//             {
//                 int iNowTime = 0;
//                 string strType = string.Empty;
//                 int iTime = 0;
//                 int iCount = oOrder.Value;
// 
//                 switch (oOrder.Key)
//                 {
//                     // 도우
//                     case "오리지널":
//                         iNowTime = 3000;
//                         strType = "도우";
//                         break;
//                     case "씬":
//                         iNowTime = 3500;
//                         strType = "도우";
//                         break;
// 
//                     // 엣지
//                     case "리치골드":
//                         iNowTime = 500;
//                         strType = "엣지";
//                         break;
//                     case "치즈크러스터":
//                         iNowTime = 400;
//                         strType = "엣지";
//                         break;
// 
//                     // 토핑
//                     case "소세지":
//                         iNowTime = 32;
//                         strType = "토핑";
//                         break;
//                     case "감자":
//                         iNowTime = 17;
//                         strType = "토핑";
//                         break;
//                     case "치즈":
//                         iNowTime = 48;
//                         strType = "토핑";
//                         break;
// 
//                     default:
//                         break;
//                 }
// 
//                 iTime = iNowTime * iCount;
// 
//                 iTotalTime = iTotalTime + iTime;
// 
//                 lboxMake.Items.Add(string.Format("{0}) {1} : {2}초 ({3}초, {4}개)", strType, oOrder.Key, iTime, iNowTime, iCount));


            int iNowTime = 0;
            string strType = string.Empty;
            int iTime = 0;
            //int iCount = oOrder.Value;
            int iCount = 0;
            //Dispatcher.Invoke(() => oOrder.Value = iCount);

            foreach (KeyValuePair<string, int> oOrder in dPizzaOrder)
            {
                // UI 스레드 체크: 호출한 스레드가 작업 스레드인지 확인
                if (Dispatcher.CheckAccess())
                {
                    // UI 스레드인 경우
                    iNowTime = 0;
                    strType = string.Empty;
                    iTime = 0;
                    iCount = oOrder.Value;
                }
                else
                {
                    // UI 스레드가 아닌 경우 Dispatcher.Invoke를 사용하여 UI 업데이트
                    Dispatcher.Invoke(() =>
                    {
                        switch (oOrder.Key)
                        {
                            // 도우
                            case "오리지널":
                                iNowTime = 3000;
                                strType = "도우";
                                break;
                            case "씬":
                                iNowTime = 3500;
                                strType = "도우";
                                break;

                            // 엣지
                            case "리치골드":
                                iNowTime = 500;
                                strType = "엣지";
                                break;
                            case "치즈크러스터":
                                iNowTime = 400;
                                strType = "엣지";
                                break;

                            // 토핑
                            case "소세지":
                                iNowTime = 32;
                                strType = "토핑";
                                break;
                            case "감자":
                                iNowTime = 17;
                                strType = "토핑";
                                break;
                            case "치즈":
                                iNowTime = 48;
                                strType = "토핑";
                                break;

                            default:
                                break;
                        }

                        iTime = iNowTime * iCount;

                        iTotalTime = iTotalTime + iTime;

                        lboxMake.Items.Add(string.Format("{0}) {1} : {2}초 ({3}초, {4}개)", strType, oOrder.Key, iTime, iNowTime, iCount));
                    });

                    Thread.Sleep(1000);
                }
                // 작업 스레드를 잠시 대기
                
            }

                //Refresh();
                //Thread.Sleep(1000);
            //}

            int iRet = eventdelPizzaComplete("Pizza가 완성 되었습니다.", iTotalTime);

            BOrderComplete = true;

            lboxMake.Items.Add("-------------------");

            if (iRet == 0)
            {
                lboxMake.Items.Add("주문 완료 확인!!");
            }
            else
            {
                lboxMake.Items.Add("제작 시간 초과로 고객 반품!!!");
            }
        }
    }
}

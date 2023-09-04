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

namespace defProject.DelegateEx
{
    /// <summary>
    /// DelDlg.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DelDlg : Window
    {
        public delegate int delFuncDow_Edge(int i);
        public delegate int delFuncTopping(string strOrder, int Ea);

 

        int _iTotalPrice = 0;
        public int initialValue { get; set; } = 0;

        SubDelDlg Sundlg { get; set; } = null;
        public DelDlg()
        {
            InitializeComponent();
         
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            delFuncDow_Edge delDow = new delFuncDow_Edge(fDow);
            delFuncDow_Edge delEdge = new delFuncDow_Edge(fEdge);

            delFuncTopping delTopping = null;

            Dictionary<string, int> dPizzaOrder = new Dictionary<string, int>(); // 주문을 담을 오더 (Key : 주문 종류, value : 개수)

            int iDowOrder = 0;
            int iEdgeOrder = 0;

            // 선택 도우 확인
            if (rdoDow1.IsChecked == true)
            {
                iDowOrder = 1;
                dPizzaOrder.Add("오리지널", 1);
                //delDow(1);
                //fDow(1);
            }
            else if (rdoDow2.IsChecked == true)
            {
                iDowOrder = 2;
                dPizzaOrder.Add("씬", 1);
                //delDow(2);
                //fDow(2);
            }

            //delDow(iDowOrder);

            string currentSpinValue = (string)numCout.Content;
            initialValue = String.IsNullOrEmpty(currentSpinValue) ? 0 : Convert.ToInt32(currentSpinValue);

            // 선택 엣지 확인
            if (rdoEdge1.IsChecked == true)
            {
                iEdgeOrder = 1;
                dPizzaOrder.Add("리치골드", 1);
            }
            else if (rdoEdge2.IsChecked == true)
            {
                iEdgeOrder = 2;
                dPizzaOrder.Add("치즈크러스터", 1);
            }

            //delEdge(iEdgeOrder);

            fCallBackDelegate(iDowOrder, delDow);
            fCallBackDelegate(iEdgeOrder, delEdge);

            // 토핑 선택 확인
            if (cboxTopping1.IsChecked == true)
            {
                //delTopping = new delFuncTopping(fTopping1);
                delTopping += fTopping1;
                dPizzaOrder.Add("소세지", (int)initialValue);
            }

            if (cboxTopping2.IsChecked == true)
            {
                delTopping += fTopping2;
                dPizzaOrder.Add("감자", (int)initialValue);
            }
                
            if (cboxTopping3.IsChecked == true)
            {
                delTopping += fTopping3;
                dPizzaOrder.Add("치즈", (int)initialValue);
            }
                

            if(cboxTopping1.IsChecked == false && cboxTopping2.IsChecked == false && cboxTopping3.IsChecked == false)
            {
                flboxOrderRed("토핑을 선택해주세요!");
                return;
            }
            delTopping("토핑", (int)initialValue);

            flboxOrderRed("----------------------------------");
            flboxOrderRed(string.Format("전체 주문 가격은 {0}원 입니다.", _iTotalPrice));

            SubLoadling(dPizzaOrder);
        }



        #region Function
        /// <summary>
        /// 0: 선택 안함 1: 오리지널 2 : 씬
        /// </summary>
        /// <param name="iOrder"></param>
        /// <returns></returns>
        private int fDow(int iOrder)
        {
            string strOrder = string.Empty;
            int iPrice = 0;

            if (iOrder == 1)
            {
                iPrice = 10000;
                strOrder = string.Format("도우는 오리지널을 선택 하셨습니다. ({0}원)", iPrice.ToString());
            }
            else if (iOrder == 2)
            {
                iPrice = 11000;
                strOrder = string.Format("도우는 씬을 선택 하셨습니다. ({0}원)", iPrice.ToString());
            }
            else
            {
                strOrder = "도우를 선택하지 않았습니다.";
            }

            flboxOrderRed(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        /// <summary>
        /// O : 선택안함, 1 : 리치골드, 2 : 치즈크러스터
        /// </summary>
        /// <param name="iOrder"></param>
        /// <returns></returns>
        private int fEdge(int iOrder)
        {
            string strOrder = string.Empty;
            int iPrice = 0;

            if (iOrder == 1)
            {
                iPrice = 1000;
                strOrder = string.Format("엣지는 리치골드를 선택 하셨습니다. ({0}원)", iPrice.ToString());
            }
            else if (iOrder == 2)
            {
                iPrice = 2000;
                strOrder = string.Format("엣지는 치즈크러스터를 선택 하셨습니다. ({0}원)", iPrice.ToString());
            }
            else
            {
                strOrder = "엣지는 선택하지 않았습니다.";
            }

            flboxOrderRed(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        public int fCallBackDelegate(int i, delFuncDow_Edge dFunction)
        {
            return dFunction(i);
        }

        private int fTopping1(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = iEa * 500;

            strOrder = string.Format("소세지 {0} {1} 개를 선택 하였습니다. : ({2}원 (1ea 500원))", Order, iEa, iPrice);

            flboxOrderRed(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        private int fTopping2(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = iEa * 200;

            strOrder = string.Format("감자 {0} {1} 개를 선택 하였습니다. : ({2}원 (1ea 200원))", Order, iEa, iPrice);

            flboxOrderRed(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        private int fTopping3(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = iEa * 300;

            strOrder = string.Format("치즈 {0} {1} 개를 선택 하였습니다. : ({2}원 (1ea 300원))", Order, iEa, iPrice);

            flboxOrderRed(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }


        private void flboxOrderRed(string strOrder)
        {
            lboxOrder.Items.Add(strOrder);
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

        #endregion

        #region event_예제
        private void SubLoadling(Dictionary<string, int> dPizzaOrder)
        {
            if (Sundlg != null)
            {
                Sundlg.Close();
                Sundlg = null;
            }

            Sundlg = new SubDelDlg();
            Sundlg.eventdelPizzaComplete += Sundlg_eventdelPizzaComplete;
            Sundlg.Show();

            Sundlg.fPizzrCheck(dPizzaOrder);
        }

        private int Sundlg_eventdelPizzaComplete(string strResult, int iTime)
        {
            flboxOrderRed("----------------------------------");
            flboxOrderRed(string.Format("{0} / 걸린 시간 : {1}", strResult, iTime));

            // 결과 값을 자식 form으로 return 해주기 위해 사용
            // 시간 계산을 해서 5분이 넘어 가면 -1
            if (iTime > 4000)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        #endregion

    }
}

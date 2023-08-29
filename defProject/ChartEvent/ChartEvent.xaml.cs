using System;
using System.Collections;
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

using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace defProject
{
    /// <summary>
    /// ChartEvent.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChartEvent : Window
    {
        LineSeries lineSeries;
        ChartEvt evt { get; set; }

        private ChartValues<ObservableValue> values1;
        public ChartValues<ObservableValue> Values1
        {
            get { return values1; }
            set { values1 = value; }
        }

        public ChartEvent()
        {
            InitializeComponent();
            evt = new ChartEvt();

            lineSeries = new LineSeries
            {
                Title = "Random Line Series",
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                PointGeometrySize = 5
            };

            Values1 = new ChartValues<ObservableValue>();

            Thread t = new Thread(Timer_Chart);
            t.Start();
        }

        private void Timer_Chart()
        {
            evt.InChart += Evt_InChart;
            evt.InputData();
        }

        private void Evt_InChart(object sender, int e)
        {
            if (Dispatcher.CheckAccess()) //코드가 객체를 사용할 수있는 스레드이면 true를 반환.
            {
                Values1.Add(new ObservableValue(e));
                lineSeries = new LineSeries
                {
                    Values = Values1,
                };

                chart.Series.Clear();
                // Add the LineSeries to the CartesianChart
                chart.Series.Add(lineSeries);
                //chart.Series[0] = lineSeries; //clear도 함께 진행되지만 선색이 자동으로 변경되어 이렇게는 사용 못할듯

                if (Values1.Count > 10)
                {
                    Values1.RemoveAt(0);
                }
            }
            else
            {
                Dispatcher.Invoke(new Action<object, int>(Evt_InChart), sender, e);
            }
        }
    }
}

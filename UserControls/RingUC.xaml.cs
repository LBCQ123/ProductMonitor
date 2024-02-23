using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// RingUC.xaml 的交互逻辑
    /// </summary>
    public partial class RingUC : UserControl
    {
        public RingUC()
        {
            InitializeComponent();
            SizeChanged += ReDrag;
        }


        /// <summary>
        /// 百分比
        /// </summary>




        public double Percent
        {
            get { return (double)GetValue(PercentProperty); }
            set { SetValue(PercentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Percent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PercentProperty =
            DependencyProperty.Register("Percent", typeof(double), 
                typeof(RingUC), new PropertyMetadata((double)0,PropertyChanged));

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is RingUC uc)
            {
                uc.Drag();
            }
        }

        private void ReDrag(object sender, SizeChangedEventArgs e)
        {
            Drag();
        }

        private void Drag()
        {
            //调整大小（正方形）
            double size = Math.Min(RenderSize.Width, RenderSize.Height);
            LayGrid.Height = size;
            LayGrid.Width = size;

            if (size == 0)
                return; 

            PathGeometry path = new PathGeometry();
            PathFigure figure = new PathFigure();

            double radius = 37;
            figure.StartPoint = new Point(50, 50- radius);

            
            double rr = -Math.PI / 2 + Percent % 100 /100.0 * 2 * Math.PI;
            double x = 50 + radius * Math.Cos(rr);
            double y = 50 + radius * Math.Sin(rr);

            if(Percent %100 == 0 && Percent >= 100) 
            {
                rr = - Math.PI / 2 + 99.9 % 100 / 100.0 * 2 * Math.PI;
                x = 50 + radius * Math.Cos(rr);
                y = 50 + radius * Math.Sin(rr);
                figure.Segments.Add(new ArcSegment(new Point(x, y), new Size(radius, radius), 0, Percent > 50, SweepDirection.Clockwise, true));
            }
            else
            {
                figure.Segments.Add(new ArcSegment(new Point(x, y), new Size(radius, radius), 0, Percent > 50, SweepDirection.Clockwise, true));
            }
            

            path.Figures.Add(figure);
            E3.Data = path;

            text.SetValue(Canvas.LeftProperty, 50 - text.ActualWidth / 2 - 10);
            text.SetValue(Canvas.TopProperty, 50 - text.ActualHeight / 2);

            //E3.Data
        }


    }
}

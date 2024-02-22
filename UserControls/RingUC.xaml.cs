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
            PTitle.Text = Percent.ToString();

            //调整大小（正方形）
            double size = Math.Min(RenderSize.Width, RenderSize.Height);
            LayGrid.Height = size;
            LayGrid.Width = size;

            if (size == 0)
                return; 

            E1.Width = size - 10;
            E1.Height = size - 10;
            E1.SetValue(Canvas.LeftProperty, 5.0);
            E1.SetValue(Canvas.TopProperty, 5.0);

            E2.Width = size - 20;
            E2.Height = size - 20;
            E2.SetValue(Canvas.LeftProperty, 10.0);
            E2.SetValue(Canvas.TopProperty, 10.0);

            PathGeometry path = new PathGeometry();

            PathFigure figure = new PathFigure();
            figure.StartPoint = new Point(50, 10);
            figure.Segments.Add(new LineSegment(new Point(50,5 + 10), false));

            figure.Segments.Add(new ArcSegment(new Point(80, 50), new Size(40, 40), 0, false, SweepDirection.Clockwise, false));
           
            figure.Segments.Add(new LineSegment(new Point(90, 50), false));
            figure.Segments.Add(new ArcSegment(new Point(50, 10), new Size(50, 50), 0, false, SweepDirection.Counterclockwise, false));


            path.Figures.Add(figure);
            E3.Data = path;

            //E3.Data
        }


    }
}

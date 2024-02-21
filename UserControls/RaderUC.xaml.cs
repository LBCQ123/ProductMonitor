using ProductMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// RaderUC.xaml 的交互逻辑
    /// </summary>
    public partial class RaderUC : UserControl
    {
        public RaderUC()
        {
            InitializeComponent();
            SizeChanged += RaderUC_SizeChanged;
            Drag();
        }

        /// <summary>
        /// 画面尺寸发生变动，重新画图
        /// </summary>
        private void RaderUC_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Drag();
        }


        /// <summary>
        /// 数据源支持绑定
        /// </summary>
        public List<RaderItemModel> ItemSource
        {
            get { return (List<RaderItemModel>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource",
                typeof(List<RaderItemModel>),
                typeof(RaderUC), 
                new PropertyMetadata(new List<RaderItemModel>() 
                {
                    new RaderItemModel("Item1",10),
                    new RaderItemModel("Item2",20),
                    new RaderItemModel("Item3",30),
                    new RaderItemModel("Item4",40),
                    new RaderItemModel("Item5",50),
                },PropertyChanged));

        /// <summary>
        /// 属性变更
        /// </summary>
        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is RaderUC rader)
            {
                rader.Drag();
            }
        }



        /// <summary>
        /// 绘制界面
        /// </summary>
        public void Drag()
        {
            //如果数据列表为空或者数据项为空
            if (ItemSource == null || ItemSource!.Count == 0)
            {
                return;
            }
            //清空画布
            mainCanvas.Children.Clear();
            P1.Points.Clear();
            P2.Points.Clear();
            P3.Points.Clear();
            P4.Points.Clear();
            P5.Points.Clear();
            
            //调整大小（正方形）
            double size= Math.Min(RenderSize.Width, RenderSize.Height);
            LayGrid.Height = size;
            LayGrid.Width = size;

            //半径
            double radius = size / 2;
            double step = 360.0 / ItemSource.Count;

            int count = ItemSource.Count;


            for(int i=0;i< count;i++)
            {
                double x = (radius - 30) * Math.Cos((step * i - 90) * Math.PI / 180);//x偏移量
                double y = (radius - 30) * Math.Sin((step * i - 90) * Math.PI / 180);//y偏移量

                //X Y坐标
                P1.Points.Add(new Point(radius + x, radius + y));
                P2.Points.Add(new Point(radius + x * 0.75, radius + y * 0.75));
                P3.Points.Add(new Point(radius + x * 0.5, radius + y * 0.5));
                P4.Points.Add(new Point(radius + x * 0.25, radius + y * 0.25));
                P5.Points.Add(new Point(radius + x * ItemSource[i].Value * 0.01, radius + y * ItemSource[i].Value * 0.01));

                //double angle = 2 * Math.PI / count * i + Math.PI / 2;
                //double x = radius + Math.Cos(angle) * (radius - 20);
                //double y = radius + Math.Sin(angle) * (radius - 20);
                //P1.Points.Add(new Point(x,y));

                //文字处理
                TextBlock txt = new TextBlock();
                txt.Width = 60;
                txt.FontSize = 10;
                txt.TextAlignment = TextAlignment.Center;
                txt.Text = ItemSource[i].ItemName;
                txt.Foreground = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                txt.SetValue(Canvas.LeftProperty, radius + (radius - 10) * Math.Cos((step * i - 90) * Math.PI / 180) - 30);//设置左边间距
                txt.SetValue(Canvas.TopProperty, radius + (radius - 10) * Math.Sin((step * i - 90) * Math.PI / 180) - 7);//设置上边间距

                mainCanvas.Children.Add(txt);

            }

            mainCanvas.Children.Add(P1);
            mainCanvas.Children.Add(P2);
            mainCanvas.Children.Add(P3);
            mainCanvas.Children.Add(P4);
            mainCanvas.Children.Add(P5);


        }


    }
}

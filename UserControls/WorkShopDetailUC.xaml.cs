using ProductMonitor.OpCommand;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// WorkShopDetail.xaml 的交互逻辑
    /// </summary>
    public partial class WorkShopDetailUC : UserControl
    {
        public WorkShopDetailUC()
        {
            InitializeComponent();
        }


        #region 打开详情
        private void ShowDetails()
        {
            detail.Visibility = Visibility.Visible;

            //动画效果
            //位移 移动时间
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0, 200, 0, -50),
                new Thickness(0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 400));

            //透明度
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(thicknessAnimation, detail);
            Storyboard.SetTarget(doubleAnimation, detail);

            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
        }

        public Command DetailShowCmd
        {
            get
            {
                return new Command(ShowDetails);
            }
        }
        #endregion

        #region 关闭详情
        private void HideDetails()
        {
            //动画效果
            //位移 移动时间
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0, 0, 0, 0),
                new Thickness(0, 50, 0, -50), new TimeSpan(0, 0, 0, 0, 400));

            //透明度
            DoubleAnimation doubleAnimation = new DoubleAnimation(1, 0, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(thicknessAnimation, detail);
            Storyboard.SetTarget(doubleAnimation, detail);

            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);

            storyboard.Completed += (_, __) =>
            {
                detail.Visibility = Visibility.Collapsed;
            };
            
            storyboard.Begin();
        }

        public Command DetailHideCmd
        {
            get
            {
                return new Command(HideDetails);
            }
        }
        #endregion
    }
}

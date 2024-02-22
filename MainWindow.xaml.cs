using ProductMonitor.OpCommand;
using ProductMonitor.UserControls;
using ProductMonitor.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowDetailUC()
        {
            if(this.DataContext is MainWindowVM model)
            {
                WorkShopDetailUC workShopDetail = new WorkShopDetailUC();
                model.MonitorUC = workShopDetail;

                //动画效果
                //位移 移动时间
                ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0,50,0,-50),
                    new Thickness(0,0,0,0),new TimeSpan(0,0,0,0,400));

                //透明度
                DoubleAnimation doubleAnimation = new DoubleAnimation(0,1,new TimeSpan(0,0,0,0,400));

                Storyboard.SetTarget(thicknessAnimation, workShopDetail);
                Storyboard.SetTarget(doubleAnimation, workShopDetail);

                Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(thicknessAnimation);
                storyboard.Children.Add(doubleAnimation);
                storyboard.Begin();
            }
        }

        public Command ShowDetailCmd {
            get
            {
                return new Command(ShowDetailUC);
            }
        }

        
        private void ShowMonitorUC()
        {
            if (this.DataContext is MainWindowVM model)
            {
                MonitorUC monitorUC = new MonitorUC();

                //UserControl org = model.MonitorUC;
                model.MonitorUC = monitorUC;

                //动画效果
                //位移 移动时间
                ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0, 50, 0, -50),
                    new Thickness(0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 400));

                //透明度
                DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

                Storyboard.SetTarget(thicknessAnimation, monitorUC);
                Storyboard.SetTarget(doubleAnimation, monitorUC);

                Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(thicknessAnimation);
                storyboard.Children.Add(doubleAnimation);
                storyboard.Begin();
            }
                
        }

        public Command GoBackCmd
        {
            get
            {
                return new Command(ShowMonitorUC);
            }
        }



    }
}

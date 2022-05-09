using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using VeterinariaExamen.Views;

namespace VeterinariaExamen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            t1 = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            t1.Tick += T1_Tick;
            t1.Start();
        }

        DispatcherTimer t1;

        private void T1_Tick(object sender, EventArgs e)
        {
            t1.Stop();
            Hide();
            MainView m = new MainView();
            m.ShowDialog();
            Close();
        }

         

      
    }
}

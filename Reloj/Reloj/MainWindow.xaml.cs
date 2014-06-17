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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Reloj
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            reloj_.Content = DateTime.Now.ToLongTimeString();//Doy la hora actual al reloj

            //Actualiza reloj
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();


            DateTime myDt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);//obtiene datos fecha/hora
            string dtString = myDt.ToString(@"M/d/yyyy");//formato a entregar
            fecha_.Content = dtString;//setea fecha
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            reloj_.Content = DateTime.Now.ToLongTimeString();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//posibilidad de mover la ventanita
        }

        private void opacity__ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Opacity = e.NewValue/10 > 0.1 ? e.NewValue/10  : 0.1;//Cambiar opacidad

        }
    }
}

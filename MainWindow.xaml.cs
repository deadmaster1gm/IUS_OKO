using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IUS_OKO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (ApplicationContext db = new ApplicationContext())
            {
                var parameters = db.ParameterOKO.Find(1);
                if (parameters.ParameterData)
                {
                    Rectangle EmergencyLevelOKO1 = (Rectangle)FindName("EmergencyLevelOKO1");
                    EmergencyLevelOKO1.Visibility = Visibility.Visible;
                }
                else
                {
                    Rectangle EmergencyLevelOKO1 = (Rectangle)FindName("EmergencyLevelOKO1");
                    EmergencyLevelOKO1.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}

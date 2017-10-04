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

namespace WpfIRadiusClient
{
    /// <summary>
    /// Lógica de interacción para Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        public SettingsManager sm;
        public Configuration()
        {
            InitializeComponent();
            sm = new SettingsManager();
            this.DataContext = sm;
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

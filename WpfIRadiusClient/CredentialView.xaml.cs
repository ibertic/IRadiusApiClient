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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfIRadiusClient
{
    /// <summary>
    /// Lógica de interacción para CredentialView.xaml
    /// </summary>
    public partial class CredentialView : UserControl
    {
        public CredentialView()
        {
            InitializeComponent();
        }

        public string UserName { get { return txtUser.Text; } set { txtUser.Text = value; } }
        public string Password { get { return txtPassword.Text; } set { txtPassword.Text = value; } }
    }
}

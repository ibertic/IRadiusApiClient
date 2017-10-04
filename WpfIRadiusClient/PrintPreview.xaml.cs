using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Media.Media3D;
using Ibertic.Iradius.Api.Client;

namespace WpfIRadiusClient
{
    /// <summary> 
    /// Interaction logic for Window1.xaml 
    /// </summary> 
    public partial class PrintPreview : Window
    {
        public PrintPreview()
        {
            InitializeComponent();

            //  string FileNames = "c:\\1.JPG";  
            ////  Image result = new Image(); 
            //  BitmapImage bitmapImage = new BitmapImage(new Uri(FileNames));//source of image   
            //  img.Width = 50; 

            //  img.Source = bitmapImage;  
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           

        }



        public void AddCredential(GenerateCredentialResult CredentialResult)
        {
            var cv = new CredentialView();
            cv.HorizontalAlignment = HorizontalAlignment.Left;
            cv.UserName = CredentialResult.UserName;
            cv.Password = CredentialResult.Password;
            container.Children.Add(cv);
        }

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(container, "Credential Printing");
            }

            this.Close();
        }
    }


}

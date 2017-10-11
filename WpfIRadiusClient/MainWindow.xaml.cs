using Ibertic.Iradius.Api.Client;
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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApiClient ApiClient;
        public List<AvailableCustomers> Customers;
        public WpfIRadiusClient.SettingsManager sm;
        bool Loading = false;

        public MainWindow()
        {
            InitializeComponent();
            sm = new SettingsManager();
        }
        
        #region Métodos
        private void IniLoad()
        {
            Loading = true;
            try
            {
                ApiClient = new ApiClient(sm.ApiUrl, sm.Token);
                Customers = ApiClient.GetCustomers();
                SetCbxDataSource<AvailableCustomers>(cbxCustomers, Customers);

                var Cid = sm.CustomerId;
                var c = (from C in Customers where C.Id == Cid.ToString() select C).SingleOrDefault();
                if (c != null)
                    cbxCustomers.SelectedValue = Cid;

                OnSelectedCustomerChanged();

                var hts = (HotspotList)cbxHotspots.DataContext;
                var hid = sm.HotspotId;
                var h = (from H in hts.Elements where H.Id == hid select H).SingleOrDefault();
                if (h != null)
                    cbxHotspots.SelectedValue = hid;


                var tts = (WpfIRadiusClient.AdvancedTypesList)cbxTypes.DataContext;
                var tid = sm.TypeId;
                var t = (from T in tts.Elements where T.TypeId == tid select T).SingleOrDefault();
                if (t != null)
                    cbxTypes.SelectedValue = tid;


                if (cbxTypes.SelectedIndex >= 0)
                    OnSelectedTypeChanged();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
            finally
            {
                Loading = false;

            }
        }

        private void OnSelectedCustomerChanged()
        {
            var i = (AvailableCustomers)cbxCustomers.SelectedItem;
            var H = ApiClient.GetHotspots(int.Parse(i.Id));
            SetCbxDataSource<HotspotType>(cbxHotspots, H);

            //var T = ApiClient.GetTypes(int.Parse(i.Id));
            //SetCbxDataSource<CredentialType>(cbxTypes, T);
            var T = ApiClient.GetAdvancedTypes(int.Parse(i.Id));
            SetCbxDataSource<InputCredentialType>(cbxTypes, T);


            //var p = new CredentialInput();
            //p.TypeId = at[0].TypeId;
            //p.HotSpotId = 



            sm.CustomerId = int.Parse(i.Id);
        }

        private void OnSelectedHotspotChanged()
        {
            var i = (HotspotType)cbxHotspots.SelectedItem;
            if (i != null)
                sm.HotspotId = i.Id;
        }

        private void OnSelectedTypeChanged()
        {
            var i = (CredentialType)cbxTypes.SelectedItem;
            if (i != null)
                sm.TypeId = i.TypeId;
            var al = (InputAttributesList)grdAttributes.DataContext;

            if (i is InputCredentialType ict)
            {
                var att = ict.Attributes;
                var l = (from a in att select a.Value).ToList();
                al.Elements = l;
            }
            else
                al.Elements = null;

        }

        private void SetCbxDataSource<T>(ComboBox cbx, System.Collections.Generic.List<T> Elements)
        {
            var lt = (ElementList<T>)cbx.DataContext;
            lt.Elements = Elements;
            if (lt.Elements.Count > 0)
                cbx.SelectedIndex = 0;
        }

        /// <summary>
        /// Metodo para generar varias credenciales agrupadas en un pedido sin personalizar los atributos
        /// </summary>
        private void GenerateCredentials()
        {
            int CustomerId = Convert.ToInt32(cbxCustomers.SelectedValue);
            int HotspotId = Convert.ToInt32(cbxHotspots.SelectedValue);
            int TypeId = Convert.ToInt32(cbxTypes.SelectedValue);
            int Quantity = Convert.ToInt32(txtQuantity.Value.Value);
            var r = ApiClient.GenerateCredentials(CustomerId, HotspotId, TypeId, Quantity);
            grdCredentials.DataContext = r;
            var p = new Printing();
            p.PrintCredential(r);
        }

        /// <summary>
        /// Método para generar una credencial con atributos personalizados
        /// </summary>
        private void GenerateSingleCredential()
        {
            int CustomerId = Convert.ToInt32(cbxCustomers.SelectedValue);
            int HotspotId = Convert.ToInt32(cbxHotspots.SelectedValue);
            int TypeId = Convert.ToInt32(cbxTypes.SelectedValue);
            int Quantity = Convert.ToInt32(txtQuantity.Value.Value);

            var p = new CredentialInput();
            p.CustomerId = CustomerId;
            p.HotSpotId = HotspotId;
            p.TypeId = TypeId;
            p.Field1 = "TEST";

            var al = (InputAttributesList)grdAttributes.DataContext;
            if (al!=null && al.Elements!= null)
                {
                p.InputAttributes = al.Elements;
            }

            try
            {
                var r = ApiClient.GenerateCredential(p);
                grdCredentials.DataContext = r;
                var print = new Printing();
                print.PrintCredential(r);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //throw;
            }
            
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Configuration c = new Configuration();
            c.Show();
        }

        private void cmdConf_Click(object sender, RoutedEventArgs e)
        {
            Configuration c = new Configuration();
            c.Closed += C_Closed;
            c.Show();
        }

        private void C_Closed(object sender, EventArgs e)
        {
            IniLoad();
        }

        private void cmdLoad_Click(object sender, RoutedEventArgs e)
        {
            IniLoad();
        }

        private void cbxCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Loading)
                return;
            OnSelectedCustomerChanged();
        }

        private void cbxHotspots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Loading)
                return;
            OnSelectedHotspotChanged();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IniLoad();
        }

        private void cbxTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Loading)
                return;
            OnSelectedTypeChanged();
        }

        private void cmdGenerate_Click(object sender, RoutedEventArgs e)
        {
            //GenerateCredentials();
            GenerateSingleCredential();
        }

        private void cmdConf_Copy_Click(object sender, RoutedEventArgs e)
        {
            var w = new PrintPreview();
            w.Show();

        }
    }
}

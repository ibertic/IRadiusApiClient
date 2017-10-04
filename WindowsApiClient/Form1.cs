using Ibertic.Iradius.Api.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Windows.Forms;

namespace WindowsApiClient
{
    public partial class Form1 : Form
    {

        string token = "Valid Token here";
        private const string baseurl = "http://api.iradius.es";
        private bool Loading = false;

        private ApiClient ApiClient;

        public Form1()
        {
            InitializeComponent();
            ApiClient = new ApiClient(baseurl, token);
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            LoadAvailableCustomers();
        }
        private void LoadAvailableCustomers()
        {
            List<AvailableCustomers> LC = ApiClient.GetCustomers();
            Loading = true;
            lstCustomers.DataSource = LC;
            Loading = false;
        }
        private void lstCustomers_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                int CustomerId;
                if (!int.TryParse(lstCustomers.SelectedValue.ToString(), out CustomerId))
                    return;

                LoadHotspots(CustomerId);
                LoadTypes(CustomerId);

                textBox1.Text = CustomerId.ToString();
            }
        }

        private void LoadHotspots(int CustomerId)
        {
            var p = new NameValueCollection() { { "CustomerId", CustomerId.ToString() } };
            List<HotspotType> r = null;
            try
            {
                r = ApiClient.GetHotspots(CustomerId);
                lstHotspots.ValueMember = "Id";
                lstHotspots.DisplayMember = "Description";
                lstHotspots.DataSource = r;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;

            }
        }

        private void LoadTypes(int CustomerId)
        {
            var p = new NameValueCollection() { { "CustomerId", CustomerId.ToString() } };
            List<CredentialType> r = null;
            try
            {
                r = ApiClient.GetTypes(CustomerId);
                lstTypes.ValueMember = "TypeId";
                lstTypes.DisplayMember = "Name";
                lstTypes.DataSource = r;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;

            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var parameters = new NameValueCollection();
            parameters.Add("Quantity", txtQuantity.Value.ToString());
            parameters.Add("TypeId", lstTypes.SelectedValue.ToString());
            parameters.Add("CustomerId", lstCustomers.SelectedValue.ToString());
            parameters.Add("HotSpotId", lstHotspots.SelectedValue.ToString());


            var r = ApiClient.GenerateCredentials( Convert.ToInt32(lstCustomers.SelectedValue), Convert.ToInt32( lstHotspots.SelectedValue), Convert.ToInt32(lstTypes.SelectedValue), Convert.ToInt32(txtQuantity.Value));
            Table.DataSource = r.CredentialsResults;
            textBox1.Text = "Orden generarada:" + r.OrderId.ToString();
        }
    }
}

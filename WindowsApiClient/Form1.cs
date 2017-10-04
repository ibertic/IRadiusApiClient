using Ibertic.Iradius.Api.Client;
using Newtonsoft.Json;
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

        string token = "A82C09C6-2A7F-43D7-B00E-F78B9EC3B6A0";
        private const string baseurl = "http://localhost:5162/"; //"http://localhost:5162/"; //"http://apiiradius.ibertictelecom.com";
        private bool Loading = false;

        private ApiClient ApiClient;
        


        public Form1()
        {
            InitializeComponent();
            ApiClient = new ApiClient(baseurl, token);
        }

        //private T PostAction<T>(string token, string Method, string ApiMethod, NameValueCollection parameters)
        //{
        //    return PostActionWC2<T>(token, Method, ApiMethod, parameters);
        //    //return PostActionWR<T>(token, Method, ApiMethod, parameters);
        //}

        //private T PostActionWC<T>(string token, string Method, string ApiMethod, NameValueCollection parameters)
        //{
        //    string url = baseurl + "/" + ApiMethod;
        //    NameValueCollection header = new NameValueCollection();
        //    header.Add("token", token);
        //    WebClient client = new WebClient();
        //    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        //    client.Headers.Add(header);
        //    string res = null;
        //    T r = default(T);
        //    try
        //    {
        //        var result = client.UploadValues(url, Method, parameters);

        //        res = Encoding.UTF8.GetString(result);
        //        r = Json.Decode<T>(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return r;
        //}


        //private T PostActionWC2<T>(string token, string Method, string ApiMethod, NameValueCollection parameters)
        //{
        //    string url = baseurl + "/" + ApiMethod;
        //    NameValueCollection header = new NameValueCollection();
        //    header.Add("token", token);
        //    WebClient client = new WebClient();
        //    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        //    client.Headers.Add(header);

        //    string postData = "";
        //    if (parameters != null)
        //    {
        //        string c = "?";
        //        foreach (string k in parameters.AllKeys)
        //        {
        //            postData += c + k + "=" + parameters[k];
        //            c = "&";
        //        }
        //    }

        //    url += postData;

        //    string res = null;
        //    T r = default(T);
        //    try
        //    {
        //        var result = client.UploadValues(url, Method, new NameValueCollection());
        //        res = Encoding.UTF8.GetString(result);
        //        //res = client.UploadString(url, Method, postData);
        //        r = Json.Decode<T>(res);

        //        //r = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(res);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return r;
        //}
        //private T PostActionWR<T>(string token, string Method, string ApiMethod, NameValueCollection parameters)
        //{
        //    string url = baseurl + "/" + ApiMethod;

        //    NameValueCollection header = new NameValueCollection();
        //    header.Add("token", token);

        //    var encoding = new UTF8Encoding();
        //    string postData = "";
        //    if (parameters != null)
        //    {
        //        string c = "";
        //        foreach (string k in parameters.AllKeys)
        //        {
        //            postData += c + k + "=" + parameters[k];
        //            c = "&";
        //        }
        //    }

        //    byte[] data = encoding.GetBytes(postData);


        //    var myRequest =
        //      (HttpWebRequest)WebRequest.Create(url);

        //    ((HttpWebRequest)myRequest).UserAgent = ".NET Framework Example Client";
        //    myRequest.Headers.Add(header);
        //    myRequest.Method = Method;
        //    myRequest.ContentType = "application/json";
        //    myRequest.ContentLength = data.Length;
        //    var newStream = myRequest.GetRequestStream();
        //    newStream.Write(data, 0, data.Length);
        //    newStream.Close();

        //    var response = myRequest.GetResponse();
        //    var responseStream = response.GetResponseStream();
        //    var responseReader = new StreamReader(responseStream);

        //    string res = null;
        //    T r = default(T);
        //    try
        //    {
        //        res = responseReader.ReadToEnd();
        //        r = Json.Decode<T>(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return r;
        //}

     

        //void test()
        //{

        //    string token = "A82C09C6-2A7F-43D7-B00E-F78B9EC3B6A0";
        //    string url = "http://apiiradius.ibertictelecom.com/api/v100/AvailableCustomers";

        //    NameValueCollection parameters = new NameValueCollection();
        //    parameters.Add("token", token);

        //    //parameters.Add("redirect_uri", "http://localhost:34962/Home/Auth");
        //    //parameters.Add("code", code);
        //    WebClient client = new WebClient();
        //    client.Headers.Add(parameters);


        //    string res = null;
        //    try
        //    {
        //        var result = client.UploadValues(url, "POST", new NameValueCollection());
        //        res = Encoding.ASCII.GetString(result);
        //        var j = Json.Decode(res);

        //        var l = JsonConvert.DeserializeObject(res);
        //        var r = Json.Decode<IList<AvailableCustomers>>(res);

        //        lstCustomers.ValueMember = "Id";
        //        lstCustomers.DisplayMember = "Name";
        //        Loading = true;
        //        lstCustomers.DataSource = r;
        //        foreach (var i in j)
        //        {
        //            //lstCustomers.Items.Add()
        //        }
        //        textBox1.Text = j;



        //    }
        //    catch (Exception ex)
        //    {

        //        res = ex.Message;// throw;


        //    }
        //    finally
        //    {
        //        Loading = false;
        //        //textBox1.Text = res;
        //    }
        //}

        //public class AvailableCustomers
        //{
        //    public string Id { get; set; }
        //    public string Name { get; set; }
        //}


        //public class HotspotType
        //{
        //    public int Id { get; set; }
        //    public string Description { get; set; }
        //    public object Attributes { get; set; }
        //}




        //public class CredentialType
        //{
        //    public int TypeId { get; set; }
        //    public int ConfId { get; set; }
        //    public string Name { get; set; }
        //    public string Description { get; set; }
        //    //public decimal Price { get; set; }
        //    //decimal Discount { get; set; }
        //    //int IdIVA { get; set; }
        //    //decimal PVP { get; set; }
        //    //int PerfilId { get; set; }
        //    //object Attributes { get; set; }

        //    //{"Attributes":null,"TypeId":146,"ConfId":23,"Name":"CUENTA FIJA","Description":"","Price":null,"Discount":0.000,"IdIVA":1,"PVP":null,"PerfilId":3}
        //}


        //public class GenerateCredentialsResult
        //{
        //    public bool HasErrors { get; set; }
        //    //Collection of string Errors
        //    public List<GenerateCredentialResult> CredentialsResults { get; set; }
        //    public int OrderId { get; set; }

        //}
        //public class GenerateCredentialResult
        //{
        //    public string UserName { get; set; }
        //    public  string Password { get; set; }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            //test();
            LoadAvailableCustomers();
        }
        private void LoadAvailableCustomers()
        {
            //List<AvailableCustomers> LC = PostAction<List<AvailableCustomers>>(token, "POST", "api/v100/AvailableCustomers", new NameValueCollection());

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
            //p.Add("CustomerId", CustomerId.ToString());
            List<HotspotType> r = null;
            try
            {
                r = ApiClient.GetHotspots(CustomerId);//  PostAction<List<HotspotType>>(token, "POST", "api/v100/AvailableHotspots", p);
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
                r = ApiClient.GetTypes(CustomerId);// PostAction<List<CredentialType>>(token, "POST", "api/v100/AvailableTypes", p);
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
            string action = "api/v100/GenerateCredentials";
            //string data= "{  "Quantity": 1,  "TypeId": 2,  "CustomerId": 3,  "HotSpotId": 4}"


            var parameters = new NameValueCollection();
            parameters.Add("Quantity", txtQuantity.Value.ToString());
            parameters.Add("TypeId", lstTypes.SelectedValue.ToString());
            parameters.Add("CustomerId", lstCustomers.SelectedValue.ToString());
            parameters.Add("HotSpotId", lstHotspots.SelectedValue.ToString());


            var r = ApiClient.GenerateCredentials( Convert.ToInt32(lstCustomers.SelectedValue), Convert.ToInt32( lstHotspots.SelectedValue), Convert.ToInt32(lstTypes.SelectedValue), Convert.ToInt32(txtQuantity.Value));
                //PostActionWC<GenerateCredentialsResult>(token, "POST", action, parameters);

            Table.DataSource = r.CredentialsResults;
            textBox1.Text = "Orden generarada:" + r.OrderId.ToString();


            



        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Ibertic.Iradius.Api.Client
{
    public class ApiClient
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ApiUrl"></param>
        /// <param name="Token"></param>
        public ApiClient(string ApiUrl, string Token)
        {
            this.ApiUrl = ApiUrl;
            this.Token = Token;
        }

        #region Propiedades y métodos privados


        private T PostAction<T>(string Method, string ApiMethod, NameValueCollection parameters)
        {
            if (parameters != null && parameters.Count > 1)
                return PostActionWC<T>(this.Token, Method, ApiMethod, parameters);
            else
                return PostActionWCQueryParams<T>(this.Token, Method, ApiMethod, parameters);
            //return PostActionWR<T>(token, Method, ApiMethod, parameters);
        }

        private T PostActionWC<T>(string token, string Method, string ApiMethod, NameValueCollection parameters)
        {
            string url = this.ApiUrl + "/" + ApiMethod;
            NameValueCollection header = new NameValueCollection();
            header.Add("token", token);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            client.Headers.Add(header);
            string res = null;
            T r = default(T);
            try
            {
                var result = client.UploadValues(url, Method, parameters);

                res = Encoding.UTF8.GetString(result);
                r = Json.Decode<T>(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }


        private T PostActionWCQueryParams<T>(string token, string Method, string ApiMethod, NameValueCollection parameters)
        {
            string url = this.ApiUrl + "/" + ApiMethod;
            NameValueCollection header = new NameValueCollection();
            header.Add("token", token);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            client.Headers.Add(header);

            string postData = "";
            if (parameters != null)
            {
                string c = "?";
                foreach (string k in parameters.AllKeys)
                {
                    postData += c + k + "=" + parameters[k];
                    c = "&";
                }
            }
            url += postData;
            string res = null;
            T r = default(T);
            try
            {
                var result = client.UploadValues(url, Method, new NameValueCollection());
                res = Encoding.UTF8.GetString(result);
                //res = client.UploadString(url, Method, postData);
                r = Json.Decode<T>(res);
                //r = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }
        private T PostActionWR<T>(string token, string Method, string ApiMethod, NameValueCollection parameters)
        {
            string url = this.ApiUrl + "/" + ApiMethod;
            NameValueCollection header = new NameValueCollection();
            header.Add("token", token);
            var encoding = new UTF8Encoding();
            string postData = "";
            if (parameters != null)
            {
                string c = "";
                foreach (string k in parameters.AllKeys)
                {
                    postData += c + k + "=" + parameters[k];
                    c = "&";
                }
            }

            byte[] data = encoding.GetBytes(postData);
            var myRequest =
              (HttpWebRequest)WebRequest.Create(url);

            ((HttpWebRequest)myRequest).UserAgent = ".Net Framework IRadius Api Client";
            myRequest.Headers.Add(header);
            myRequest.Method = Method;
            myRequest.ContentType = "application/json";
            myRequest.ContentLength = data.Length;
            var newStream = myRequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            var response = myRequest.GetResponse();
            var responseStream = response.GetResponseStream();
            var responseReader = new StreamReader(responseStream);

            string res = null;
            T r = default(T);
            try
            {
                res = responseReader.ReadToEnd();
                r = Json.Decode<T>(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }
        #endregion

        #region Propiedades y métodos públicos

        public string Token { get; internal set; }
        public string ApiUrl { get; internal set; }

        public List<AvailableCustomers> GetCustomers()
        {
            List<AvailableCustomers> LC = null;
            try
            {
              LC=  PostAction<List<AvailableCustomers>>("POST", "api/v100/AvailableCustomers", new NameValueCollection());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return LC;
        }

        public List<HotspotType> GetHotspots(int CustomerId)
        {
            var p = new NameValueCollection() { { "CustomerId", CustomerId.ToString() } };
            List<HotspotType> r = null;
            try
            {
                r = PostAction<List<HotspotType>>("POST", "api/v100/AvailableHotspots", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        public List<CredentialType> GetTypes(int CustomerId)
        {
            var p = new NameValueCollection() { { "CustomerId", CustomerId.ToString() } };
            List<CredentialType> r = null;
            try
            {
                r = PostAction<List<CredentialType>>("POST", "api/v100/AvailableTypes", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        public GenerateCredentialsResult GenerateCredentials(int CustomerId, int HotspotId, int TypeId, int Quantity)
        {
            string action = "api/v100/GenerateCredentials";
            var parameters = new NameValueCollection();
            parameters.Add("Quantity", Quantity.ToString());
            parameters.Add("TypeId", TypeId.ToString());
            parameters.Add("CustomerId", CustomerId.ToString());
            parameters.Add("HotSpotId", HotspotId.ToString());
            GenerateCredentialsResult r = null;
            try
            {
                r = PostAction<GenerateCredentialsResult>("POST", action, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }
        #endregion
    }
}

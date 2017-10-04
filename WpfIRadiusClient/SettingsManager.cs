using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfIRadiusClient
{
    public class SettingsManager
    {
        public SettingsManager()
        {

        }

        public string Token
        {
            get
            {
                return WpfIRadiusClient.Properties.Settings.Default.Token;
            }
            set
            {
                WpfIRadiusClient.Properties.Settings.Default.Token = value;
                WpfIRadiusClient.Properties.Settings.Default.Save();
            }
        }

        public string ApiUrl
        {
            get
            {
                return WpfIRadiusClient.Properties.Settings.Default.ApiUrl;
            }
            set
            {
                WpfIRadiusClient.Properties.Settings.Default.ApiUrl = value;
                WpfIRadiusClient.Properties.Settings.Default.Save();

            }
        }


        public int CustomerId
        {
            get
            {
                return WpfIRadiusClient.Properties.Settings.Default.CustomerId;
            }
            set
            {
                WpfIRadiusClient.Properties.Settings.Default.CustomerId= value;
                WpfIRadiusClient.Properties.Settings.Default.Save();
            }
        }
        public int HotspotId
        {
            get
            {
                return WpfIRadiusClient.Properties.Settings.Default.HotspotId;
            }
            set
            {
                WpfIRadiusClient.Properties.Settings.Default.HotspotId = value;
                WpfIRadiusClient.Properties.Settings.Default.Save();
            }
        }


        public int TypeId
        {
            get
            {
                return WpfIRadiusClient.Properties.Settings.Default.TypeId;
            }
            set
            {
                WpfIRadiusClient.Properties.Settings.Default.TypeId= value;
                WpfIRadiusClient.Properties.Settings.Default.Save();
            }
        }
    }
}

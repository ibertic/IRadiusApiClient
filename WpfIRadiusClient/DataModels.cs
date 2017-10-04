using Ibertic.Iradius.Api.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace WpfIRadiusClient
{
    class DataModels
    {
    }


    public class ElementList<T> : INotifyPropertyChanged
    {
        private List<T> _Elements { get; set; }
        public List<T> Elements
        {
            get { return _Elements; }
            set
            {
                _Elements = value;
                NotifyPropertyChanged("Elements");
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class HotspotList : ElementList<HotspotType>
    {
    }

    public class CustomersList : ElementList<AvailableCustomers>
    {

    }


    public class TypesList : ElementList<Ibertic.Iradius.Api.Client.CredentialType>
    {

    }

    /*
    public class CustomersList: INotifyPropertyChanged
    {
        private List<AvailableCustomers> _Customers { get; set; }
        public List<AvailableCustomers> Customers
        {
            get { return _Customers; }
            set
            {
                _Customers = value;
                NotifyPropertyChanged("Customers");
            }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    */
}

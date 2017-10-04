using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibertic.Iradius.Api.Client
{
    public class AvailableCustomers
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }


    public class HotspotType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public object Attributes { get; set; }
    }




    public class CredentialType
    {
        public int TypeId { get; set; }
        public int ConfId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public decimal Price { get; set; }
        //decimal Discount { get; set; }
        //int IdIVA { get; set; }
        //decimal PVP { get; set; }
        //int PerfilId { get; set; }
        //object Attributes { get; set; }

        //{"Attributes":null,"TypeId":146,"ConfId":23,"Name":"CUENTA FIJA","Description":"","Price":null,"Discount":0.000,"IdIVA":1,"PVP":null,"PerfilId":3}
    }


    public class GenerateCredentialsResult
    {
        public bool HasErrors { get; set; }
        //Collection of string Errors
        public List<GenerateCredentialResult> CredentialsResults { get; set; }
        public int OrderId { get; set; }

    }
    public class GenerateCredentialResult
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

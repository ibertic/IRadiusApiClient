using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

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
    }


    public class InputCredentialType : CredentialType
    {
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int IdIVA { get; set; }
        public decimal PVP { get; set; }
        public int PerfilId { get; set; }
        public Dictionary<object, InputCredentialAttribute> Attributes { get; set; }
    }

    public class CredentialInput
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Info { get; set; }
        public string Name { get; set; }
        public string CodPos { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public bool? IsMale { get; set; }
        public int CustomerId { get; set; }
        public int HotSpotId { get; set; }
        public int TypeId { get; set; }

        public List<InputCredentialAttribute> InputAttributes { get; set; }

        /// <summary>
        /// Devuelve Una colección de strings con los atributos de la credencial a generar
        /// </summary>
        /// <returns></returns>
        public NameValueCollection GetParameters()
        {
            var n = new NameValueCollection();
            var col = ClassToArray(this);
            foreach (var v in col)
            {
                if (v.Value != null)
                {
                    if (v.Value is IList)
                    {
                        int x = 0;
                        foreach (var o in (IEnumerable)v.Value)
                        {
                            var cList = ClassToArray(o);
                            foreach (var v2 in cList)
                            {
                                string val = v2.Value == null ? "" : v2.Value.ToString();
                                n.Add(string.Format("{0}[{1}].{2}", v.Key, x.ToString(), v2.Key), val);
                            }
                            x += 1;
                        }
                    }
                    else
                    {
                        string val = v.Value == null ? "" : v.Value.ToString();
                        n.Add(v.Key, val);
                    }

                }
            }
            return n;
        }

        /// <summary>
        /// Método para convertir un objeto en un diccionario con la propiedad como clave y su valor
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private Dictionary<string, object> ClassToArray(object obj)
        {
            return obj.GetType()
          .GetProperties(BindingFlags.Instance | BindingFlags.Public)
          .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj, null));
        }

    }





    public class InputCredentialAttribute
    {
        public int Id { get; set; }
        public string AttributeName { get; set; }
        public string Description { get; set; }
        public string StringValue { get; set; }
        public string NumericValue { get; set; }
        //":"","NumericValue":null,"Writable":true,"PerfilId":28,"FromPerfil":true,"Id":1002,"VendorId":9999,"AttributeId":1,"AttributeName":"DateIni","Description":"Fecha Inicio","IsNumeric":false,"Required":true}
    }

    public class GenerateCredentialsResult
    {
        public bool HasErrors { get; set; }
        //Collection of string Errors
        public List<GenerateCredentialResult> CredentialsResults { get; set; }
        public int? OrderId { get; set; }
    }

    public class GenerateCredentialResult
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


}

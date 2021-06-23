using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AirAstana.Models
{
    [DataContract]
    public class Person
    {
        [DataMember(Name ="Login")]
        public string Login { get; set; }

        [DataMember(Name = "Password")]
        public string Password { get; set; }

        [DataMember(Name = "Role")]
        public string Role { get; set; }
    }
}

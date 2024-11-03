using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CRM.Entity.Result
{
    public class Sonuc<T>
    {
        public T? Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public bool? Varmi { get; set; }

        public string Mesaj { get; set; }

        public HataBilgisi HataBilgisi { get; set; }
    }
}

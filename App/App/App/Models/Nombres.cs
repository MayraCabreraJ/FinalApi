using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App.Models
{
    public class Nombres
    {
        #region Atributos
        [JsonProperty(PropertyName = "studentId")]
        public int StudentId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "evaluation")]
         public int Evaluation { get; set; }
        #endregion

    }
}

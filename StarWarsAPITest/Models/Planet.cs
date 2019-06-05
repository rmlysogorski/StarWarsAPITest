using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsAPITest.Models
{
    public class Planet
    {
        public string Name { get; set; }

        public Planet(string APIText)
        {
            Name = JObject.Parse(APIText)["name"].ToString();
        }
    }
}
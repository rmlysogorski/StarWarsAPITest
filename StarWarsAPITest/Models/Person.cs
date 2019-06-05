using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsAPITest.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public string HomePlanet { get; set; }

        public Person(string APIText)
        {
            JObject data = JObject.Parse(APIText);
            Name = data["name"].ToString();
            Species = JObject.Parse(StarWarsDAL.GetData(data["species"][0].ToString()))["name"].ToString();
            Gender = data["gender"].ToString();
            HomePlanet = JObject.Parse(StarWarsDAL.GetData(data["homeworld"].ToString()))["name"].ToString();
        }
    }
}
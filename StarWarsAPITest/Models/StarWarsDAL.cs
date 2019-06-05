using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace StarWarsAPITest.Models
{
    public class StarWarsDAL
    {
        private static readonly string url = "https://swapi.co/api/";
        public static string GetData(string url)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if(response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                string dataString = data.ReadToEnd();
                data.Close();
                response.Close();
                return dataString;
            }

            response.Close();
            return null;

        }

        public static Person GetPerson(int i)
        {
            return new Person(GetData(url + "people/" + i.ToString() + "/"));
        }

        public static Planet GetPlanet(int i)
        {
            return new Planet(GetData(url + "planets/" + i.ToString() + "/"));
        }

    }
}
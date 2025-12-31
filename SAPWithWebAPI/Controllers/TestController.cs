using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace SAPWithWebAPI.Controllers
{
    public class TestController : ApiController
    {
        //Resource
        static List<string> Colors = new List<string>()     //Collection Initializer   
        {
            "Red","Green","Blue","Purple","Magenta"
        };

        //Get Request (SELECT operation will perform to get list of colors)
        public IEnumerable<string> Get()
        {
            return Colors;
        }

        //GET Request (SELECT operation will perform to get single color)
        public string Get(int id)
        {
            return Colors[id];
        }

        //POST Request (INSERT operation will perform to add color in colors list)
        public void Post([FromBody] string Color)
        {
            Colors.Add(Color);
        }

        //PUT Request (Update operation will perform, which update existing color value based on id and new color value provided)
        public void Put(int id,[FromBody] string Color)
        {
            Colors[id] = Color;
        }

        //DELETE Request (Delete operation will perform based on color index from the list of color)
        public void Delete(int id)
        {
            Colors.RemoveAt(id);
        }

        //DELETE Request (Delete operation will perform based on color name from the list of color)
        public void Delete([FromBody] string Color)
        {
            Colors.Remove(Color);
        }
    }
}

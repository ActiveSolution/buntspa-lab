using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Bunt.Web.Controllers
{
    [Route("api/bunt")]
    public class BuntController : Controller
    {
        [HttpGet]
        public IEnumerable<BuntladeStalle> List()
        {
            return new List<BuntladeStalle>
            {
                new BuntladeStalle
                {
                    Index = 0,
                    Adress = "Testgatan 3",
                    Typ = "Lämna",
                    BuntladeNummer = 0
                },
                new BuntladeStalle
                {
                    Index = 1,
                    Adress = "Testgatan 4",
                    Typ = "Hämta",
                    BuntladeNummer = 1
                }
            };
        }
    }

    public class BuntladeStalle
    {
        public int Index { get; set; }
        public string Adress { get; set; }
        public string Typ { get; set; }
        public int? BuntladeNummer { get; set; }
    }
}
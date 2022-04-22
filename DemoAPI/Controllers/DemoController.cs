using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoApp.Models;
using Microsoft.AspNetCore.Cors;

namespace DemoApp.Controllers
{
    [Route("api/Demo")]
    [ApiController]
    public class DemoController : ControllerBase
    {

        [HttpGet]
        public JsonResult Get()
        {
            List<DemoSell> lst = new List<DemoSell>();
            lst.Add(new DemoSell { date = Convert.ToDateTime("12/12/12"), fuelType = "Gas", price = Convert.ToDouble(10) });
            lst.Add(new DemoSell { date = Convert.ToDateTime("11/12/12"), fuelType = "Gas", price = Convert.ToDouble(10) });
            lst.Add(new DemoSell { date = Convert.ToDateTime("10/12/12"), fuelType = "Gas", price = Convert.ToDouble(10) });

            // return  lst.ToArray();
            return new JsonResult(lst);
        }

        [HttpPost]
        public JsonResult Post(DemoSell demoSell)
        {
            List<DemoSell> lst = new List<DemoSell>();
            demoSell.discountedPrice = discountedPrice(demoSell);
            lst.Add(demoSell);
            return new JsonResult(lst);

        }
        private double discountedPrice(DemoSell demoSell)
        {
            double price = 0;
            if (demoSell != null)
            {
                DayOfWeek day = demoSell.date.DayOfWeek;
                if ((day == DayOfWeek.Saturday) || (day == DayOfWeek.Sunday))
                {
                    price = demoSell.price - (demoSell.price * .1);
                }
                else
                {
                    price = demoSell.price;
                }
            }
            return price;
        }

    }
}

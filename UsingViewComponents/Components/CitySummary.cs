using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;

namespace UsingViewComponents.Components
{
    //option 1 - poco view component (limited funtionality)
    //option 2 - derive it from the Component class
    public class CitySummary : ViewComponent 
    {
        private ICityRepository repository;

        public CitySummary(ICityRepository repo) => repository = repo;

        public IViewComponentResult Invoke(bool showList)
        {
            if (showList)
            {
                return View("CityList", repository.Cities);
            }
            else
            {
                return View(new CityViewModel
                {
                    Cities = repository.Cities.Count(),
                    Population = repository.Cities.Sum(c => c.Population)
                });
            }

            ////filtering context data by using ViewComponent properties
            //string target = RouteData.Values["id"] as string;
            //var cities = repository.Cities
            //    .Where(city => target == null || string.Compare(city.Country, target, true) == 0);
            //return View(new CityViewModel
            //{
            //    Cities = cities.Count(),
            //    Population = cities.Sum(c => c.Population)
            //});


            ////returning a Trusted html fragment
            //return new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i></h3>"));





        }
    }
}

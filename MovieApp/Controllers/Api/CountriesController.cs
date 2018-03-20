using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieApp.Controllers.Api
{
    public class CountriesController : ApiController
    {
        private ApplicationDbContext _context;

        public CountriesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/countries
        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        // GET /api/countries/1
        public Country GetCountry(int id)
        {
            var country = _context.Countries.SingleOrDefault(c => c.Id == id);

            if (country == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return country;
        }
    }
}

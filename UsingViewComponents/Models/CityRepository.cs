﻿using System.Collections.Generic;


namespace UsingViewComponents.Models
{
    public interface ICityRepository
    {
        IEnumerable<City> Cities { get; }
        void AddCity (City newCity);
    }


    public class MemoryCityRepository : ICityRepository
    {
        private List<City> cities = new List<City> {
            new City {Name="London", Country="UK", Population=8593000},
            new City {Name="New York", Country="USA", Population=8409000},
            new City {Name="San Jose", Country="USA", Population=998537},
            new City {Name="Paris", Country="France", Population=2234000}
        };

        public IEnumerable<City> Cities => cities;

        public void AddCity(City newCity) => cities.Add(newCity);
    }
}

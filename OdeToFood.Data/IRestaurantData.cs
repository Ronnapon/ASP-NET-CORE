using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updateRestaurant);
        Restaurant Create(Restaurant createRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1 , Name = "ร้านคำโต", Location = "พระราม2", CuisineType = CuisineType.Indian},
                new Restaurant {Id = 2 , Name = "ร้านเสวย", Location = "อ่อนนุช", CuisineType = CuisineType.Indian},
                new Restaurant {Id = 3 , Name = "ร้านบาบีก้อน", Location = "เอกมัย", CuisineType = CuisineType.Indian}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name).ToList();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants.Where(p => string.IsNullOrEmpty(name) || p.Name.StartsWith(name)).OrderBy(p => p.Name).ToList();
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(p => p.Id == id);
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(p => p.Id == updateRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.CuisineType = updateRestaurant.CuisineType;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Create(Restaurant createRestaurant)
        {
            createRestaurant.Id = restaurants.Max(p => p.Id) + 1;
            restaurants.Add(createRestaurant);
            return createRestaurant;
        }
    }
}



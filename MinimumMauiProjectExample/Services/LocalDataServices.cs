using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using MinimumMauiProjectExample.Models;


namespace MinimumMauiProjectExample.Services
{
    class LocalDataServices
  {
        //All data will be here:
        //User
        //Items
        //Categories
        //This is not a database, just "Faking" the data
        //Later on, it will be replaced by data from the DataBase
        static public List<Category>? categories;
        static public List<Item>? items;

        static public void Init()
        {
            categories = new List<Category>();
            categories.Add(new Category() { Id = "1", Name = "Food", Description = "We all love food", Order = 30 });
            categories.Add(new Category() { Id = "2", Name = "Sport", Description = "Sport if good for health", Order = 40 });
            categories.Add(new Category() { Id = "3", Name = "Furniture", Description = "We all need furnitures", Order = 70 });
            categories.Add(new Category() { Id = "4", Name = "Electronic", Description = "Phones, Computer, bip bip", Order = 60 });
            categories.Add(new Category() { Id = "5", Name = "Clothes", Description = "Fashion", Order = 50 });
            categories.Add(new Category() { Id = "6", Name = "Israel", Description = "Gr8 country", Order = 10 });
            categories.Add(new Category() { Id = "7", Name = "USA", Description = "United State of America", Order = 20 });

            items = new List<Item>();
            items.Add(new Item() { Id = "1", Name = "Falafel", Description = "Best Street Food", Categories = new List<Category>() { categories[0], categories[5] } });
            items.Add(new Item() { Id = "2", Name = "Nike Running Shoes", Description = "Run fast", Categories = new List<Category>() { categories[1], categories[6] } });
            items.Add(new Item() { Id = "3", Name = "DryFit Shirt", Description = "Dry fast", Categories = new List<Category>() { categories[1], categories[4], categories[6] } });
            items.Add(new Item() { Id = "4", Name = "Tesla", Description = "Drive fast", Categories = new List<Category>() { categories[6] } });
            items.Add(new Item() { Id = "5", Name = "Tank Merkava III", Description = "Shoot fast", Categories = new List<Category>() { categories[5] } });
            items.Add(new Item() { Id = "6", Name = "Kitchen Table", Description = "Great Kitchen Table", Categories = new List<Category>() { categories[2] } });
            items.Add(new Item() { Id = "7", Name = "Pasta", Description = "Pasta Pesto", Categories = new List<Category>() { categories[0] } });
            items.Add(new Item() { Id = "8", Name = "Iphone 15", Description = "Iphone 14 - a bit better", Categories = new List<Category>() { categories[3], categories[6] } });
            items.Add(new Item() { Id = "9", Name = "Android Sumsung", Description = "Sumsung great for debugging Maui", Categories = new List<Category>() { categories[3], categories[6] } });
            items.Add(new Item() { Id = "10", Name = "Junior Bed", Description = "Shomrat Hazorea bed for kids", Categories = new List<Category>() { categories[2], categories[5] } });
        }


    
        public static async Task<bool> TryLogin(string userNameString, string passwordString)
          {
          if (userNameString == "haha@hoho.com" && passwordString == "123456")
            {
            return true;
            }
            return false;
          }
        public static async Task<List<Category>> GetCategoriesAsync()
        {
            return categories;
        }
        public static async Task<List<Category>> GetCategoriesByOrderAsync()
        {
            List<Category> newList = categories.OrderBy(ctgry => ctgry.Order).ToList();
            return categories;
        }
        public static async Task<List<Item>> GetAllItemsAsync()
        {
            return items;
        }
        public static async Task<List<Item>> GetAllItemsAccordingACategoryAsync(string categoryName)
        {
            List<Item> filteredItems = items.Where(itm => itm.Categories.Any(ctgry => ctgry.Name == categoryName)).ToList();
            return filteredItems;
        }
        public static async Task<bool> DeleteItemAsync(Item theItemToDelete)
        {
            if (items != null)
            {
                if (items.Contains(theItemToDelete))
                {
                    items.Remove(theItemToDelete);
                    await Task.CompletedTask; // To mimic asynchronous behavior
                    return true;
                }
            }
            return false;
        }
        public static async Task<bool> AddItemAsync(Item theItemToAdd)
        {
            Item newItem = new Item() { Id = theItemToAdd.Id, Name = theItemToAdd.Name, Description = theItemToAdd.Description, Categories = theItemToAdd.Categories };
            items!.Add(newItem);
            return true;
        }
    }
}

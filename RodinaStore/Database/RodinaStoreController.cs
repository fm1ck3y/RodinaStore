using RodinaStore.Model;
using System.Collections.Generic;
using System.Linq;


namespace RodinaStore.DateBase
{
    public class RodinaStoreController
    {
        RodinaStoreContext context = new RodinaStoreContext();

        private static RodinaStoreController _instance;

        public static RodinaStoreController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RodinaStoreController();

                return _instance;
            }
        }

        public List<Client> GetClients()
        {
            return context.Clients.ToList();
           
        }

        public void UpdateClient(Client client)
        {
            if (client.Id == 0)
                context.Clients.Add(client);
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            if (product.Id == 0)
                context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateCategory(Category categ)
        {
            if (categ.Id == 0)
                context.Categories.Add(categ);
            context.SaveChanges();

        }

        public void UpdateFirm(Firm firm)
        {
            if (firm.Id == 0)
                context.Firms.Add(firm);
            context.SaveChanges();
        }


        public List<Product> GetProducts()
        {
            Product.IsLoading = true;
            var list = context.Products.ToList();
            Product.IsLoading = false;
            return list;
        }
        public List<BaseObject> GetBaseObjects()
        {
            return context.BaseObjects.ToList();
        }

        public void UpdateUsers(User user)
        {
            if (user.Id == 0)
                context.Users.Add(user);
            context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            var categories = context.Categories.ToList();
            if (categories.Count == 0)
                Category.CreateDefaultCategory();
            return categories;
        }

        public void UpdateSolds(SoldItem sold)
        {
            if (sold.Id == 0)
                context.SoldItems.Add(sold);
            context.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public List<Firm> GetFirms()
        {
            return context.Firms.ToList();
        }

        public List<SoldItem> GetSoldItems()
        {
            return context.SoldItems.ToList();
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
        public void DeleteClient(Client client)
        {
            context.Clients.Remove(client);
            context.SaveChanges();
        }
        
        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

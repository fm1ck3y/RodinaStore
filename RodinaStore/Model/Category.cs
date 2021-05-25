using RodinaStore.DateBase;
using System.ComponentModel.DataAnnotations;

namespace RodinaStore.Model
{


    public class Category
    {
        public Category() { }
        public Category(string name, int discount, string[] sizes) {
            this.Name = name;
            this.Discount = discount;
            this.Size = true;
            this.Sizes = string.Join(";",sizes);
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Discount { get; set; }

        public bool Size { get; set; }

        public string Sizes { get; set; }

        public string[] ArraySizes
        {
            get
            {
                return Sizes.Split(';');
            }
        }
          
        public static void CreateDefaultCategory()
        {
            RodinaStoreController.Instance.UpdateCategory(new Category("Обувь", 0, Category.SizesForFootwear));
            RodinaStoreController.Instance.UpdateCategory(new Category("Одежда", 0, Category.SizesForOuterwear));
        }

        private static readonly string[] SizesForOuterwear = { "XS", "S", "M", "L", "XL", "XXL", "XXXL" };
        private static readonly string[] SizesForFootwear = { "34,5", "35,5", "36", "36,5", "37", "38", "38,5",
            "38,5", "39", "40", "40,5", "41", "42", "43", "43,5", "44", "44,5","45","46","46,5","47","48", };
    }
}

using System;

namespace Adv_Session02_Delegates
{
    #region Product Data Model
    /// <summary>
    /// Core product entity representing catalog items in ShopMaster.
    /// Starter code required by the assignment.
    /// </summary>
    public class Product
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // "Electronics", "Clothing", "Food", "Books"
        public double Price { get; set; }
        public int Stock { get; set; }
        #endregion

        #region Constructors
        public Product() { }

        public Product(int id, string name, string category, double price, int stock)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            Stock = stock;
        }
        #endregion

        #region Formatting Methods
        /// <summary>
        /// Formats product as: Name - $Price (Stock: X)
        /// </summary>
        public string ToCatalogString()
        {
            return $"{Name} - ${Price} (Stock: {Stock})";
        }

        /// <summary>
        /// Formats product as: Name - $Price
        /// </summary>
        public string ToShortString()
        {
            return $"{Name} - ${Price}";
        }

        /// <summary>
        /// Formats product as: [Category] Name | Price: $X | Stock: Y
        /// </summary>
        public string ToDetailedString()
        {
            return $"[{Category}] {Name} | Price: ${Price} | Stock: {Stock}";
        }

        public override string ToString()
        {
            return ToCatalogString();
        }
        #endregion
    }
    #endregion
}

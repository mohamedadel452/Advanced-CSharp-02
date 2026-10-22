using System;
using System.Collections.Generic;

namespace Adv_Session02_Delegates
{
    #region Task 03.3: Product Filtering via Predicate
    /// <summary>
    /// Implements Task 03.3: Condition-based filtering using Predicate&lt;Product&gt;.
    /// Senior Architectural Design:
    /// Explains Predicate&lt;T&gt; vs Func&lt;T, bool&gt;:
    /// Predicate&lt;T&gt; was introduced in .NET 2.0 specifically for collection filtering (like List&lt;T&gt;.FindAll).
    /// Func&lt;T, bool&gt; was introduced later in .NET 3.5 with LINQ. Both have identical signatures (T -> bool),
    /// but Predicate clearly expresses domain intent: a truth-test condition.
    /// </summary>
    public static class ProductFilter
    {
        #region Methods
        /// <summary>
        /// Filters products based on a boolean condition represented by a Predicate.
        /// </summary>
        /// <param name="products">The product list to filter.</param>
        /// <param name="condition">Predicate evaluating whether a product meets the criteria.</param>
        /// <returns>List of matching products.</returns>
        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));
            if (condition == null) throw new ArgumentNullException(nameof(condition));

            List<Product>? matchingProducts = new List<Product>();

            foreach (Product product in products)
            {
                if (condition(product))
                {
                    matchingProducts.Add(product);
                }
            }

            return matchingProducts;
        }
        #endregion
    }
    #endregion
}

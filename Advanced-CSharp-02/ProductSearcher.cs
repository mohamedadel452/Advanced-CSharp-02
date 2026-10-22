using System;
using System.Collections.Generic;

namespace Adv_Session02_Delegates
{
    #region Task 01: Smart Product Search
    /// <summary>
    /// Implements Task 01: Flexible product searching via delegates.
    /// Senior Architectural Design:
    /// Adheres to the Open/Closed Principle (OCP) - Open for extension, Closed for modification.
    /// By parameterizing the filter condition through Func&lt;Product, bool&gt;, this method
    /// never needs to be edited again, no matter what crazy filter criteria the business invents.
    /// </summary>
    public static class ProductSearcher
    {
        #region Search Methods
        /// <summary>
        /// Searches products matching an arbitrary condition passed as a delegate.
        /// </summary>
        /// <param name="products">The product list to inspect.</param>
        /// <param name="filter">Delegate evaluating whether a product matches the condition (returns true to include).</param>
        /// <returns>Filtered list of products.</returns>
        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            var result = new List<Product>();

            foreach (var product in products)
            {
                // Execute the delegate (invokes target lambda or method)
                if (filter(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }
        #endregion
    }
    #endregion
}

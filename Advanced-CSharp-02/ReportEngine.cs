using System;
using System.Collections.Generic;

namespace Adv_Session02_Delegates
{
    #region Task 03.1: Custom Report Generator
    /// <summary>
    /// Implements Task 03.1: Flexible report printing using Action&lt;Product&gt;.
    /// Senior Architectural Design:
    /// Action&lt;T&gt; is used when a side-effect is desired (e.g. console output, formatting, logging)
    /// without returning a value. The engine owns the iteration; the caller owns the formatting.
    /// </summary>
    public static class ReportEngine
    {
        #region Methods
        /// <summary>
        /// Iterates over all products and executes the provided Action on each element.
        /// </summary>
        /// <param name="products">The product list.</param>
        /// <param name="action">Action delegate defining the printing or formatting behavior.</param>
        public static void PrintReport(List<Product> products, Action<Product> action)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));
            if (action == null) throw new ArgumentNullException(nameof(action));

            foreach (var product in products)
            {
                // Invoke the delegate on each product instance
                action(product);
            }
        }
        #endregion
    }
    #endregion
}

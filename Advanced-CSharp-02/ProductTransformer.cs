using System;
using System.Collections.Generic;

namespace Adv_Session02_Delegates
{
    #region Task 03.2: Product Transformation Engine
    /// <summary>
    /// Implements Task 03.2: Mapping and transforming products using Func&lt;Product, TResult&gt;.
    /// Senior Architectural Design:
    /// Demonstrates Projection / Mapping (the theoretical foundation of LINQ's .Select()).
    /// Takes a Product in, returns a transformed value of type TResult out.
    /// </summary>
    public static class ProductTransformer
    {
        #region Methods
        /// <summary>
        /// Transforms each Product into a target type TResult using a transformation delegate.
        /// </summary>
        /// <typeparam name="TResult">The destination projected type.</typeparam>
        /// <param name="products">The product collection.</param>
        /// <param name="transformer">Delegate that maps a Product to TResult.</param>
        /// <returns>A list of transformed elements.</returns>
        public static List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> transformer)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));
            if (transformer == null) throw new ArgumentNullException(nameof(transformer));

            List<TResult>? result = new List<TResult>(products.Count);

            foreach (var product in products)
            {
                result.Add(transformer(product));
            }

            return result;
        }
        #endregion
    }
    #endregion
}

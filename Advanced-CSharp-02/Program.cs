

namespace Adv_Session02_Delegates
{


    #region Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Load the shared product catalog from starter code
            List<Product> catalog = ProductCatalog.GetCatalog();
           
            #region Header
            Console.WriteLine("================================================================================");
            Console.WriteLine("                  SHOPMASTER - ONLINE STORE ORDER PROCESSING                    ");
            Console.WriteLine("                     Advanced C# Session 02 - Delegates                         ");
            Console.WriteLine("================================================================================\n");
            #endregion
           
            #region Task 01: Smart Product Search (Func<Product, bool>)
            /*
            --------------------------------------------------------------------------------
            TASK 01: SMART PRODUCT SEARCH
            --------------------------------------------------------------------------------
            Delegate Used: Func<Product, bool>
            Why: The search engine needs a predicate function that takes a Product and returns
                 a boolean (true = match, false = ignore). Func<Product, bool> allows callers
                 to pass clean inline lambda expressions without altering SearchProducts.
            --------------------------------------------------------------------------------
            */
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("TASK 01: SMART PRODUCT SEARCH (Func<Product, bool>)");
            Console.WriteLine("--------------------------------------------------");

            #region 1. All Electronics products
            Console.WriteLine("--- Electronics ---");
            List<Product> electronics = ProductSearcher.SearchProducts(catalog, p => p.Category == "Electronics");
            foreach (var p in electronics)
            {
                Console.WriteLine(p.ToCatalogString());
            }
            Console.WriteLine();
            #endregion
            
            #region 2. Products cheaper than $50
            Console.WriteLine("--- Under $50 ---");
            List<Product> under50 = ProductSearcher.SearchProducts(catalog, p => p.Price < 50);
            foreach (var p in under50)
            {
                Console.WriteLine(p.ToCatalogString());
            }
            Console.WriteLine();
            #endregion
           
            #region 3. Products that are in stock (Stock > 0)
            Console.WriteLine("--- In Stock ---");
            List<Product> inStock = ProductSearcher.SearchProducts(catalog, p => p.Stock > 0);
            // Printing products in stock matching the expected output format
            foreach (var p in inStock)
            {
                Console.WriteLine(p.ToCatalogString());
            }
            Console.WriteLine();
            #endregion
           
            #region 4. Clothing products under $100
            Console.WriteLine("--- Clothing Under $100 ---");
            List<Product> clothingUnder100 = ProductSearcher.SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            foreach (var p in clothingUnder100)
            {
                Console.WriteLine(p.ToCatalogString());
            }
            Console.WriteLine("\n");
            #endregion
            #endregion

            #region Task 03.1: Print Reports (Action<Product>)
            /*
            --------------------------------------------------------------------------------
            TASK 03.1: CUSTOM REPORT GENERATOR - PRINT REPORTS
            --------------------------------------------------------------------------------
            Delegate Used: Action<Product>
            Why: Action<T> represents an operation that takes an input and returns void.
                 It is ideal for console printing, logging, or rendering where the caller
                 specifies the format and side-effect without producing a return value.
            --------------------------------------------------------------------------------
            */
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("TASK 03.1: PRINT REPORTS (Action<Product>)");
            Console.WriteLine("--------------------------------------------------");

            // Scenario 1: Short Report (Name - $Price)
            Console.WriteLine("--- Short Report ---");
            ReportEngine.PrintReport(catalog, p => Console.WriteLine(p.ToShortString()));
            Console.WriteLine();

            // Scenario 2: Detailed Report ([Category] Name | Price: $X | Stock: Y)
            Console.WriteLine("--- Detailed Report ---");
            ReportEngine.PrintReport(catalog, p => Console.WriteLine(p.ToDetailedString()));
            Console.WriteLine("\n");
            #endregion



        }
    }
    #endregion
}


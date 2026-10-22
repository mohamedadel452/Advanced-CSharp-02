

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

            #region Task 03.2: Transform Products (Func<Product, TResult>)
            /*
            --------------------------------------------------------------------------------
            TASK 03.2: TRANSFORM PRODUCTS (Func<Product, TResult>)
            --------------------------------------------------------------------------------
            Delegate Used: Func<Product, TResult>
            Why: Func<T, TResult> is used for mapping/projections. It takes an input entity
                 and returns a newly computed or formatted representation of type TResult.
                 This is the exact underlying design pattern of LINQ's .Select() extension.
            --------------------------------------------------------------------------------
            */
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("TASK 03.2: TRANSFORM PRODUCTS (Func<Product, TResult>)");
            Console.WriteLine("--------------------------------------------------");

            // Scenario 3: Summary List: Name ($Price)
            Console.WriteLine("--- Summary List ---");
            List<string> summaryList = ProductTransformer.TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            foreach (var item in summaryList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Scenario 4: Price Label: "Expensive!" if Price > 100 else "Affordable"
            Console.WriteLine("--- Price Labels ---");
            List<string> priceLabels = ProductTransformer.TransformProducts(catalog, p =>
                $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
            foreach (string label in priceLabels)
            {
                Console.WriteLine(label);
            }
            Console.WriteLine("\n");
            #endregion

            #region Task 03.3: Filter Products (Predicate<Product>)
            /*
            --------------------------------------------------------------------------------
            TASK 03.3: FILTER PRODUCTS (Predicate<Product>)
            --------------------------------------------------------------------------------
            Delegate Used: Predicate<Product>
            Why: Predicate<T> is explicitly designed for conditional criteria evaluation.
                 It is equivalent to Func<T, bool> and communicates semantic intent:
                 evaluating whether a product meets a specific business condition (Low Stock).
            --------------------------------------------------------------------------------
            */
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("TASK 03.3: FILTER PRODUCTS (Predicate<Product>)");
            Console.WriteLine("--------------------------------------------------");

            // Scenario 5: Low-Stock Alert: Find products with Stock < 20
            Console.WriteLine("--- Low-Stock Alert ---");
            List<Product> lowStockProducts = ProductFilter.FilterProducts(catalog, p => p.Stock < 20);
            foreach (var p in lowStockProducts)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }
            Console.WriteLine("\n");
            #endregion



        }
    }
    #endregion
}


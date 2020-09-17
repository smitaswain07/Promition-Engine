using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            //hardcoded for testing
            int ACount = 1;
            int BCount = 5;
            int CCount = 3;
            int DCount = 2;
            int total = p.CalculateTotal(ACount, BCount, CCount, DCount);

            Console.WriteLine(total);
            Console.ReadLine();
        }

        public int CalculateTotal(int ACount, int BCount, int CCount, int DCount)
        {

            List<Product> products = new List<Product>();

            products.Add(new Product() { SKU = 'A', Price = 50 });
            products.Add(new Product() { SKU = 'B', Price = 30 });
            products.Add(new Product() { SKU = 'C', Price = 20 });
            products.Add(new Product() { SKU = 'D', Price = 15 });

            int total = 0;

            int APrice = products.First(x => x.SKU == 'A').Price;
            int BPrice = products.First(x => x.SKU == 'B').Price;
            int CPrice = products.First(x => x.SKU == 'C').Price;
            int DPrice = products.First(x => x.SKU == 'D').Price;

            total = ACount * APrice + BCount * BPrice + CCount * CPrice + DCount * DPrice;

            return total;
        }

    }

    public class Product
    {
        public char SKU { get; set; }
        public int Price { get; set; }
    }
}

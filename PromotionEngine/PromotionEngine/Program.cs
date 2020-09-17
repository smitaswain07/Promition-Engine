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
            //Promotions should be mutually exclusive - only one can be applied
            if (ACount >= 3) //Apply first promotion 3A=130
            {
                //Apply Promotion
                int firstPromotion = 130; //3A
                int promoNotApplicableCount = ACount % 3;
                int promoApplicableCount = ACount - promoNotApplicableCount;

                int totalAPrice = (promoApplicableCount / 3) * firstPromotion + promoNotApplicableCount * APrice;
                total = totalAPrice + BCount * BPrice + CCount * CPrice + DCount * DPrice;

            }
            else if (CCount > 0 && DCount > 0) //Apply second promotion C+D=30
            {
                //Apply Promotion
                int secondPromotion = 30; //  C+D
                int promoNotApplicableCount = (CCount > DCount) ? CCount - DCount : DCount - CCount;
                var CDTotalPrice = secondPromotion * ((CCount > DCount) ? DCount : CCount);
                var extraCDSKUPrice = (CCount > DCount) ? promoNotApplicableCount * CPrice : promoNotApplicableCount * DPrice;
                total = CDTotalPrice + extraCDSKUPrice + BCount * BPrice + ACount * APrice;

            }
            else if (BCount >= 2) //Apply third promotion 2B=45
            {
                //Apply Promotion
                int thirdPromotion = 45; // 2B
                int promoNotApplicableCount = BCount % 2;
                int promoApplicableCount = BCount - promoNotApplicableCount;

                int totalBPrice = (promoApplicableCount / 2) * thirdPromotion + promoNotApplicableCount * BPrice;
                total = totalBPrice + ACount * APrice + CCount * CPrice + DCount * DPrice;

            }
            //No Promotion Applied
            else


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

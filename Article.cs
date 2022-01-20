using System;

namespace Everything
{
    public class Article

    {
        private static int idSeed = 1;
        public int id { get; set; }
        public string name { get; set; }
        public decimal averagePrice { get; set; }
        public int amount { get; set; }
        public Article(int i, string n, decimal p, int a) {
            this.id = idSeed++;
            this.name = n;
            this.averagePrice = p;
            this.amount = a;
        }
    }
}

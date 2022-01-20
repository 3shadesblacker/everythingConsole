using System;

namespace Everything
{
    public class Article

    {
        private static int idSeed = 1;
        public int id { get; set; }
        public string name { get; set; }
        public double averagePrice { get; set; }
        public int amount { get; set; }
        public Article(int i, string n, double p, int a) {
            this.id = idSeed++;
            this.name = n;
            this.averagePrice = p;
            this.amount = a;
        }
    }
}

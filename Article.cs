using System;

namespace Everything
{
    public class Article
    {
        public long barcode { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int amount { get; set; }
        public DateTime date { get; set; }

        public Article(long c, string n, decimal p, int a, DateTime d) {
            this.barcode = c;
            this.name = n;
            this.price = p;
            this.amount = a;
            this.date = d;
        }

        public Article initArticle(long barcode, string name, decimal price, int amount, DateTime date) {
            return (new Article(barcode, name, price, amount, date));
        }
        public void addArticle(long barcode, decimal price, int amount, DateTime date) { }
        public void deleteArticle(long barcode) { }
    }
}

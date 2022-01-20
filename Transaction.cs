using System;
using System.Text;

namespace Everything
{
    public class Transaction
    {
        private static int idSeed = 1;
        public int id { get; set; }
        public int articleId { get; set; }
        public double price { get; set; }
        public int amount { get; set; }
        public DateTime dateTime { get; set; }

        public Transaction(int id, int articleId, double price, int amount, DateTime dateTime) { 
            this.id = idSeed++;
            this.articleId = articleId;
            this.price = price;
            this.amount = amount;
            this.dateTime = dateTime;
        }
    }
}

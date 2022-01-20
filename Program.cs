using System;
using System.Collections.Generic;

namespace Everything
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // articles and transactions as lists
            List<Article> articles = new List<Article> { };
            List<Transaction> transactions = new List<Transaction> { };
            
            // average price for a single article
            decimal avg(List<Transaction> T)
            {
                decimal avg = 0m;
                foreach (Transaction t in T)
                {
                    avg += t.price;
                }
                return (avg / T.Count);
            }

            // creating a transaction
            void create(string name, decimal price, int amount)
            {
                Article A = articles.Find(x => x.name == name);
                int id;
                if ( A != null) { id = A.id; }
                else { id = articles.Count + 1; }
                articles.Add(new Article(default, name, avg(transactions.FindAll(x => x.id == id)), amount));
                transactions.Add(new Transaction(default, id, price, amount, DateTime.Today));
            }
            
            // delete a transaction or article
            void deleteTransaction(int id) { transactions.RemoveAll(x => x.id == id); }
            void deleteArticle(int id) { articles.RemoveAll (x => x.id == id); }

            // edit an article or transaction
            void editArticle(int id, string name, decimal avg, int amount) { 
                
            }
            void editTransaction(int id, int articleId, decimal price, int amount, DateTime date) {

            }

            // displaying all articles
            void displayArticles()
            {
                Console.WriteLine("---ARTICLES---");
                foreach (Article a in articles)
                {
                    Console.WriteLine($"id - {a.id} | name - {a.name} | price - {a.averagePrice} | amount - {a.amount}");
                }
                Console.WriteLine("--------------");
            }
        }
    }
}

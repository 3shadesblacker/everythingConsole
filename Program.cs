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
            double avg(List<Transaction> T)
            {
                double avg = 0;
                foreach (Transaction t in T)
                {
                    avg += t.price;
                }
                return (avg / T.Count);
            }

            // total amount an article happened
            int amnt(int id)
            {
                int amnt = 0;
                foreach (Transaction t in transactions.FindAll(x => x.articleId == id))
                {
                    amnt += t.amount;
                }
                return (amnt);
            }

            // creating a transaction
            void create(string name, double price, int amount)
            {
                Article A = articles.Find(x => x.name == name);
                int id;
                if (A != null) { id = A.id; }
                else { id = articles.Count + 1; }
                articles.Add(new Article(default, name, avg(transactions.FindAll(x => x.id == id)), amnt(id)));
                transactions.Add(new Transaction(default, id, price, amount, DateTime.Today));
            }

            // edit an article or transaction
            void editArticle(int id, string name, double avg)
            {
                articles[articles.FindIndex(x => x.id == id)] = new Article(id, name, avg, amnt(id));
            }
            void editTransaction(int id, int articleId, double price, int amount, DateTime date)
            {
                transactions[transactions.FindIndex(x => x.id == id)] = new Transaction(id, articleId, price, amount, date);
            }

            // delete a transaction or article
            void deleteTransaction(int id) { transactions.RemoveAll(x => x.id == id); }

            // displaying all articles and transactions
            void displayArticles()
            {
                Console.WriteLine("---ARTICLES---");
                foreach (Article a in articles)
                {
                    Console.WriteLine($@"id -    {a.id} | name -    {a.name} | price -  {a.averagePrice} | amount - {a.amount}");
                }
                Console.WriteLine("--------------");
            }
            void displayTransactions()
            {
                Console.WriteLine("---TRANSACTIONS---");
                foreach (Transaction a in transactions)
                {
                    Console.WriteLine($"id -    {a.id} | articleId -    {a.articleId} | price - {a.price} | amount -    {a.amount} | Date - {a.dateTime}");
                }
                Console.WriteLine("------------------");
            }

            // MAIN PROGRAM
            string option;
            do {
                Console.WriteLine(@"
Choose an option by entering its number.
1 - Add a transaction
2 - Edit a transaction
3 - Edit an article
4 - Delete a transaction
5 - Display articles
6 - Display transactions
Enter 'X' to quit.");
                option = Console.ReadLine();
                Console.Clear();
                switch (option){
                    case "1":
                        Console.WriteLine("Article name?");
                        string name = Console.ReadLine();
                        Console.WriteLine("Amount?");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Price");
                        double price = Convert.ToDouble(Console.ReadLine());
                        create(name, price, amount);
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("id?");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Article id?");
                        int articleId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("price?");
                        price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Amount?");
                        amount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Date?");
                        DateTime date = Convert.ToDateTime(Console.ReadLine());
                        editTransaction(id, articleId, price, amount, date);
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("id?");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("name");
                        name = Console.ReadLine();
                        Console.WriteLine("price");
                        price = Convert.ToDouble(Console.ReadLine());
                        editArticle(id, name, price);
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine("id?");
                        id = Convert.ToInt32(Console.ReadLine());
                        deleteTransaction(id);
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        displayArticles();
                        break;
                    case "6":
                        Console.Clear();
                        displayTransactions();
                        break;
                    default:
                        Console.WriteLine(@"
Choose an option by entering its number.
1 - Add a transaction
2 - Edit a transaction
3 - Edit an article
4 - Delete a transaction
5 - Display articles
6 - Display transactions
Enter 'X' to quit.");
                        option = Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while(option != "X");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public interface ICoffeeShop
    {
        void ProcessOrder(string customerName, bool wantsCoffee, bool wantsSandwich);
        void UpdateMenu(double coffeePrice, double sandwichPrice);
    }

    public class Menu
    {
        public double CoffeePrice { get; private set; }
        public double SandwichPrice { get; private set; }

        public void UpdateMenu(double coffeePrice, double sandwichPrice)
        {
            CoffeePrice = coffeePrice;
            SandwichPrice = sandwichPrice;
            Console.WriteLine("Updated Price of Coffee: "+ coffeePrice);
            Console.WriteLine("Updated Price of Sandwich: " + sandwichPrice);
        }
    }

    public class Order
    {
        private readonly Menu _menu;

        public Order(Menu menu)
        {
            _menu = menu;
        }

        public void ProcessOrder(string customerName, bool wantsCoffee, bool wantsSandwich)
        {
            double total = 0;

            if (wantsCoffee)
                total += _menu.CoffeePrice;
            if (wantsSandwich)
                total += _menu.SandwichPrice;

            Console.WriteLine("Order processed for " + customerName);
            Console.WriteLine("Total amount to pay: " + total);
            ProcessPayment(total);
        }

        private void ProcessPayment(double amount)
        {
            Console.WriteLine("Processing payment of " + amount);
        }
    }

    public class CoffeeShop : ICoffeeShop
    {
        private readonly Menu _menu;
        private readonly Order _order;

        public CoffeeShop()
        {
            _menu = new Menu();
            _order = new Order(_menu);
        }

        public void ProcessOrder(string customerName, bool wantsCoffee, bool wantsSandwich)
        {
            _order.ProcessOrder(customerName, wantsCoffee, wantsSandwich);
        }

        public void UpdateMenu(double coffeePrice, double sandwichPrice)
        {
            _menu.UpdateMenu(coffeePrice, sandwichPrice);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CoffeeShop coffeeShop = new CoffeeShop();

            coffeeShop.UpdateMenu(5.0, 7.5);

            coffeeShop.ProcessOrder("Hasan", true, false);
            coffeeShop.ProcessOrder("Ahmed", true, true);
            Console.ReadLine();
        }
    }
}




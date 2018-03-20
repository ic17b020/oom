using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;


namespace Task2
{
    public class Shoe
    {
        private double s_price;

        public Shoe (string Brand, string Model, double Size)
        {
            if (string.IsNullOrWhiteSpace(Brand)) throw new ArgumentException("Please state a brand name.", nameof(Brand));
            if (string.IsNullOrWhiteSpace(Model)) throw new ArgumentException("Please state a model name.", nameof(Model));

            brand = Brand;
            model = Model;
            size = Size;
        }

        public string brand { get; }
        public string model { get; }
        public double size { get; }

        public void set_price (double new_price)
        {
            if (new_price < 0) throw new ArgumentException("Please state a price equal to or greater than zero.");
            s_price = new_price;
        }

        public double get_price()
        {
            return s_price;
        }

        public void show_full_data ()
        {
            Console.WriteLine("Brand: {0}\nModel: {1}\nSize: {2}\nPrice: {3}\n", brand, model, size, s_price);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Shoe s_1 = new Shoe("Nike", "Free", 43.00);

            Console.WriteLine("{0}\n", s_1.brand);

            Shoe s_2 = new Shoe("Adidas", "Predator", 43.5);

            s_1.set_price(79.99);

            Console.WriteLine("Der {0} {1} kostet {2} Euro.\n", s_1.brand, s_1.model, s_1.get_price());

            s_1.show_full_data();

            s_2.show_full_data();


        }
    }
}

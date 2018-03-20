using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;


namespace Task2
{
    interface Shoe
    {
        void show_all_data();
        string create_key();
    }

    public class Allday : Shoe
    {
        private double a_price;

        public Allday (string Brand, string Model, double Size)
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
            a_price = new_price;
        }

        public double get_price()
        {
            return a_price;
        }

        public void show_all_data()
        {
            Console.WriteLine("Brand: {0}\nModel: {1}\nSize: {2}\n", brand, model, size);
            if (a_price > 0) Console.WriteLine("Price: {0}\n", a_price);
        }

        public string create_key()
        {
            return "Allday/" + brand + "_" + model;
        }
    }

    public class Soccer : Shoe
    {
        private double s_price;

        public Soccer(string Brand, string Model, double Size, bool Turf, bool Leather)
        {
            if (string.IsNullOrWhiteSpace(Brand)) throw new ArgumentException("Please state a brand name.", nameof(Brand));
            if (string.IsNullOrWhiteSpace(Model)) throw new ArgumentException("Please state a model name.", nameof(Model));
            if (Turf != true) throw new ArgumentException("Only turf shoes allowed!");

            brand = Brand;
            model = Model;
            size = Size;
            turf = Turf;
            leather = Leather;

        }

        public string brand { get; }
        public string model { get; }
        public double size { get; }
        public bool turf;
        public bool leather { get; }

        public string ask_material()
        {
            if (leather) return "Leather";
            else return "Plastic";
        }

        public void show_all_data()
        {
            Console.WriteLine("Brand: {0}\nModel {1}\nSize: {2}\nMaterial: {3}\n", brand, model, size, ask_material());
        }

        public string create_key()
        {
            return "Soccer/" + brand + "_" + model + "->" + ask_material(); 
        }

        public void set_price(double new_price)
        {
            if (new_price < 0) throw new ArgumentException("Please state a price equal to or greater than zero.");
            s_price = new_price;
        }

        public double get_price()
        {
            return s_price;
        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            Allday a_1 = new Allday("Nike", "Free", 43.00);

            //Console.WriteLine("{0}\n", a_1.brand);

            Allday a_2 = new Allday("Adidas", "Cloudfoam", 43.5);
            Allday a_3 = new Allday("Vans", "Half Cab", 42.5);
            Allday a_4 = new Allday("Asics", "Aaron", 43.0);

            Soccer s_1 = new Soccer("Nike", "Total 90", 43, true, false);
            Soccer s_2 = new Soccer("Adidas", "Copa Mundial", 42.5, true, true);
            Soccer s_3 = new Soccer("Puma", "King", 43, true, true);

            a_1.set_price(79.99);

            Shoe[] instarr = { a_1, a_2, a_3, a_4, s_1, s_2, s_3 };

            foreach (var i in instarr)
            {
                Console.WriteLine(i.create_key());
                i.show_all_data();
            }


            //Console.WriteLine("Der {0} {1} kostet {2} Euro.\n", a_1.brand, a_1.model, a_1.get_price());

            //Console.WriteLine("This is a key: {0}", a_1.create_key());


        }
    }
}

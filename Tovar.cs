using cs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace cs
{
    class Class_giv_name : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Product && y is Product) return string.Compare((x as Product).Giv_name, (y as Product).Giv_name);
            throw new NotImplementedException();
        }
    }
    class Time : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Product && y is Product) return string.Compare((x as Product).Sale_per, (y as Product).Sale_per);
            throw new NotImplementedException();
        }
    }
    class Product : IComparable
    {
        public string Type { get; set; }
        public string Giv_name { get; set; }
        public string Entr_per { get; set; }
        public string Sale_per { get; set; }
        public string Per_of_write_downs { get; set; }
        public int CompareTo(object subj)
        {
            if (subj is Product) return Entr_per.CompareTo((subj as Product).Entr_per);
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"тип: {Type}, поступление: {Entr_per}, наименование: {Giv_name}, продажа: {Sale_per}, списание: {Per_of_write_downs}";
        }
    }
    class Goods : IEnumerable
    {
        Product[] products = { new Product { Type = "продукт", Giv_name = "молоко", Entr_per = "020323", Sale_per = "030323", Per_of_write_downs = "040323" }, new Product { Type = "продукт", Giv_name = "хлеб", Entr_per = "050323", Sale_per = "060323", Per_of_write_downs = "060323" }, new Product { Type = "продукт", Giv_name = "рис", Entr_per = "070323", Sale_per = "080323", Per_of_write_downs = "090323" }, new Product { Type = "бытовая химия", Giv_name = "мыло", Entr_per = "100323", Sale_per = "110323", Per_of_write_downs = "110323" }, new Product { Type = "бытовая химия", Giv_name = "стиральный порошок", Entr_per = "120323", Sale_per = "130323", Per_of_write_downs = "140323" }, new Product { Type = "бытовая химия", Giv_name = "освежитель воздуха", Entr_per = "150323", Sale_per = "160323", Per_of_write_downs = "160323" } };
        public IEnumerator GetEnumerator()
        {
            return products.GetEnumerator();
        }
        public void Sort()
        {
            Array.Sort(products);
        }
        public void Sort(IComparer comp)
        {
            Array.Sort(products, comp);
        }
    }
    internal class Tovar
    {
        static void Main(string[] args)
        {
            Goods commodity = new Goods();
            WriteLine("сортировка по наименованию");
            commodity.Sort(new Class_giv_name());
            foreach (Product item in commodity) WriteLine(item);
            WriteLine("сортировка по продаже");
            commodity.Sort(new Time());
            foreach (Product item in commodity) WriteLine(item);
        }
    }
}
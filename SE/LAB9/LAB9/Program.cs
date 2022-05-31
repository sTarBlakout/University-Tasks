using System;
using System.Collections;
using System.Collections.Generic;

namespace LAB9
{

#region Zadanie 1
    public interface MenuComponent
    {
        string GetName();
        string GetUrl();
        void DisplayMenu();
    }

    public class MenuItem
    {
        public string name;
        public string url;

        public void DisplayMenu()
        {
            Console.WriteLine("Item: " + name);
        }

        public string GetName()
        {
            return name;
        }

        public string GetUrl()
        {
            return url;
        }
    }

    public class Menu : MenuComponent
    {
        public string name;
        public string url;
        public List<MenuComponent> subMenus = new List<MenuComponent>();

        public void Add(MenuComponent component)
        {
            subMenus.Add(component);
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Menu name: " + name);
            foreach (var item in subMenus) item.DisplayMenu();
        }

        public string GetName()
        {
            return name;
        }

        public string GetUrl()
        {
            return url;
        }
    }

    #endregion

#region Zadanie 2
    public interface IBox
    {
        public string GetName();
        public float GetPrice();
    }

    public class Box : IBox
    {
        public string name;
        public List<IBox> boxes = new List<IBox>();

        public string GetName()
        {
            return name;
        }

        public float GetPrice()
        {
            var price = 0f;
            foreach (var box in boxes) price += box.GetPrice();
            return price;
        }

        public void AddItem(IBox item)
        {
            boxes.Add(item);
        }
    }

    public class Item : IBox
    {
        public string name;
        public float price;

        public string GetName()
        {
            return name;
        }

        public float GetPrice()
        {
            return price;
        }
    }
    #endregion

#region Zadanie 3

    public interface IPracownik
    {
        int Count();
        void ShowInformation();
        string GetName();
    }

    public class Kierownik : IPracownik, IEnumerable<IPracownik>
    {
        public string name;
        public List<IPracownik> pracowniki = new List<IPracownik>();

        public Kierownik(string name)
        {
            this.name = name;
        }

        public int Count()
        {
            var count = 0;
            foreach (var p in pracowniki) count++;
            return count;
        }   

        public void ShowInformation()
        {
            Console.WriteLine("Kierownik: " + name + "\n Pracowniki: \n");
            foreach (var p in pracowniki) p.ShowInformation();
        }

        public void AddPracownik(IPracownik p)
        {
            pracowniki.Add(p);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return pracowniki.GetEnumerator();
        }

        public IEnumerator<IPracownik> GetEnumerator()
        {
            return pracowniki.GetEnumerator();
        }

        public string GetName()
        {
            return name;
        }
    }

    public class Pracownik : IPracownik
    {
        public string name;

        public Pracownik(string name)
        {
            this.name = name;
        }

        public int Count()
        {
            return 1;
        }

        public void ShowInformation()
        { 
            Console.WriteLine("Pracownik: " + name);
        }

        public string GetName()
        {
            return name;
        }
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Pracownik("Alex");
            var p2 = new Pracownik("John");
            var k1 = new Kierownik("Michael");

            k1.AddPracownik(p1);
            k1.AddPracownik(p2);

            foreach (var p in k1)
            {
                Console.WriteLine(p.GetName());
            }
        }
    }
}

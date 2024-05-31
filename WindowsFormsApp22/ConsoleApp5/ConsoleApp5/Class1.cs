using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp5
{
    public class Avtomobil : Room
    {



        public Avtomobil(string name, float cost, int art) : base(name, cost, art, "Automobil")
        {
           
        }

        



        public static bool operator >(Avtomobil r1, Avtomobil r2)
        {
            return r1.Cost > r2.Cost;
        }
        public static bool operator <(Avtomobil r1, Avtomobil r2)
        {
            return r1.Cost < r2.Cost;
        }

    }

    public class Autorasp
    {
        

        public Autorasp()
        {
            auto = new List<Avtomobil>();
           
            
        }
        public void dovav(Avtomobil room1) { auto.Add(room1); }
        

        //public int RoomsCount => auto.Count;

        public string GetTotalSquare()
        {
            string d = " ";
            int i = 0;
            string n = "121";
            float g = 0;
            foreach (var r in auto)
            {
                if (i == 0) { n = r.Name; g = r.Cost; }

                if (r.Name==n && i != 0)
                {
                    d += r.Name + " ";
                   
                }
                i += 1;
            }

            return d;
        }
        public float Livingsquare()
        {
            float d = 0;
            int i = 0;
            string n = "121";
            
            foreach (var r in auto)
            {
                
                
                    if (i == 0) { n = r.Name;  }

                    if ( i != 0 &&  r.Name ==n)
                        d += 1;
                
                i += 1;
            }

            return d;
        }
        public float Naitiminsena()
        {
            float resualt = 1;
            int i = 0;
            if (auto.Count > 1)
            {

                foreach (var r in auto)
                {
                   
                    {
                        if (i == 1) resualt = r.Cost;
                        else if (i > 1)
                        {
                            var x = r.Cost;

                            if (x > resualt) resualt = x;
                        }
                    }
                    i++;
                }
            }
            return resualt;
        }
        public string Get()
        {
            string d = " ";
            int i = 0;
            string n = " ";
            float g = 1;
            foreach (var r in auto)
            {
                if (i == 0) { n = r.Kateg; }

                if (r.Kateg == n && i != 0)
                {

                    r.Cost = r.Cost + g * r.Cost;
                    d += r.Cost + " ";
                }
                i += 1;
            }

            return d;
        }
        private List<Avtomobil> auto;
    }
}
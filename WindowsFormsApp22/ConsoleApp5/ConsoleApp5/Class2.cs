using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Room
    {

        
        public Room(string name, float cost, int art, string kateg)
        {
            Name = name;
            Cost =cost ;
            Art = art;
           Kateg= kateg;
        }

        public string Name;
        public  float Cost;
        public  int Art;
        public  string Kateg;
        public static bool operator >(Room r1, Room r2) 
        { 
            return r1.Cost > r2.Cost;
        }
        public static bool operator <(Room r1, Room r2)
        {
            return r1.Cost < r2.Cost;
        }

    }

    public class Flat
    {
        
        
        public Flat()
        {
            rooms = new List<Room>();
            
        }
        
        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

        //public int RoomsCount => rooms.Count;

        public string GetTotalSquare()
        {
            string d=" ";
            int i = 0;
            string n = " ";
           
            foreach (var r in rooms)
            {
                if (i == 0) { n = r.Kateg; }

                if (r.Kateg == n && i != 0)
                {
                    d += r.Name + " ";
                    
                }
                i += 1;
            }

            return  d;
        }
       

        public float Livingsquare()
        {
            float d=0;
            int i = 0;
            string n = "121";
            float g=0;
            foreach (var r in rooms)
            {
                if (i == 0) { n = r.Kateg;g = r.Cost; }

                if (r.Kateg == n && i != 0 && r.Cost == g)
                    d += r.Cost;
                i += 1;
            }

            return d;
        }
        public float Naitiminsena()
        {
           float resualt=0;
            int i = 0;
            if (rooms.Count > 1) 
            {
                
                foreach (var r in rooms)
                {
                    if (i == 1) resualt = r.Cost;
                    else if (i > 1)
                    {
                        var x = r.Cost;
                        if (x < resualt) resualt = x;
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
            foreach (var r in rooms)
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
        private List<Room> rooms;
    }
}

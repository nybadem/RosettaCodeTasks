using System;
using System.Collections.Generic;

namespace HundredDoors
{
    class Program
    {
    class Door
        {
            public int doornum;
            public bool state;

            public Door(int num, bool doorstate = false)
            {
                this.doornum = num;
                this.state = doorstate;
            }

        }

        static List<Door> doorset = new List<Door>();
        static void InitializeDoors()
        {
            for (int i = 1; i < 101; i++)
            {
                Door newdoor = new Door(i);
                doorset.Add(newdoor);
            }
            ListDoors();
        }
        static void MakePasses()
        {
            for (int curPass = 1; curPass <= doorset.Count; curPass++)
            {
                foreach(Door dr in doorset)
                {
                    if (dr.doornum % curPass == 0) dr.state = !dr.state;
                   
                }
            }
        }

        static void ListDoors()
        {
            foreach (Door checkeddoor in doorset)
                Console.Write(checkeddoor.doornum.ToString() + ": " + checkeddoor.state.ToString() + "  \t");
        }

        static void Main()
        {
            Console.WriteLine("Hundred Doors\n\n");
            InitializeDoors();
            Console.WriteLine("Doors are initialized, making passes!");
            MakePasses();
            Console.WriteLine("Final states of the doors are as follows:");
            ListDoors();
            Console.WriteLine("I guess we have a satisfactory output... Press any key to end the program.");
            Console.ReadKey(true);

        }
    }
}

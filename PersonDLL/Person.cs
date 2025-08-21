using System;
using System.Linq;

namespace PersonDLL
{
    public class Person
    {
        private string name;
        private int body;
        private int reflex;
        private int knowledge;
        private int wit;

        private static Random r = new Random();

        private string[] nameStart = { "Malc", "Arv", "Boab", "Hep", "Loan", "Kros", "Phib", "Fi", "Arzo", "Milt" };
        private string[] nameSegments = { "all", "ut", "abrun", "mun", "ahal", "at", "a", "oph", "ir", "ett", "im", "in", "us" };
        private string[] nameConnector = { " of ", ", son of ", ", daughter of ", ", hero of ", " ", " ", " ", " ", " ", " ", " ", " " };



        public Person(string nm, int bod, int rflx, int knowl, int wt)
        {
            name = nm;
            body = bod;
            reflex = rflx;
            knowledge = knowl;
            wit = wt;
        }
        public Person() { }
        private string randomName()
        {
            int nameSegs = Roll();
            string name = nameStart[r.Next(nameStart.Length)];
            for (int i = 0; i < nameSegs - 1; i++)
            {
                name += nameSegments[r.Next(nameSegments.Length)];
            }
            name += nameConnector[r.Next(nameConnector.Length)];
            name += nameStart[r.Next(nameStart.Length)];
            nameSegs = Roll();
            for (int i = 0; i < nameSegs - 1; i++)
            {
                name += nameSegments[r.Next(nameSegments.Length)];
            }
            return name;
        }
        private int Roll()
        {
            return (r.Next(5)) + 1;
        }
        private int higherXRoll(int rolls, int highX)
        {
            int[] rolled = new int[highX];
            int ttl = new int();
            for (int i = 0; i < rolls; i++)
            {
                int rl = Roll();
                if (i >= rolled.Length)
                {
                    if (rolled.Min() < rl)
                    {
                        rolled[Array.IndexOf(rolled, rolled.Min())] = rl;
                    }
                }
                else
                {
                    rolled[i] = rl;
                }
            }
            for (int i = 0; i < rolled.Length; i++)
            {
                ttl += rolled[i];
            }
            return ttl;
        }
        public Person randomStats()
        {
            Person rPers = new Person(randomName(), higherXRoll(4, 3), higherXRoll(4, 3), higherXRoll(4, 3), higherXRoll(4, 3));
            return rPers;
        }
        public void printStats()
        {
            System.Diagnostics.Debug.WriteLine($"name: {name}\n strength: {body}\n rexlex: {reflex}\n knowledge: {knowledge}\n wit: {wit}");
        }
    }
}

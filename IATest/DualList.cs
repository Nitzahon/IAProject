using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IATest
{
    [Serializable()]
    public class DualList
    {
        
        public Lister Pair1 { get; set; }

        public Lister Pair2 { get; set; }

        public DualList()
        {
            Pair1 = new Lister();
            Pair2 = new Lister();

        }
        public DualList(string n, string[] t1, bool[] t2, string nb, string[] t1b, bool[] t2b)
        {
            Pair1 = new Lister(n, t1, t2);
            Pair2 = new Lister(nb, t1b, t2b);
        }
        public DualList(string n, List<string> t1, List<bool> t2, string nb, List<string> t1b, List<bool> t2b)
        {
            Pair1 = new Lister(n, t1, t2);
            Pair2 = new Lister(nb, t1b, t2b);
        }
        public DualList(Lister lefList, Lister rigList)
        {
            Pair1 = new Lister(lefList);
            Pair2 = new Lister(rigList);
        }
        public DualList(DualList input)
        {
            Pair1 = input.Pair1;
            Pair2 = input.Pair2;
        }
    }
}

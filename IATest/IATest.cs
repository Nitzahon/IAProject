using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IATest
{
    [Serializable()]
    public class IATest
    {
        
        public DualList g1 { get; set; }
        
        public DualList g2 { get; set; }
        
        public int TestSize { get; set; }
        
        public string curr { get; set; }
        
        public List<int> results { get; set; }
        public IATest()
        {
            g1 = new DualList();
            g2 = new DualList();
            TestSize = 0;
            curr=null;
            results = new List<int>();
        }
        public IATest(string n1, string n2, string[] t1, bool[] b1, string[] t2, bool[] b2, string n1b, string n2b, string[] t1b, bool[] b1b, string[] t2b, bool[] b2b, int size)
        {
            g1 = new DualList(n1, t1, b1, n2, t2, b2);
            g2 = new DualList(n1b, t1b, b1b, n2b, t2b, b2b);
            TestSize = size;
            curr=null;
            results = new List<int>();
        }
        public IATest(string n1, string n2, List<string> t1, List<bool> b1, List<string> t2, List<bool> b2, string n1b, string n2b, List<string> t1b, List<bool> b1b, List<string> t2b, List<bool> b2b, int size)
        {
            g1 = new DualList(n1, t1, b1, n2, t2, b2);
            g2 = new DualList(n1b, t1b, b1b, n2b, t2b, b2b);
            TestSize = size;
            curr=null;
            results = new List<int>();
        }
        public IATest(DualList l1, DualList l2, int size)
        {
            g1 = l1;
            g2 = l2;
            TestSize = size;
            curr = null;
            results = new List<int>();
        }
        public IATest(IATest input)
        {

            g1 = new DualList(input.g1);
            g2 = new DualList(input.g2);
            TestSize = input.TestSize;
            curr=null;
            results = input.results;
        }

    }
}

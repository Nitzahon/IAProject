using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IATest
{
    [Serializable()]
    public class Lister
    {
        
        public string name { get; set; }
        
        public List<string> data { get; set; }
        
        public List<bool> isImage { get; set; }
        public Lister()
        {
            name = null;
            data = new List<string>();
            isImage = new List<bool>();
        }
        public Lister(string n,string[] t1, bool[] t2)
        {
            name = n;
            data = new List<string>(t1);
            isImage = new List<bool>(t2);
        }
        public Lister(string n, List<string> t1, List<bool> t2)
        {
            name = n;
            data = new List<string>(t1);
            isImage = new List<bool>(t2);
        }
        public Lister(Lister input)
        {
            name = input.name;
            data = new List<string>(input.data);
            isImage = new List<bool>(input.isImage);
        }
    }
}

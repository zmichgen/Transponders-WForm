using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trans

{

   

    public class Transp
    {
        public int id { get; set; }
        public List<String> channels { get; set; }
        public void AddChannel(String s)
        {
            this.channels.Add(s);
        }
    }









    
}

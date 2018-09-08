using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trans
{

    class ChList
    {
        public int Tr { get; set; }
        public String ChName { get; set; }
        public ChList(int tr,String ChName)
        {
            this.Tr = tr;
            this.ChName = ChName;
        }
    }

   
}

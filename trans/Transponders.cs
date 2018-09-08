using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trans
{
    public class Transponders
    {
        public List<Transp> Transpon{ get; set; }

        public Transponders(List<Transp> ltr)
        {
            this.Transpon = ltr;
        }

         public List<Transp> getTransp()
        {
            return this.Transpon;
        }

        public void ToConsole()
        {
            foreach (Transp o in this.Transpon)
            {
                Console.WriteLine(o.id);
                Console.WriteLine("---------------------");
                foreach (String s in o.channels)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("-----------------------");
            }


            Console.ReadLine();
            
        }
    }
}

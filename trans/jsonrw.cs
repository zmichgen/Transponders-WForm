using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;



namespace trans
{
    class jsonrw
    {
        public Transponders Read()
        {
            string json = File.ReadAllText("trans.json");
            List<Transp> data = JsonConvert.DeserializeObject<List<Transp>>(json);
            Transponders Tr = new Transponders(data);
            return Tr;
        }

        public List<Transp> getTr()
        {
            Transponders D = Read();
            List<Transp> Tr = D.getTransp();
                return Tr;
        }

        public void setTr(List<Transp> Tr)
        {

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(Tr, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("trans.json", output);

        }
    }
}

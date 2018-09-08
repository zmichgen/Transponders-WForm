using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trans
{
    public partial class Form1 : Form
    {
        private List<Transp> Transps;
        private List<String> oustr;
        private List<ChList> ChLists;
        private String ChannelName ="";
        int ind = 0;
        public void setList()
        {
            label1.Text = Transps.ElementAt(ind).id.ToString() + "000 KGz";
            listBox1.Items.Clear();
            foreach (String S in Transps.ElementAt(ind).channels)
            { listBox1.Items.Add(S); }

        }
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            jsonrw t = new jsonrw();
            ChLists = new List<ChList>();
            oustr = new List<String>();
            Transps = t.getTr();
            int q = 0;
            foreach(var O in Transps)
            {
                foreach(String S in O.channels)
                {
                    ChList chl = new ChList(q, S);
                    ChLists.Add(chl);
                    oustr.Add(S);
                }
                q++;
            }
            oustr.Sort();
            Button[] tb = new Button[20];
            for (var i = 0; i < Transps.Count; i++)
            {
                Transp d = Transps.ElementAt(i);
                tb[i] = new Button();
                tb[i].Location = new Point(8, 20 + i * 30);
                tb[i].Name = d.id.ToString();
                tb[i].Size = new Size(105, 23);
                tb[i].TabIndex = i;
                tb[i].Text = d.id.ToString()+"000 KGz";
                tb[i].Click += this.OnButtonClick;
                groupBox1.Controls.Add(tb[i]);
            }
            cB.DataSource = oustr;
           
            setList();
          
           
        }
        private void OnButtonClick(Object sender, EventArgs e)
        {
            ind = ((Button)sender).TabIndex;
            setList();

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            jsonrw t = new jsonrw();
            t.setTr(Transps);
        }
        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ChannelName = (String)listBox1.SelectedItem;
            textBox1.Text = ChannelName;
           
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Transps.ElementAt(ind).channels.Add(textBox1.Text);
                listBox1.Items.Add(textBox1.Text);
            }

        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                List<String> Str = new List<String>();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                foreach (String items in listBox1.Items)
                {
                    Str.Add(items);
                }
                Transps.ElementAt(ind).channels = Str;
                setList();
            }
               
                
            
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            String sta = cB.SelectedItem.ToString();

            foreach (var k in ChLists)
            {
                if (sta == k.ChName) { ind = k.Tr; }
            }
            setList();

        }
    }
}

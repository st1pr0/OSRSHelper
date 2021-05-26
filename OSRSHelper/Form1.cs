using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace OSRSHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string id;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = textBox1.Text.ToString();

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://secure.runescape.com/m=itemdb_oldschool/Old+school+bond/viewitem?obj=" + id);

            List<string> list = new List<string>();
            string itemPrice = "";

            foreach (var item in doc.DocumentNode.SelectNodes("//span"))
            {
                list.Add(item.InnerText);
            }

            for (int i = 0; i < list.Count; i++)
            {
                itemPrice = list[4];
            }

            Price.Text = itemPrice;

            pictureBox1.ImageLocation = "https://secure.runescape.com/m=itemdb_oldschool/1621861275137_obj_big.gif?id=" + id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.osrsbox.com/tools/item-search/");
        }
    }
}

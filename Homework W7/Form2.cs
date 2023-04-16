using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_W7
{
    public partial class Form2 : Form
    {
        public static int film = 0; int x1 = 0;
        string[] listmovie = Properties.Resources.listmovie.Split(',');
        List<List<string>> jamfilm = new List<List<string>>();
        List<List<Control>> sinting = null;
        List<string> jam1 = new List<string>() {"12:00 - 14:30", "15:00 - 17:30", "19:30 - 22:00"};
        List<string> jam2 = new List<string>() {"13:20 - 16:20", "17:35 - 18:35", "19:00 - 21:00"};
        List<string> jam3 = new List<string>() {"12:35 - 14:35", "17:35 - 18:35", "21:00 - 23:00"};
        List<string> jam4 = new List<string>() {"12:00 - 15:15", "16:45 - 19:45", "20:00 - 23:00"};
        List<string> jam5 = new List<string>() {"12:30 - 13:30", "15:15 - 16:55", "18:00 - 20:00"};
        List<string> jam6 = new List<string>() {"12:35 - 14:35", "13:20 - 16:20", "16:45 - 19:45" };
        List<string> jam7 = new List<string>() {"15:00 - 17:30", "17:35 - 18:35", "19:30 - 22:00" };
        List<string> jam8 = new List<string>() {"13:20 - 16:20", "15:15 - 16:55", "18:00 - 20:00" };
        public Form2()
        {
            InitializeComponent();
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            jamfilm.Add(jam1); jamfilm.Add(jam2); jamfilm.Add(jam3); jamfilm.Add(jam4); jamfilm.Add(jam5); jamfilm.Add(jam6); jamfilm.Add(jam7); jamfilm.Add(jam8);
            for (int i = 0; i < jamfilm[film].Count; i++)
            {
                Button a = new Button();
                a.AutoSize = true;
                a.Location = new Point(5, 5 + x1);
                a.Tag = i.ToString();
                a.Text = jamfilm[film][i];
                this.Controls.Add(a);
                a.Click += a_click;
                x1 += 25;
            }
            Button capek = new Button();
            capek.AutoSize = true;
            capek.Text = "OK";
            capek.Location = new Point(5, 85);
            this.Controls.Add(capek);
            capek.Click += ok_click;

            
        }

        int count = 0;
        int cek = 0;
        private void ok_click(object sender, EventArgs e)
        {
            MessageBox.Show(count + " tickets for " + listmovie[film] + "\nEnjoy your movie");
            for (int h = 0; h < sinting[cek].Count; h++)
            {
                if (sinting[cek][h].BackColor == Color.Yellow)
                {
                    sinting[cek][h].BackColor = Color.Red;
                    //Form1.gila[film][cek][h].BackColor = Color.Red;
                }
            }
        }
        private void a_click(object sender, EventArgs e)
        {
            //sinting = Form1.gila[film];
            Button b = sender as Button;
            cek = Convert.ToInt32(b.Tag);
            panel1.Controls.Clear();
            
            foreach (Control a in sinting[cek])
            {
                panel1.Controls.Add(a);
                if (a is Button)
                {
                    a.Click += kursi_click;
                }
            }
        }

        private void kursi_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            foreach (Control a in sinting[cek])
            {
                if (a is Button)
                {
                    if (a.Tag == b.Tag && a.BackColor != Color.Red)
                    {
                        a.BackColor = Color.Yellow;
                        count++;
                    }           
                }    
            }
        }
        private void Form2_Leave(object sender, EventArgs e)
        {
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vezbanje_Za_Okt2
{
    public partial class Form1 : Form
    {
        bool a1 = false, a2 = false, a3 = false;
        int brp;
        List<Class1> lista;


        public Form1()
        {
            InitializeComponent();
            lista = new List<Class1>();
            textBox4.Multiline = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String unos = textBox1.Text;
            if (unos != "" && unos[0] >= 'A' && unos[0] <= 'Z' && unos.Length > 1)
            {
                a1 = true;
                textBox1.BackColor = Color.LightGreen;
            }
            else if (unos == "")
            {
                a1 = false;
                textBox1.BackColor = Color.White;
            }
            else
            {
                a1 = false;
                textBox1.BackColor = Color.IndianRed;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int n))
            {
                if (n > 1 && (n % 1 == 0))
                {
                    a2 = true;
                    textBox2.BackColor = Color.LightGreen;
                    brp=n;
                }
                else
                {
                    a2 = false;
                    textBox2.BackColor = Color.IndianRed;
                }
            }
            else if (textBox2.Text == "")
            {
                a2 = false;
                textBox2.BackColor = Color.White;
            }
            else
            {
                MessageBox.Show("Greska pri unosu broja prijavljenih!!!");
                textBox2.Text = "";
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int n))
            {
                if (n < brp)
                {
                    a3 = true;
                    textBox3.BackColor = Color.LightGreen;
                }
                else
                {
                    a3 = false;
                    textBox3.BackColor = Color.IndianRed;
                }
            }
            else if (textBox3.Text == "")
            {
                a3 = false;
                textBox3.BackColor = Color.White;
            }
            else
            {
                MessageBox.Show("Greska pri unosu broja polozenih ispita!!!");
                textBox3.Text = "";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (a1 == true && a2 == true && a3 == true)
            {
                listBox1.Items.Clear();
                int.TryParse(textBox2.Text, out int n);
                int.TryParse(textBox3.Text, out int m);


                lista.Add(new Class1(textBox1.Text, n, m));

                for (int i = 0; i < lista.Count; i++)
                {
                    listBox1.Items.Add(lista[i]);
                }
            }
            else
            {
                MessageBox.Show("Niste pravilno uneli podatke!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int pomeraj = 70;
            Random rnd = new Random();
            for (int i = 0; i < lista.Count; i++)
            {
                int r = rnd.Next(256);
                int g = rnd.Next(256);
                int b = rnd.Next(256);

                int z;
                Button btn = new Button();
                btn.Top = 250;
                btn.Left = pomeraj;
                btn.Width = 60;
                btn.Height = 60;
                btn.BackColor = Color.FromArgb(r, g, b);
                btn.Text = lista[i].ToString();
                btn.Click += Btn_Click;
                btn.MouseEnter += Btn_MouseEnter;
                btn.MouseLeave += Btn_MouseLeave;
                z = i;
                pomeraj += 70;
                this.Controls.Add(btn);
            }
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button kliknutoDugme = sender as Button;
            kliknutoDugme.ForeColor = Color.Black;
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button kliknutoDugme = sender as Button;
            kliknutoDugme.ForeColor = Color.White;
        }


        private void Btn_Click(object sender, EventArgs e)
        {
            Button kliknutoDugme = sender as Button;
            string tekst = kliknutoDugme.Text;

            MatchCollection brojevi = Regex.Matches(tekst, @"\d+");

            int prvibroj = 0;
            int drugibroj = 0;

            foreach(Match broj in brojevi)
            {
                int trenutnibroj = int.Parse(broj.Value);

                if (prvibroj == 0)
                {
                    prvibroj = trenutnibroj;
                }
                else
                {
                    drugibroj = trenutnibroj;
                }
            }

            int razlika = prvibroj - drugibroj;
            MessageBox.Show("Broj palih ispita je: " + razlika.ToString(), tekst);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = File.Open("datoteka.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
          
            foreach (var item in listBox1.Items)
            {
                sw.WriteLine(item.ToString());
            }
           
            sw.Close();
            fs.Dispose();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fs = File.Open("datoteka.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            textBox4.Text = sr.ReadToEnd();

            sr.Close();
            fs.Dispose();
        }
    } 
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string words = textBox1.Text;
            bool radio_but_golos = radioButton1.Checked;
            bool radio_but_prygol = radioButton2.Checked;
            int[] count = {0,0,0,0,0};
            char[] c_ar = {'а','е','б','в','н'};
            for(int i = 0; i < words.Length; i++) for(int j = 0; j < 5; j++) if (words[i] == c_ar[j]) count[j]++;              
            if (radio_but_golos) MessageBox.Show($"{c_ar[0]}: {count[0]} {c_ar[1]}: {count[1]}");
            if(radio_but_prygol) MessageBox.Show($"{c_ar[2]}: {count[2]} {c_ar[3]}: {count[3]} {c_ar[4]}: {count[4]}");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string words = "ag123zzjtzkn1 преблаженний преподобний прекрасний гарний Славіктоп Славіктоп ag123zzjtzkn1";
        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string[] mass_words = words.Split(' ');
            foreach(string word in mass_words) if (word.IndexOf("пре") == 0) listBox2.Items.Add(word);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] mass_words = words.Split(' ');
            int count = 0;
            for(int i = 0; i < mass_words.Length; i++)
            {
                
                        count = 0;
                        for (int j = 0; j < mass_words.Length; j++)
                        {
                            if (mass_words[i] == mass_words[j]) count++;
                        }
                        for(int k = 0; k < mass_words.Length; k++)
                {
                    if (mass_words[i] == mass_words[k])
                        if (i != k) break;
                        else listBox1.Items.Add(count + "\t" + new string(mass_words[i].Reverse().ToArray()));
                }
                        
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string pattern = @"\bag\d{1,3}z.j[(t-z)|(k-n)]...\d";
            Match match = Regex.Match(words, pattern);
            if (match.Success)
            {
                label5.Text = $"'{match.Value}' found in the source code at position {match.Index}.";
            }

            Regex rx = new Regex(pattern,
              RegexOptions.Compiled | RegexOptions.IgnoreCase);


            MatchCollection matches = rx.Matches(words);

            label6.Text = $"'{matches[0].Value}' repeated at positions";

            foreach (Match dupa in matches)
            {
                GroupCollection groups = dupa.Groups;
                label6.Text += $"{groups[0].Index} ";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOD_NOK
{
    public partial class Form1 : Form
    {
        int[] Nums; int N;

        public Form1()
        {
            InitializeComponent();
        }

        private void Input()
        {   
            string[] Str = textBox1.Text.Split(' ').Where(x => x != "").ToArray();
            N = Str.Length;
            Nums = new int[N];
            for (int i = 0; i < N; i++) 
            {
                Nums[i] = int.Parse(Str[i]);
            }
            button2.Text = "НОД";
            button3.Text = "НОК";
        }
        
        int NOD(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        int NOK(int a, int b)
        {
            return Math.Abs(a * b) / NOD(a, b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Input();
            int res = Nums[0];
            if (N == 1) 
            { 
                button2.Text = Convert.ToString(res); 
                return; 
            }
            for (int i = 0; i < N; i++)
            {
                res = NOD(res, Nums[i]);
            }
            button2.Text = Convert.ToString(res);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Input();
            int res = Nums[0];
            if (N == 1) 
            { 
                button3.Text = Convert.ToString(res);
                return;
            }
            for (int i = 0; i < N; i++)
            {
                res = NOK(res, Nums[i]);
            }
            button3.Text = Convert.ToString(res);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(" ")) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
    }
}

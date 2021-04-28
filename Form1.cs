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
            if (N == 1) button2.Text = Convert.ToString(Nums[0]);
            if (N == 2) button2.Text = Convert.ToString(NOD(Nums[0], Nums[1]));
            for (int i = 0; i<N-2; i++)
            {
                button2.Text = Convert.ToString(NOD(NOD(Nums[i], Nums[i + 1]), Nums[i + 2]));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Input();
            if (N == 1) button3.Text = Convert.ToString(Nums[0]);
            if (N == 2) button3.Text = Convert.ToString(NOK(Nums[0], Nums[1]));
            for (int i = 0; i < N - 2; i++)
            {
                button3.Text = Convert.ToString(NOK(NOK(Nums[i], Nums[i + 1]), Nums[i + 2]));
            }
        }
    }
}

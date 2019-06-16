using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CourseWork
{
    public partial class Prog : Form
    {
        public Em2 Em2;
        public Prog()
        {
            InitializeComponent();
            Em2 = new Em2();
            try
            {
                Directory.CreateDirectory("programs");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Field.Text = "";

            Field.Text += Em2.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] field = Field.Text.Split('\n');
            List<string> output = new List<string>();

            for (int i = 0; i < field.Length - 1; i++)
            {
                string[] columns = field[i].Split(' ');

                Em2.Comand.Col[i] = columns[1];
                Em2.Registers[0].Col[i] = columns[2];
                Em2.Registers[1].Col[i] = columns[3];

                if (columns.Length == 5)
                {
                    Em2.Sign.Col[i] = columns[4];
                }

                if (columns.Length == 6)
                {
                    Em2.Sign.Col[i] = columns[4];
                    Em2.Type.Col[i] = columns[5];
                }
            }

            try
            {
                Em2.Actions(Input.Text.Split(' '), output);
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            } 

            Field.Text = "";

            Field.Text += Em2.ToString();

            if (output.Count != 0)
            {
                Output.Text = "";

                for (int i = 0; i < output.Count; i++)
                {
                    Output.Text += output[i] + ' ';
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Em2.ToZero();

            Field.Text = "";

            Field.Text += Em2.ToString();

            Input.Text = "";

            Output.Text = "";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText("programs/" + SavePath.Text + ".txt", Field.Text);
                MessageBox.Show("Saved.");
                SavePath.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                Field.Text = File.ReadAllText("programs/" + LoadPath.Text + ".txt");
                MessageBox.Show("Loaded");
                LoadPath.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            Reference reference = new Reference();
            reference.Show();
        }
    }
}

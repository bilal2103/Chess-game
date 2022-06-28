using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 gameWindow = new Form1();
            gameWindow._AI_or1_v_1(false);
            gameWindow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 gameWindow = new Form1();
            gameWindow._AI_or1_v_1(true);
            gameWindow.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace NetTWO_ThreadsREAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            stuff s = new stuff();
            //s.hi(); -> this creates an infinite loop
            Thread t = new Thread(new ThreadStart(s.hi)); //declares the thread, but hasn't started it yet
            t.Start();  //this starts the t thread (i.e. s.hi)


        }
    }
    public class stuff
    {
        public void hi()
        {
            while(true)
            {
                MessageBox.Show("Hi");
                Thread.Sleep(5000);
            }
            
        }
    }
}

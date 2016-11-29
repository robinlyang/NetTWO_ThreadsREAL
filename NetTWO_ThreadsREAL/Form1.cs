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

        public static int total = 0;
        //this will be used for LOCKING the threads to prevent one starting before another is complete
        //it can be any type (e.g., int), any number, any name, but it can't be null
        public static object obj = 1;
        // from notes: "-	-	Use Static Variable"
        public static string data = "";
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

        private void button2_Click(object sender, EventArgs e)
        {
            stuff s = new stuff();
            for (int i = 1; i <= 10; i++)
            {
                //s.addIt();
                Thread t = new Thread(new ThreadStart(s.addIt));
                t.Start();
            }
            Thread.Sleep(5000);
            MessageBox.Show(total.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stuff s = new stuff();
            Thread t = new Thread(new ThreadStart(s.greet));
            t.Name = "Hi from Program";  //this could be any variable
            t.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(data != "")
            {
                textBox1.Text = data;
                data = "";
            }
            
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
        public void addIt()
        {
            //never put the lock INSIDE of the for loop
            lock (Form1.obj) //this will synchronize the threads
            {
                for (int i = 1; i <= 50000000; i++)
                {
                    Form1.total = Form1.total + 1;
                }
            }
        }
        public void greet()  // from notes: "-	Use thread name"
        {
            Form1.data = "Stuff from thread";
            Thread id = Thread.CurrentThread;
            MessageBox.Show(id.Name);
        }
    }
}

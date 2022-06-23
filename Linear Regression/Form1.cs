using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linear_Regression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int dataCount;

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataCount = int.Parse(tbInputNumber.Text);
            }
            catch
            {
                MessageBox.Show("Masukkan nilai dengan benar!");
                return;
            }
            tbInputNumber.Text = "";

            label6.Text = dataCount.ToString() + " X " + dataCount.ToString();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            /*dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();*/

            //input x and y
            for (int i = 0; i <= 1; i++)
            {
                var column = new DataGridViewColumn();
                column.HeaderText = (i == 1 ? "Y" : "X" );
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.Width = 50;
                dataGridView1.Columns.Add(column);
            }



            for (int i = 0; i < dataCount; i++)
            {
                dataGridView1.Rows.Add();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] x_point = new double[dataCount];
            double[] y_point = new double[dataCount];

            for (int i = 0; i < dataCount; i++)
            {
                x_point[i] = double.Parse((string)dataGridView1.Rows[i].Cells[0].Value);
                y_point[i] = double.Parse((string)dataGridView1.Rows[i].Cells[1].Value);
                /*Console.Write(x_point[i]); Console.Write("\t");
                Console.Write(y_point[i]);
                Console.WriteLine();*/
            }
            linear_regression(x_point, y_point);



        }

        private void linear_regression(double[] _x_point, double[] _y_point)
        {
            int _data_count = _x_point.GetLength(0);
            double sumx = 0, sumy = 0, sumxy = 0, sumx2 = 0, st = 0, sr =0 ;

            for(int i= 0; i< _data_count; i++)
            {
                sumx += _x_point[i];
                sumy += _y_point[i];
                sumxy += (_x_point[i]*_y_point[i]);
                sumx2 += (_x_point[i] * _x_point[i]);
            }

            double xm = sumx / _data_count;
            double ym = sumy / _data_count;
            Console.WriteLine(xm);
            Console.WriteLine(ym);

            double a1 = ((_data_count * sumxy) - (sumx * sumy)) / ((_data_count * sumx2) - (sumx * sumx));
            double a0 = ym - a1 * xm;
            Console.WriteLine(a1);
            Console.WriteLine(a0);
            // y = a0+a1*x

            for (int i = 0; i < _data_count; i++)
            {
                st += ((_y_point[i] - ym) * (_y_point[i] - ym));
                sr += ((_y_point[i] - a1 * _x_point[i] - a0) * (_y_point[i] - a1 * _x_point[i] - a0));
            }
            double syx = Math.Sqrt((sr / (dataCount - 2)));
            double r2 = (st - sr) / st;
            double r = Math.Sqrt(r2);
            Console.WriteLine();
            Console.WriteLine(r2);
            Console.WriteLine(r);

            //show on user interface
            if (a0 > 0)
            {
                String formula = "y = " + a1.ToString() + "x +" + a0.ToString();
                label3.Text = formula;
            }
            else if(a0 <0)
            {
                String formula = "y = " + a1.ToString() + "x " + a0.ToString();
                label3.Text = formula;
            }else if(a0 == 0)
            {
                String formula = "y = " + a1.ToString() + "x ";
                label3.Text = formula;
            }
            label8.Text = syx.ToString();
            label9.Text = r.ToString();

            

            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }

}

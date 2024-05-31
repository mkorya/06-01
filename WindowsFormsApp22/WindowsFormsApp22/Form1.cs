// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp22
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                double x;
                double y;
                double b = 3.14;
                this.chart1.Series[0].Points.Clear();
                this.chart2.Series[0].Points.Clear();
                for (double i = -3.14; i < b; i += 0.01) 
                { 
                    double ft=(1+Math.Sin(i))*(1+0.9*Math.Cos(8*i))* (1 + 0.1 * Math.Cos(24 * i))*(0.9+0.05*Math.Cos(200*i));
                    x=ft*Math.Cos(i);
                    y=ft*Math.Sin(i);
                    this.chart1.Series[0].Points.AddXY(x,y);
                    this.chart3.Series[0].Points.AddXY(x, y);
                }
                for (double i = -10; i < 10; i += 0.1)
                {
                    if (i <= 0)
                    {
                        y = Math.Log(Math.Abs(i));
                        this.chart2.Series[0].Points.AddXY(i, y);
                        this.chart3.Series[0].Points.AddXY(i, y);
                    }
                    else if (0 < i && i < 3)
                    {
                        y = Math.Cos(i);
                        this.chart2.Series[0].Points.AddXY(i, y);
                        this.chart3.Series[0].Points.AddXY(i, y);
                    }
                    else 
                    {
                        y = Math.Pow(i,(-5 / 6));
                        this.chart2.Series[0].Points.AddXY(i, y);
                        this.chart3.Series[0].Points.AddXY(i, y);
                    }
                }
                for (double i = -7; i <=7; i += 0.1)
                {
                    if (Math.Abs(i) < 0.5 && Math.Abs(i) >= 0)
                    {
                        y = 2.25;
                        this.chart4.Series[0].Points.AddXY(i, y);
                        
                    }
                    else if (Math.Abs(i) >= 0.5 && Math.Abs(i) < 0.75)
                    {
                        y = 3*Math.Abs(i)+0.75;
                        this.chart4.Series[0].Points.AddXY(i, y);
                        
                    }
                    else if (Math.Abs(i) < 1 && Math.Abs(i) >= 0.75)
                    {
                        y = 9-8 * Math.Abs(i);
                        this.chart4.Series[0].Points.AddXY(i, y);
                       
                    }
                    else if (Math.Abs(i) >= 1 && Math.Abs(i) < 3)
                    {
                        y = 1.5-0.5*Math.Abs(i)-3*(Math.Sqrt(10)/7)*(Math.Sqrt(3-Math.Pow(i,2)+2*Math.Abs(i))-2);
                        this.chart4.Series[0].Points.AddXY(i, y);
                    }
                    else 
                    {
                        y =  3 * (Math.Sqrt(1-Math.Pow(i/7,2)));
                        this.chart4.Series[0].Points.AddXY(i, y);
                    }
                    if (Math.Abs(i) < 4 && Math.Abs(i) >= 0)
                    {
                        y = Math.Abs(i/2)-((3*Math.Sqrt(33)-7)/112)*Math.Pow(i,2)+ Math.Sqrt(1 - Math.Pow(Math.Abs(Math.Abs(i)-2)-1, 2)) - 3;
                        this.chart4.Series[1].Points.AddXY(i, y);

                    }
                    else
                    {
                        y = -3 * (Math.Sqrt(- Math.Pow(i / 7, 2)+1));
                        this.chart4.Series[1].Points.AddXY(i, y);
                    }
                }

            }
        }
    }
}

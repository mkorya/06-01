

namespace Графы
{
    public partial class Form1 : Form
    {


        Font font = new Font("Arial", 15, FontStyle.Regular);
        public List<int> x = new List<int>();
        public List<int> y = new List<int>();
        public List<string> name = new List<string>();
        int k = 0;
        int f = 0;
        int stolbec=0;
        int strok=0;

        public List<int> startx = new List<int>();
        public List<int> starty = new List<int>();
        public List<int> finishx = new List<int>();
        public List<int> finishy = new List<int>();


        public List<string> nameSvyaz = new List<string>();


        Point finish;
        Point start;


        public Form1()
        {
            InitializeComponent();
         
            
            name.Add("a"); name.Add("b"); name.Add("c"); name.Add("d"); name.Add("e"); name.Add("f"); name.Add("g"); name.Add("h"); name.Add("i"); name.Add("j"); name.Add("k"); name.Add("l"); name.Add("m"); name.Add("n"); name.Add("o"); name.Add("p"); name.Add("q"); name.Add("r"); name.Add("s"); name.Add("t"); name.Add("u"); name.Add("v"); name.Add("w"); name.Add("x"); name.Add("y"); name.Add("z");
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
                label1.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)

        {

            if (checkBox1.Checked==false) // вершины
            {
                Graphics g = this.CreateGraphics();
                int width = 28;
                int height = 28;
                g.DrawEllipse(Pens.Black, e.X - 15, e.Y - 15, width, height);
                x.Add(e.X); // сохраняем в массив координату х
                y.Add(e.Y); // сохраняем в массив координату y

                
                  
              
                if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) // подписываем буквы
                {
                    g.DrawString(name[k], font, Brushes.Black, e.X - 12, e.Y - 12);
                    k++;
                }
              

            }
           
            else  // линии 
            {
                label1.Visible = true;
                Graphics g = Graphics.FromHwnd(Handle);

               
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < x.Count; i++)
                    {
                        if (Math.Sqrt(Math.Pow(e.X - x[i], 2) + Math.Pow(e.Y - y[i], 2)) < 14) // если нажатая координата попадает в вершину(круг) то запоминаем координаты вершины
                        {
                            start = new Point(x[i], y[i]); // координаты первой вершины
                            startx.Add(x[i]);
                            starty.Add(y[i]);

                        }
                    }
                   
                 

                }
                if (textBox1.Text == "")
                { MessageBox.Show("Не присвоено имя связи", "Ошибка"); }

                if (e.Button == MouseButtons.Right)
                {
                    nameSvyaz.Add(textBox1.Text); //запоминаем подписи вершин
                    for (int i = 0; i < x.Count; i++)
                    {
                       
                        if (Math.Sqrt(Math.Pow(e.X - x[i], 2) + Math.Pow(e.Y - y[i], 2)) < 14) // если нажатая координата попадает в вершину(круг) то запоминаем координаты вершины
                        {
                            finish = new Point(x[i], y[i]); // координаты второй вершины
                            finishx.Add(x[i]);
                            finishy.Add(y[i]);

                        }
                        
                    }
                   

                  
                 
                    g.DrawLine(Pens.Red, start, finish); // рисуем линию между двумя вершинами
                    
                    for (int i = 0; i < startx.Count; i++) // подписываем имя связи
                    {
                            g.DrawString(nameSvyaz[i], font, Brushes.Black,(float)(startx[i]+finishx[i]) / 2, (float)(starty[i]+finishy[i]) / 2);     
                       
                    }
                      
                   
                }
                
            }
           
        }
       



        private void Button1_Click(object sender, EventArgs e)
        {
            int koltochek = x.Count;
            dataGridView1.Visible = true;
            dataGridView1.RowCount = koltochek+1;
            dataGridView1.ColumnCount = koltochek+1;

             List<int> mstrok = new List<int>();
             List<int> mstolb = new List<int>();

            for (int i = 0; i < koltochek; i++) 
            {
                dataGridView1.Rows[i+1].Cells[0].Value =name[i]; // заполняем вершины в строчки
                dataGridView1.Rows[0].Cells[i+1].Value =name[i]; // заполняем вершины в столбцы

               
                


            }
            for (int i = 0; i < finishx.Count; i++)
            {
                for (int j = 0; j < x.Count; j++)
                {
                    if (startx[i]==x[j])
                    {
                        strok = j + 1;
                        mstrok.Add(strok);
                    }

                    //dataGridView1.Rows[strok].Cells[stolbec].Value = "1";
            
                }
            }
            for (int i = 0; i < finishx.Count; i++)
            {
                for (int j = 0; j < x.Count; j++)
                {
                    if (finishx[i] == x[j])
                    {
                        stolbec = j + 1;
                        mstolb.Add(stolbec);
                    }
                }
            }






            for (int i = 0; i < mstolb.Count; i++)
            {
                dataGridView1.Rows[mstrok[i]].Cells[mstolb[i]].Value = "1";
                dataGridView1.Rows[mstolb[i]].Cells[mstrok[i]].Value = "1";
            }


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value==null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "0";
                    }
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e) // матрица инцидентности
        {
            dataGridView2.Visible = true;
            int koltochek = x.Count;
            dataGridView2.RowCount = koltochek + 1;
            dataGridView2.ColumnCount = finishx.Count+1;
            for (int i = 0; i < koltochek; i++)
            {
                dataGridView2.Rows[i + 1].Cells[0].Value = name[i]; 
            }
            for (int i = 0; i < nameSvyaz.Count; i++)            //Заполнили датагридвью
            {
                dataGridView2.Rows[0].Cells[i+1].Value = nameSvyaz[i];
            }


            for (int i = 0; i < startx.Count; i++)
            {
                for (int j = 0; j < x.Count; j++)
                {
                    if (startx[i] == x[j] ) // если начало линии совпадает с координатой вершины
                    {
                        dataGridView2.Rows[i+1].Cells[j+1].Value = "1";
                    }
                    if (finishx[i] == x[j]) //если конец линии совпадает с координатой вершины
                    {
                        dataGridView2.Rows[j + 1].Cells[i + 1].Value = "1";
                    }
                }
               
            }


           



       





        

    }

    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


     
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_means_project
{
    public partial class Form1 : Form
    {
        Bitmap buffer;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;           // вид границы рабочей области
            pictureBox1.BackColor = Color.White;                         // белый фон рабочей области
            buffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);  // экземпляр класса Bitmap размером с рабочую область
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int shape_size      = 10;      // размер фигуры (диаметр окружности)
        int centroid_size   = 4;       // размер фигур центроидов (сторона квадрата)
        int k;                         // k - количество кластеров (задаётся пользователем)
        int iteration_count = 0;       // счётчик итераций алгоритма k-means 

        List<Element> Elements = new List<Element>();  // список элементов
        List<Cluster> Clusters = new List<Cluster>();  // список кластеров
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // 1 - Получить координаты клика
            MouseEventArgs me = (MouseEventArgs)e;
            Elements.Add(new Element(me.Location));

            // 2 - Нарисовать элемент
            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.DrawEllipse(Pens.Red, Elements[Elements.Count - 1].coordinates.X - shape_size/2, Elements[Elements.Count - 1].coordinates.Y - shape_size/2, shape_size, shape_size);  // поправка на размер фигуры (чтобы на месте клика был центр фигуры, а не начало)
            }
            pictureBox1.BackgroundImage = buffer;  // собственно рисование
            pictureBox1.Refresh();                 // обеспечение отображения предыдущих фигур

            // 3 - Активировать/деактивировать кнопку "Пуск"
            k_check();

            // 4 - Обновить инфоормацию о количестве элементов
            label_element_count_2.Text = Convert.ToString(Elements.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;          // исключить возможность дальнейшего нажатия на рабочую область (добавления элементов после начала анализа)
            k_select.Enabled    = false;          // исключить возможность изменения количества кластеров
            k = Convert.ToInt32(k_select.Value);  // зафиксировать введённое пользователем значение k

            k_means();  // кластеризация

            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.Clear(pictureBox1.BackColor);
                Pen multicolor = new Pen(Brushes.Black);

                // рисуем элементы
                for (int i = 0; i < Elements.Count; i++)
                {
                    multicolor.Color = Clusters[Elements[i].cluster].color;
                    g.DrawEllipse(multicolor, Elements[i].coordinates.X - shape_size / 2, Elements[i].coordinates.Y - shape_size / 2, shape_size, shape_size);  // поправка на размер фигуры (чтобы на месте клика был центр фигуры, а не начало)
                }

                // рисуем центроиды
                for (int j = 0; j < k; j++)
                {
                    multicolor.Color = Clusters[j].color;
                    g.DrawRectangle(multicolor, Clusters[j].centroid.X - centroid_size / 2, Clusters[j].centroid.Y - centroid_size / 2, centroid_size, centroid_size);
                }
            }

            pictureBox1.Refresh(); // собственно рисование
            label_iteration_count_2.Text = Convert.ToString(iteration_count);  // отобразить информацию о номере итерации
        }

        public void k_means()
        {
            // первая итерация: задание начальных центроидов
            if (iteration_count == 0)
            {
                initialize_centroids();  // инициализация центроидов    
                assign_points();         // первоначальное отнесение точек к кластерам
            }
            // вторая и последующая итерации
            else
            {
                if (!move_centroids())  // перемещение центроидов
                {
                    label_state_2.Text = "Кластеризация завершена";
                    button1.Enabled = false;
                    return;
                }
                assign_points();  // отнесение точек к кластерам (с учётом сдвинувшихся центроидов)
            }
            label_state_2.Text = "готов к следующей итерации (нажмите \"Пуск\")";
            iteration_count++;
        }

        // I - инициализация центроидов
        public void initialize_centroids()
        {
            Random random1 = new Random();

            int optimization_attempts_remaining = 50;
            do
            {
                Point random_centroid;
                for (int j = 0; j < k; j++)
                {
                    do
                    {
                        random_centroid = Elements[random1.Next(0, Elements.Count)].coordinates;
                    } while (Clusters.Any(cluster => cluster.centroid == random_centroid)); // проверяем, была ли уже назначена данная точка центроидом какого-либо кластера
                    
                    Clusters.Add(new Cluster(random_centroid, assign_colour(j)));
                }
            } while (centroid_optimization_required( (double)(--optimization_attempts_remaining) / 100 ));
        }

        // II - перемещение центроидов
        public bool move_centroids()
        {
            bool centroids_moved = false;  // флаг смещения центроидов (для определения завершения процесса кластеризации)
            for (int j = 0; j < k; j++)
                {
                    int count = 0;
                    int x_sum = 0;
                    int y_sum = 0;

                    // ищем среднюю точку для точек, относящихся к кластеру данного центроида
                    for (int i = 0; i < Elements.Count; i++)
                    {
                        if (Elements[i].cluster == j) // если данная (i-я) точка принадлежит к данному (j-му) кластеру 
                        {
                            x_sum += Elements[i].coordinates.X;
                            y_sum += Elements[i].coordinates.Y;
                            count++;
                        }
                    }
                    // сдвигаем центроид в найденную точку
                    Point new_centroid = new Point(x_sum / count, y_sum / count);
                    if (Clusters[j].centroid != new_centroid)
                    {
                        Clusters[j].centroid = new_centroid;
                        centroids_moved = true;  // зафиксировано смещение центроидов - возможно, потребуется ещё одна итерация
                    }      
                }
            return centroids_moved;
        }

        // III - отнесение элементов к кластерам
        public void assign_points()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                double min_dist = Double.MaxValue;
                for (int j = 0; j < k; j++)
                {
                    int x_dist = Elements[i].coordinates.X - Clusters[j].centroid.X;
                    int y_dist = Elements[i].coordinates.Y - Clusters[j].centroid.Y;
                    double dist = Math.Sqrt(x_dist * x_dist + y_dist * y_dist);

                    if (dist < min_dist)
                    {
                        min_dist = dist;
                        Elements[i].cluster = j;
                    }
                }
            }
        }

        // IV - генератор цветов
        public Color assign_colour(int cluster_number)
        {
            Random colour_randomizer = new Random(Environment.TickCount);

            if      (cluster_number == 0)
                return Color.FromArgb(255, 0, 0);
            else if (cluster_number == 1)
                return Color.FromArgb(0, 0, 255);
            else if (cluster_number == 2)
                return Color.FromArgb(0, 255, 0);
            else
                return Color.FromArgb(colour_randomizer.Next(80, 200), colour_randomizer.Next(80, 200), colour_randomizer.Next(80, 200));
        }

        public bool centroid_optimization_required(double threshold)
        {
            double centroid_min_dist = Double.MaxValue;
            for (int j = 0; j < k - 1; j++)
            {                
                for (int l = j + 1; l < k; l++)
                {
                    int x_dist = Clusters[j].centroid.X - Clusters[l].centroid.X;
                    int y_dist = Clusters[j].centroid.Y - Clusters[l].centroid.Y;
                    double dist = Math.Sqrt(x_dist * x_dist + y_dist * y_dist);

                    if (dist < centroid_min_dist)
                        centroid_min_dist = dist;
                }
            }

            if (centroid_min_dist < threshold * Math.Sqrt(pictureBox1.Width * pictureBox1.Width + pictureBox1.Height * pictureBox1.Height))
            {
                Clusters.Clear();
                return true;
            }
            else
                return false;
        }

        public void k_check()
        {
            // проверка допустимости заданного пользователем значения k
            if (Convert.ToInt32(k_select.Value) <= Elements.Count)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void k_select_ValueChanged(object sender, EventArgs e)
        {
            k_check();
        }

        private void button_start_anew_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }
    }

    // класс кластеризуемых элементов (точек)
    public class Element
    {
        public Point coordinates { get; set; }  // координаты точки (задаются кликом)
        public int cluster { get; set; }        // принадлежность кластеру

        public Element(Point click_coordinates)
        {
            coordinates = click_coordinates;
            cluster = 0;
        }
    }
    public class Cluster
    {
        public Point centroid { get; set; }
        public Color color { get; set; }

        public Cluster(Point centroid_coordinates, Color cluster_color)
        {
            centroid = centroid_coordinates;
            color = cluster_color;
        }
    }
}



    
    
    
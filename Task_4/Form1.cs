using System;
using System.Drawing;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

/*Разработать приложение, созданное на основе форме. 
 ■ Пользователь «щелкает» левой кнопкой мыши по форме и, не отпуская кнопку, ведет по ней мышку, а в момент отпу-
скания кнопки по полученным координатам прямоугольника (вам, конечно, известно, что двух точек на плоскости 
достаточно для создания прямоугольника) необходимо создать «статик», который содержит свой порядковый номер 
(имеется в виду порядок появления на форме). 
 ■ Минимальный размер «статика» составляет 10х10, при попытке создания элемента меньших размеров пользователь 
должен увидеть соответствующее предупреждение. 
 ■ При  щелчке  правой  кнопкой  мыши  над  поверхностью «статика»  в  заголовке  окна  должна  появиться  информа-
ция о его площади и координатах (относительно формы). В случае, если в точке щелчка находится несколько «ста-
тиков», то предпочтение отдается «статику» с наибольшим порядковым номером. */

namespace Task_4
{
    public partial class Form1 : Form
    {
        int X { get; set; }
        int Y { get; set; }
        int numStatic { get; set; } = 1;
        const int minSize = 10;

        public Form1()
        {
            InitializeComponent();
            MouseDown += MouseLeftButtonDown;
            MouseUp += MouseLeftButtonUp;
        }

        void MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                X = e.X;
                Y = e.Y;
            }
        }

        void MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label label = new Label();

                label.Location = CheckPositionLabel(X, Y, label, e);

                if (IsCreate(X, Y, minSize, e))
                {
                    MessageError($"Невозможно создать «статик» меньше чем {minSize}x{minSize}");
                }
                else
                {
                    CreateLabel(label, e);
                }
            }
            else
            {
                MessageError("Для создания «статика» нажмите левую кнопку мышки");
            }
        }

        /// <summary>
        /// Выводит сообщение об ошибке
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        void MessageError(string text)
        {
            MessageBox.Show(text, @"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Проверка координат для создания Label
        /// </summary>
        /// <param name="x">координата x</param>
        /// <param name="y">координата y</param>
        /// <param name="label">Создаваемый Label</param>
        /// <param name="e">Событие мыши</param>
        /// <returns></returns>
        Point CheckPositionLabel(int x, int y, Label label, MouseEventArgs e)
        {
            if (e.X > x && e.Y > y)
            {
                label.Location = new Point(x, y);
            }
            else if (e.X > x && e.Y < y)
            {
                label.Location = new Point(x, e.Y);
            }
            else if (e.X < x && e.Y < y)
            {
                label.Location = new Point(e.X, e.Y);
            }
            else
            {
                label.Location = new Point(e.X, y);
            }

            return label.Location;
        }

        /// <summary>
        /// Проверка размера
        /// </summary>
        /// <param name="x">координата x</param>
        /// <param name="y">координата y</param>
        /// <param name="minSize">минимальный размер</param>
        /// <param name="e">событие мыши</param>
        /// <returns>true, если размер > minSize, иначе false</returns>
        bool IsCreate(int x, int y, int minSize, MouseEventArgs e)
        {
            return Math.Abs(e.X - x) <= minSize || Math.Abs(e.Y - y) <= minSize;
        }

        /// <summary>
        /// Создание Label
        /// </summary>
        /// <param name="label">label</param>
        /// <param name="e">событие мыши</param>
        void CreateLabel(Label label, MouseEventArgs e)
        {
            label.BorderStyle = BorderStyle.Fixed3D;
            label.Size = new Size(Math.Abs(e.X - X), Math.Abs(e.Y - Y));
            label.Text = $"{numStatic}";
            label.ForeColor = Color.White;
            label.BackColor = Color.Red;
            Controls.Add(label);//Добавление нового статика в коллекцию элементов управления.
            Text = $"«Статик» номер №{label.Text} создан!";
            label.MouseClick += LabelMouseClickRight;//подписываем на два события для статика
            label.MouseDoubleClick += LabelMouseDoubleClickLeft;
            numStatic++;
        }

        /// <summary>
        /// вывод площади и координат
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LabelMouseClickRight(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (Label item in Controls)
                {
                    Point location = item.PointToScreen(Point.Empty);
                    if (MousePosition.X > location.X && MousePosition.X < location.X + item.Width && MousePosition.Y > location.Y && MousePosition.Y < location.Y + item.Height)
                    {
                        Text = $"«Статик» номер №{item.Text}, Площадь {item.Width * item.Height}, Координаты Х = {item.Location.X} Y = {item.Location.Y}";
                    }
                }
            }
        }

        /// <summary>
        /// удаление Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LabelMouseDoubleClickLeft(object sender, MouseEventArgs e)
        {
            int numLabel = numStatic;
            if (e.Button == MouseButtons.Left)
            {
                foreach (Label item in Controls)
                {
                    Point location = item.PointToScreen(Point.Empty);
                    if (MousePosition.X > location.X && MousePosition.X < location.X + item.Width && MousePosition.Y > location.Y && MousePosition.Y < location.Y + item.Height)
                    {
                        if (numLabel > Convert.ToInt32(item.Text))
                        {
                            numLabel = Convert.ToInt32(item.Text);
                        }
                    }
                }
                foreach (Label item in Controls)
                {
                    if (numLabel == Convert.ToInt32(item.Text))
                    {
                        Text = $"«Статик» с номер №{item.Text} удалён!";
                        Controls.Remove(item);
                        item.MouseClick -= LabelMouseClickRight;
                        item.MouseDoubleClick -= LabelMouseDoubleClickLeft;
                    }
                }
            }
        }
    }
}

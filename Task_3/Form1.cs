using System;
using System.Drawing;
using System.Windows.Forms;

/*Представьте, что у вас на форме есть прямоугольник, границы которого на 10 пикселей отстоят от границ рабочей области формы.
 Необходимо создать следующие обработчики:
 ■ Обработчик нажатия левой кнопки мыши, который выводит  сообщение  о  том,  где  находится  текущая  точка:
внутри прямоугольника, снаружи, на границе прямоугольника. Если при нажатии левой кнопки мыши была нажата кнопка
Control (Ctrl), то приложение должно закрываться;
 ■ Обработчик нажатия правой кнопки мыши, который выводит в заголовок окна информацию о размере клиентской
(рабочей) области окна в виде: Ширина = x, Высота = y, где x и y – соответствующие параметры вышего окна;
 ■ Обработчик перемещения указателя мыши в пределах рабочей области, который должен выводить в заголовок окна
текущие координаты мыши x и y. */

namespace Task_3
{
    public partial class Form1 : Form
    {
        private new const int Margin = 10;
        private Rectangle _rectangle;

        public Form1()
        {
            InitializeComponent();
            UpdateRectangle();
            MouseMove += MouseMovement;
            MouseClick += FormMouseClick;
            Resize += FormResize;
        }

        private void UpdateRectangle()
        {
            _rectangle = new Rectangle(Margin, Margin, ClientSize.Width - 2 * Margin, ClientSize.Height - 2 * Margin);
        }

        private void FormResize(object sender, EventArgs e)
        {
            UpdateRectangle();
            Invalidate(); // Принудительно перерисовать форму
        }

        private void FormMouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left when ModifierKeys == Keys.Control:
                    Close();
                    break;
                case MouseButtons.Left:
                {
                    string message;
                    if (_rectangle.Contains(e.Location))
                        message = "Внутри";
                    else if (IsOnBorder(e.Location, _rectangle))
                        message = "На границе";
                    else
                        message = "Снаружи";
                    ShowMessageBox(message);
                    break;
                }
                case MouseButtons.Right:
                    Text = $@"Ширина = {ClientSize.Width}, Высота = {ClientSize.Height}";
                    break;
                case MouseButtons.None:
                case MouseButtons.Middle:
                case MouseButtons.XButton1:
                case MouseButtons.XButton2:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MouseMovement(object sender, MouseEventArgs e)
        {
            Text = $@"Координаты мыши: x = {e.X}, y = {e.Y}";
        }

        private static bool IsOnBorder(Point point, Rectangle rect)
        {
            return ((point.X == rect.Left || point.X == rect.Right - 1) && point.Y >= rect.Top &&
                    point.Y <= rect.Bottom - 1) ||
                   ((point.Y == rect.Top || point.Y == rect.Bottom - 1) && point.X >= rect.Left &&
                    point.X <= rect.Right - 1);
        }

        /// <summary>
        /// Выводит MessageBox
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        private static void ShowMessageBox(string text)
        {
            MessageBox.Show(text, @"Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        string text = string.Empty;
        const int margin = 10;

        public Form1()
        {
            InitializeComponent();
            MouseMove += MouseMovement;
            MouseClick += MouseClickButtonLeft;
            MouseClick += MouseClickButtonRight;
        }

        private void MouseClickButtonLeft(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Control)
                {
                    Close();
                }

                if ((e.X < margin || e.X > Width - margin) || (e.Y < margin || e.Y > Height - margin))
                {
                    text = "Снаружи";
                }
                else if ((e.X == margin || e.X == Width - margin) || (e.Y == margin || e.Y == Height - margin))
                {
                    text = "На границе";
                }
                else
                {
                    text = "Внутри";
                }
                ShowMessageBox(text);
            }
        }

        void MouseClickButtonRight(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Text = $"Ширина = {Width}, Высота = {Height}";
                Thread.Sleep(2000);
            }
        }

        void MouseMovement(object sender, MouseEventArgs e)
        {
            Text = $"X {e.X} - Y {e.Y}";
        }

        /// <summary>
        /// Выводит MessageBox
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        void ShowMessageBox(string text)
        {
            MessageBox.Show(text, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

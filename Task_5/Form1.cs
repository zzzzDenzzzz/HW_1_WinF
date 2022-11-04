using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Разработать приложение «убегающий статик»:) Суть приложения: на  форме  расположен  статический  элемент  управления  («статик»). 
Пользователь пытается подвести курсор мыши к «статику», и, если курсор находиться близко со статиком, элемент управления «убега-
ет». Предусмотреть перемещение «статика» только в пределах формы. */

namespace Task_5
{
    public partial class Form1 : Form
    {
        Label label;
        int margin = 20;
        int offset = 10;

        public Form1()
        {
            InitializeComponent();
            label = new Label();
            Load += CreateLabel;
            MouseMove += FormMouseMove;
        }

        /// <summary>
        /// создание label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CreateLabel(object sender, EventArgs e)
        {
            label.BorderStyle = BorderStyle.Fixed3D;
            label.Size = new Size(80, 40);
            label.Text = $"Я «статик»";
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = false;
            label.ForeColor = Color.White;
            label.BackColor = Color.Red;
            Controls.Add(label);
            LableCenter(label);
        }

        /// <summary>
        /// движение мыши по Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormMouseMove(object sender, MouseEventArgs e)
        {
            if ((e.X > label.Location.X - margin && e.X < label.Location.X + label.Width + margin)
                && (e.Y > label.Location.Y - margin && e.Y < label.Location.Y + label.Height + margin))
            {
                if (e.X > label.Location.X - margin && e.X < label.Location.X)//движение курсора слева по оси X
                {
                    label.Left += offset;
                }
                else if (e.X < label.Location.X + label.Width + margin && e.X > label.Location.X + label.Width)//движение курсора с права по оси X
                {
                    label.Left -= offset;
                }
                else if (e.Y > label.Location.Y - margin && e.Y < label.Location.Y)//движение курсора сверху по оси Y
                {
                    label.Top += offset;
                }
                else if (e.Y < label.Location.Y + label.Height + margin && e.Y > label.Location.Y + label.Height)//движение курсора снизу по оси Y
                {
                    label.Top -= offset;
                }
                //Проверка границ окна и возврат «статика» в центр
                if ((label.Location.X < 0 || label.Location.X > ClientSize.Width - label.Width) || (label.Location.Y < 0 || label.Location.Y > ClientSize.Height - label.Height))
                {
                    LableCenter(label);
                }
            }
        }

        /// <summary>
        /// центрирование Label
        /// </summary>
        /// <param name="lable">label</param>
        void LableCenter(Label lable)
        {
            label.Left = (Width - label.Size.Width) / 2;
            label.Top = (Height - label.Size.Height) / 2;
        }
    }
}

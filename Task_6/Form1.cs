using System;
using System.Windows.Forms;

/*Написать программу, которая по введенной дате определяет день 
недели. Результат выводить в текстовое поле (желательно по-русски). */

namespace Task_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dayOfWeekButton_Click(object sender, EventArgs e)
        {
            outputTextBox.Text = Translete(DateTime.Parse(inputTextBox.Text));
        }

        /// <summary>
        /// перевод названия дня недели с англ. на русский
        /// </summary>
        /// <param name="dateTime">день недели</param>
        /// <returns>день недели на русском</returns>
        string Translete(DateTime dateTime)
        {
            string dayOfWeek = string.Empty;

            try
            {
                switch (dateTime.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        dayOfWeek = "Воскресенье";
                        break;
                    case DayOfWeek.Monday:
                        dayOfWeek = "Понедельник";
                        break;
                    case DayOfWeek.Tuesday:
                        dayOfWeek = "Вторник";
                        break;
                    case DayOfWeek.Wednesday:
                        dayOfWeek = "Среда";
                        break;
                    case DayOfWeek.Thursday:
                        dayOfWeek = "Четверг";
                        break;
                    case DayOfWeek.Friday:
                        dayOfWeek = "Пятница";
                        break;
                    case DayOfWeek.Saturday:
                        dayOfWeek = "Суббота";
                        break;
                }
            }
            catch (Exception)
            {
                dayOfWeek = "Error";
            }
            
            return dayOfWeek;
        }
    }
}

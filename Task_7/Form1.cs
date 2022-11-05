using System;
using System.Windows.Forms;

/*Написать  программу,  вычисляющую  сколько  осталось  времени до указанной даты (дата вводится с клавиатуры в Edit).
 Предусмотреть возможность выдачи результата в годах, месяцах, днях, минутах, секундах (для первых двух вариантов ответ дробный).
 Для переключения  между  вариантами  желательно  использовать  переключатели (RadioButton).*/

namespace Task_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timeSpanButton_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan ts = new TimeSpan();
                DateTime inputDateTime = DateTime.Parse(inputTextBox.Text);
                ts = inputDateTime - DateTime.Now;

                if (inputDateTime > DateTime.Now)
                {
                    if (yearRadioButton.Checked)
                    {
                        outputTextBox.Text = YearSpan(ts);
                    }
                    else if (monthRadioButton.Checked)
                    {
                        outputTextBox.Text = MonthSpan(ts);
                    }
                    else if (dayRadioButton.Checked)
                    {
                        outputTextBox.Text = DaySpan(ts);
                    }
                    else if (minuteRadioButton.Checked)
                    {
                        outputTextBox.Text = MinutesSpan(ts);
                    }
                    else if (secondRadioButton.Checked)
                    {
                        outputTextBox.Text = SecondsSpan(ts);
                    }
                    else
                    {
                        ;
                    }
                }
                else
                {
                    outputTextBox.Text = "Error";
                }
            }
            catch (Exception)
            {
                outputTextBox.Text = "Error";
            }
        }

        /// <summary>
        /// интервал в годах
        /// </summary>
        /// <param name="timeSpan">разница между заданной датой и текущей</param>
        /// <returns>результат в годах</returns>
        string YearSpan(TimeSpan timeSpan)
        {
            return (timeSpan.TotalDays / 365).ToString();
        }

        /// <summary>
        /// интервал в месяцах
        /// </summary>
        /// <param name="timeSpan">разница между заданной датой и текущей</param>
        /// <returns>результат в месяцах</returns>
        string MonthSpan(TimeSpan timeSpan)
        {
            return (timeSpan.TotalDays / 30).ToString();
        }

        /// <summary>
        /// интервал в днях
        /// </summary>
        /// <param name="timeSpan">разница между заданной датой и текущей</param>
        /// <returns>результат в днях</returns>
        string DaySpan(TimeSpan timeSpan)
        {
            return ((int)timeSpan.TotalDays).ToString();
        }

        /// <summary>
        /// интервал в минутах
        /// </summary>
        /// <param name="timeSpan">разница между заданной датой и текущей</param>
        /// <returns>результат в минутах</returns>
        string MinutesSpan(TimeSpan timeSpan)
        {
            return ((int)timeSpan.TotalMinutes).ToString();
        }

        /// <summary>
        /// интервал в секундах
        /// </summary>
        /// <param name="timeSpan">разница между заданной датой и текущей</param>
        /// <returns>результат в секундах</returns>
        string SecondsSpan(TimeSpan timeSpan)
        {
            return ((int)timeSpan.TotalSeconds).ToString();
        }
    }
}

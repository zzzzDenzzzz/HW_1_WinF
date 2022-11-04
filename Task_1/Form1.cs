using System;
using System.Windows.Forms;

/* Вывести на экран свое (краткое!!!) резюме с помощью последовательности MessageBox’ов (числом не менее трех). Причем на заголовке 
последнего должно отобразиться среднее число символов на странице (общее количество символов в резюме / количество MessageBox’ов). */

namespace Task_1
{
    public partial class Form1 : Form
    {
        string[] resume = { "Горохов Денис", "Краткое резюме", "Какой - то текст" };
        const string titleMessageBox_1 = "Message №";
        const string titleMessageBox_2 = "Среднее число символов на сранице";

        public Form1()
        {
            InitializeComponent();
            Shown += ShowMessageBox;
        }

        void ShowMessageBox(object sender, EventArgs e)
        {
            int averageNumberOfCharacters = (CounterSymbols(resume) + titleMessageBox_1.Length) / resume.Length;

            for (int i = 0; i < resume.Length; i++)
            {
                MessageBox.Show(resume[i], TitleMessageBox(titleMessageBox_1, i + 1), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            MessageBox.Show(averageNumberOfCharacters.ToString(), titleMessageBox_2, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Считаем количество символов в тексте
        /// </summary>
        /// <param name="text">Текст</param>
        /// <returns>Количество символов</returns>
        int CounterSymbols(string[] text)
        {
            int counterSymbols = 0;

            for (int i = 0; i < text.Length; i++)
            {
                counterSymbols += text[i].Length;
            }

            return counterSymbols;
        }

        /// <summary>
        /// Формирует заголовок MessageBox
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="number">Номер заголовка</param>
        /// <returns>Заголовок MessageBox</returns>
        string TitleMessageBox(string text, int number)
        {
            string title = string.Empty;

            return title += $"{text} {number}"; ;
        }
    }
}

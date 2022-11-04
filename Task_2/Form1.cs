using System;
using System.Windows.Forms;

/*Написать  функцию,  которая  «угадывает»  задуманное  пользователем число от 1 до 2000. Для запроса к пользователю использовать 
MessageBox.  После  того,  как  число  отгадано,  необходимо  вывести количество  запросов,  потребовавшихся  для  этого,  и  предоставить 
пользователю возможность сыграть еще раз, не выходя из программы (MessageBox’ы оформляются кнопками и значками соответственно ситуации). */

namespace Task_2
{
    public partial class Form1 : Form
    {
        // счетчик попыток
        int attemptCounter = 0;
        Random randomNumber;
        const int minNumber = 1;
        const int maxNumber = 2000;

        public Form1()
        {
            randomNumber = new Random();
            InitializeComponent();
            Shown += Game;
        }

        void Game(object sender, EventArgs e)
        {
            while (true)
            {
                attemptCounter++;
                if (QuestionNumber(randomNumber) == DialogResult.Yes)
                {
                    Win(attemptCounter);

                    if (ExitGame() == DialogResult.No)
                    {
                        Close();
                    }
                    else
                    {
                        attemptCounter = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Запрос о выходе из игры
        /// </summary>
        /// <returns>Да Нет</returns>
        DialogResult ExitGame()
        {
            return MessageBox.Show($"Хотите продолжить?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Программа угадывает число
        /// </summary>
        /// <param name="randomNumber">Случайное число</param>
        /// <returns>Да Нет</returns>
        DialogResult QuestionNumber(Random randomNumber)
        {
            return MessageBox.Show(randomNumber.Next(minNumber, maxNumber).ToString(), "Вы загадали число", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Программа успешно угадала число
        /// </summary>
        /// <param name="count">Количество попыток</param>
        void Win(int count)
        {
            MessageBox.Show($"Количество попыток {count}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

﻿using System;
using System.Windows.Forms;

/*
Владелец автозаправки «BestOil» заказал следующую программу. Когда автозаправка только начинает свою деятельность, 
владелец обычно хочет получать максимально большой доход, который планирует увеличить за счет 
дополнительных услуг.Поэтому на автозаправке будет действовать небольшое кафе.Но, в то же время он может
нанять только одного работника на должность кассира, а потому назначение программы – учет продаж бензина и 
ассортимента товаров в миникафе.*/

namespace Task_8
{
    public partial class Form1 : Form
    {
        double PayGasStation { get; set; } = 0;              // сумма покупки топлива
        double PayCafe { get; set; } = 0;                    // сумма покупки в кафе
        double PayTotal { get; set; } = 0;                   // общая сумма
        double cHot, cHam, cCol, cFri = 0;                   // переменные для хранения кол-во товаров кафе
        double[] oil = { 46.70, 50.20, 51.50, 54.70, 20.90 };// цена топлива
        int tempTimer = 0;                                   // итератор таймера

        public Form1()
        {
            InitializeComponent();
            Load += FormLoad;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            comboBoxFuel.SelectedIndex = 0;                  // выбор определенного вида горючего
            textBoxFuelPrice.Text = $"{oil[0]}";             // цена на данный вид продукта

            //переключение кнопок RadioButton
            radioButtonCount.CheckedChanged += RadioButtonCheckedChanged;
            radioButtonSum.CheckedChanged += RadioButtonCheckedChanged;

            //сооб. выбора топлива
            comboBoxFuel.SelectedValueChanged += ComboBoxFuel_SelectedValueChanged;

            //сооб. при входе на текстовое поле и выходе из него
            textBoxRadioCount.Enter += TextBox_Enter;
            textBoxRadioCount.Leave += TextBox_Leave;
            textBoxRadioSum.Enter += TextBox_Enter;
            textBoxRadioSum.Leave += TextBox_Leave;
            HotDogCount.Enter += TextBox_Enter;
            HotDogCount.Leave += TextBox_Leave;
            FrenchFriesCount.Enter += TextBox_Enter;
            FrenchFriesCount.Leave += TextBox_Leave;
            CokoColaCount.Enter += TextBox_Enter;
            CokoColaCount.Leave += TextBox_Leave;
            HamburgerCount.Enter += TextBox_Enter;
            HamburgerCount.Leave += TextBox_Leave;

            //сооб. изменения значений в полях покупки топлива и подсчет суммы
            textBoxRadioCount.TextChanged += Radio_TextChanged;
            textBoxRadioSum.TextChanged += Radio_TextChanged;

            //сооб. CheckBox-сов и изменение значений полей ReadOnly
            HotDogCheckBox.CheckedChanged += HotDogCheckBox_CheckedChanged;
            CokoColaCheckBox.CheckedChanged += CokoColaCheckBox_CheckedChanged;
            FrenchFriesCheckBox.CheckedChanged += FrenchFriesCheckBox_CheckedChanged;
            HamburgerCheckBox.CheckedChanged += HamburgerCheckBox_CheckedChanged;

            //сооб. изменения значений в полях покупки товаров в кафе и подсчет суммы
            HamburgerCount.TextChanged += HamburgerCount_TextChanged;
            HotDogCount.TextChanged += HotDogCount_TextChanged;
            CokoColaCount.TextChanged += CokoColaCount_TextChanged;
            FrenchFriesCount.TextChanged += FrenchFriesCount_TextChanged;

            //сооб. проверка на изменения значения вывода основной суммы
            toPayCafe.TextChanged += ToPayCafe_TextChanged;

            //сооб. на нажатую кнопку рассчитать
            toCount.Click += ToCount_Click;

            //сооб. начало работы таймера
            timer.Tick += Timer_Tick;

            FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PayTotal == 0)
            {
                MessageBox.Show($"Продаж нет!", "Завершение программы", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Общие продажи за {DateTime.Now.ToShortDateString()} = {Math.Round(PayTotal, 2)} руб.", "Завершение программы", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer s = sender as Timer;
            tempTimer++;
            if (tempTimer == 10)
            {
                DialogResult result = MessageBox.Show("Завершить работу с этим клиентом?", "Очистить форму?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    PayTotal += PayGasStation + PayCafe;
                    timer.Stop();
                    Text = $"BestOil Общие продажи за {DateTime.Now.ToShortDateString()} = {Math.Round(PayTotal, 2)} руб.";
                    CokoColaCheckBox.Checked = false;
                    HamburgerCheckBox.Checked = false;
                    HotDogCheckBox.Checked = false;
                    FrenchFriesCheckBox.Checked = false;
                    comboBoxFuel.SelectedIndex = 0;
                    radioButtonCount.Checked = true;
                    textBoxRadioCount.Text = "0,00";
                    tempTimer = 0;
                    toPayTotal.Text = "0,00";
                }
                else
                {
                    tempTimer = 0;
                }
            }
        }

        private void ToPayCafe_TextChanged(object sender, EventArgs e)
        {
            if (toPayCafe.Text == "0")
            {
                toPayCafe.Text = "0,00";
            }
        }

        private void HamburgerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (HamburgerCheckBox.Checked)
            {
                HamburgerCount.ReadOnly = false;
                HamburgerCount.Focus();
            }
            else
            {

                PayCafe -= (double.Parse(HamburgerPrice.Text) * cHam);
                cHam = 0;
                HamburgerCount.ReadOnly = true;
                HamburgerCount.Text = "0,00";
                toPayCafe.Text = Math.Round(PayCafe, 2).ToString();
            }
        }

        private void FrenchFriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FrenchFriesCheckBox.Checked)
            {
                FrenchFriesCount.ReadOnly = false;
                FrenchFriesCount.Focus();
            }
            else
            {

                PayCafe -= (double.Parse(FrenchFriesPrice.Text) * cFri);
                cFri = 0;
                FrenchFriesCount.ReadOnly = true;
                FrenchFriesCount.Text = "0,00";
                toPayCafe.Text = Math.Round(PayCafe, 2).ToString();
            }
        }

        private void CokoColaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CokoColaCheckBox.Checked)
            {
                CokoColaCount.ReadOnly = false;
                CokoColaCount.Focus();
            }
            else
            {
                PayCafe -= (double.Parse(CokoColaPrice.Text) * cCol);
                cCol = 0;
                CokoColaCount.ReadOnly = true;
                CokoColaCount.Text = "0,00";

                toPayCafe.Text = Math.Round(PayCafe, 2).ToString();
            }
        }

        private void HotDogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (HotDogCheckBox.Checked)
            {
                HotDogCount.ReadOnly = false;
                HotDogCount.Focus();
            }
            else
            {

                PayCafe -= (double.Parse(HotDogPrice.Text) * cHot);
                cHot = 0;
                HotDogCount.ReadOnly = true;
                HotDogCount.Text = "0,00";
                toPayCafe.Text = Math.Round(PayCafe, 2).ToString();
            }
        }

        private void FrenchFriesCount_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            try
            {
                if (text.Text != "")
                {
                    if (double.Parse(text.Text) != cFri)
                    {
                        PayCafe -= (double.Parse(FrenchFriesPrice.Text) * cFri);
                        cFri = double.Parse(text.Text);
                        PayCafe += (double.Parse(FrenchFriesPrice.Text) * cFri);
                        toPayCafe.Text = Math.Round(PayCafe, 2).ToString();
                    }
                }
            }
            catch (Exception)
            {
                text.Text = "0,00";
                MessageBox.Show("Некорректный ввод данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CokoColaCount_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            try
            {
                if (text.Text != "")
                {
                    if (double.Parse(text.Text) != cCol)
                    {
                        PayCafe -= (double.Parse(CokoColaPrice.Text) * cCol);
                        cCol = double.Parse(text.Text);
                        PayCafe += (double.Parse(CokoColaPrice.Text) * cCol);
                        toPayCafe.Text = Math.Round(PayCafe, 2).ToString();
                    }
                }
            }
            catch (Exception)
            {
                text.Text = "0,00";
                MessageBox.Show("Некорректный ввод данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HotDogCount_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            try
            {
                if (text.Text != "")
                {
                    if (double.Parse(text.Text) != cHot)
                    {
                        PayCafe -= (double.Parse(HotDogPrice.Text) * cHot);
                        cHot = double.Parse(text.Text);
                        PayCafe += (double.Parse(HotDogPrice.Text) * cHot);
                        toPayCafe.Text = Math.Round(PayCafe, 2).ToString();
                    }
                }
            }
            catch (Exception)
            {
                text.Text = "0,00";
                MessageBox.Show("Некорректный ввод данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HamburgerCount_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            try
            {
                if (text.Text != "")
                {
                    if (double.Parse(text.Text) != cHam)
                    {
                        PayCafe -= (double.Parse(HamburgerPrice.Text) * cHam);
                        cHam = double.Parse(text.Text);
                        PayCafe += (double.Parse(HamburgerPrice.Text) * cHam);
                        toPayCafe.Text = Math.Round(PayCafe, 2).ToString();
                    }
                }
            }
            catch (Exception)
            {
                text.Text = "0,00";
                MessageBox.Show("Некорректный ввод данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToCount_Click(object sender, EventArgs e)
        {
            if (PayGasStation + PayCafe != 0)
            {
                toPayTotal.Text = (Math.Round((PayGasStation + PayCafe), 2)).ToString();
                timer.Start();
            }
            else
            {
                MessageBox.Show("Вы не совершили никаких операций", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Radio_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            try
            {
                if (radioButtonCount.Checked)
                {
                    PayGasStation = 0;
                    if (text.Text == "")
                    {
                        toPayGasStation.Text = "0,00";
                    }
                    else
                    {
                        PayGasStation = double.Parse(textBoxFuelPrice.Text) * double.Parse(text.Text);
                        toPayGasStation.Text = Math.Round(PayGasStation, 2).ToString();
                    }
                }
                if (radioButtonSum.Checked)
                {
                    PayGasStation = 0;
                    if (text.Text == "")
                    {
                        toPayGasStation.Text = "0,00";
                    }
                    else
                    {
                        PayGasStation = double.Parse(text.Text);
                        toPayGasStation.Text = Math.Round((double.Parse(text.Text) / double.Parse(textBoxFuelPrice.Text)), 2).ToString();
                    }
                }
            }
            catch (Exception)
            {
                text.Text = "0,00";
                MessageBox.Show("Некорректный ввод данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text == "")
            {
                text.Text = "0,00";
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text == "0,00")
            {
                text.Text = "";
            }
        }

        private void ComboBoxFuel_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox radio = sender as ComboBox;
            if (radio.SelectedIndex == 0)
            {
                textBoxFuelPrice.Text = $"{oil[0]}";
            }
            if (radio.SelectedIndex == 1)
            {
                textBoxFuelPrice.Text = $"{oil[1]}";
            }
            if (radio.SelectedIndex == 2)
            {
                textBoxFuelPrice.Text = $"{oil[2]}";
            }
            if (radio.SelectedIndex == 3)
            {
                textBoxFuelPrice.Text = $"{oil[4]}";
            }
            if (radio.SelectedIndex == 4)
            {
                textBoxFuelPrice.Text = $"{oil[3]}";
            }
            textBoxRadioCount.Text = "0,00";
            textBoxRadioSum.Text = "0,00";
            toPayGasStation.Text = "0,00";
        }

        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCount.Checked)
            {
                textBoxRadioCount.ReadOnly = false;
                textBoxRadioSum.ReadOnly = true;
                textBoxRadioSum.Text = "0,00";
                toPayGasStation.Text = "0,00";
                groupBoxFuel.Text = "К оплате";
                label5.Text = "грн.";
                textBoxRadioCount.Focus();
            }
            if (radioButtonSum.Checked)
            {
                textBoxRadioCount.ReadOnly = true;
                textBoxRadioSum.ReadOnly = false;
                textBoxRadioCount.Text = "0,00";
                toPayGasStation.Text = "0,00";
                groupBoxFuel.Text = "К выдаче";
                label5.Text = "л.";
                textBoxRadioSum.Focus();
            }
        }
    }
}

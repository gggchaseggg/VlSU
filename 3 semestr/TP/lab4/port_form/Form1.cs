using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using port_form;

namespace port_form
{
    public partial class Form1 : Form
    {
        public string NameTB = "";
        public int VmestimostTB;
        public int VesTB;
        public int PassengerAmountTB;

        public Form1()
        {
            InitializeComponent();

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;

            TextBoxName.Visible = false;
            TextBoxVmestimost.Visible = false;
            TextBoxVes.Visible = false;
            TextBoxPassengerAmount.Visible = false;
            TextBoxSat.Visible = false;

            SaveSudnoInfo_Button.Visible = false;
            SavePassengerAmount_Button.Visible = false;
            BackToMenu_Button.Visible = false;

        }
        
        //Кнопки главного меню
        //Кнопка "ДОБАВИТЬ СУДНО"
        private void AddSudno_Button_Click(object sender, EventArgs e)
        {
            AddSudno_Button.Visible = false;
            GetInfo_Button.Visible = false;
            AddPassenger_Button.Visible = false;
            Exit_Button.Visible = false;

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;

            TextBoxName.Visible = true;
            TextBoxVmestimost.Visible = true;
            TextBoxVes.Visible = true;
            TextBoxPassengerAmount.Visible = true;

            SaveSudnoInfo_Button.Visible = true;
            BackToMenu_Button.Visible = true;

        }
        //Кнопка "ПОЛУЧИТЬ ИНФОРМАЦИЮ"
        private void GetInfo_Button_Click(object sender, EventArgs e)
        {
            if (NameTB != "")
            {
                var sudno = new Passenger(NameTB, VmestimostTB, VesTB, PassengerAmountTB);
                sudno.Info();
            }
            else
            {
                MessageBox.Show("Сначала добавьте судно!");
            }
        }
        //Кнопка "ДОБАВИТЬ ПАССАЖИРОВ"
        private void AddPassenger_Button_Click(object sender, EventArgs e)
        {
            AddSudno_Button.Visible = false;
            GetInfo_Button.Visible = false;
            AddPassenger_Button.Visible = false;
            Exit_Button.Visible = false;
            BackToMenu_Button.Visible = true;
            SavePassengerAmount_Button.Visible = true;

            label6.Visible = true;

            TextBoxSat.Visible = true;
        }
        //Кнопка "ВЫХОД"
        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        
        //Общие кнопки
        //Кнопка "НАЗАД" для возврата в главное меню из второстепенных
        private void BackToMenu_Button_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;

            TextBoxName.Visible = false;
            TextBoxVmestimost.Visible = false;
            TextBoxVes.Visible = false;
            TextBoxPassengerAmount.Visible = false;
            TextBoxSat.Visible = false;

            SaveSudnoInfo_Button.Visible = false;
            SavePassengerAmount_Button.Visible = false;
            BackToMenu_Button.Visible = false;

            AddSudno_Button.Visible = true;
            GetInfo_Button.Visible = true;
            AddPassenger_Button.Visible = true;
            Exit_Button.Visible = true;

        }

        //Кнопки меню добавления судна
        //Кнопка "СОХРАНИТЬ"
        private void SaveSudnoInfo_Button_Click(object sender, EventArgs e)
        {
            NameTB = TextBoxName.Text;
            VmestimostTB = Convert.ToInt32(TextBoxVmestimost.Text);
            VesTB = Convert.ToInt32(TextBoxVes.Text);
            PassengerAmountTB = Convert.ToInt32(TextBoxPassengerAmount.Text);
        }
        //Кнопки меню добавления пассажиров
        //Кнопки "СОХРАНИТЬ"
        private void SavePassengerAmount_Button_Click(object sender, EventArgs e)
        {
            PassengerAmountTB += Convert.ToInt32(TextBoxSat.Text);
        }
    }
}

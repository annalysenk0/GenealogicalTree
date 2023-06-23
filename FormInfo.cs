using GenealogicalTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Дерево
{
    public partial class FormInfo : Form
    {
        public Person Data { get; private set; }
        //private Person modules;
        public FormInfo()
        {
            InitializeComponent();
        }

        //public Person GetModulesData(FormInfo form)
        //{
        //    return modules;
        //}

        //public Person GetModules()
        //{
        //    return modules;
        //}
        
        public void GetData(Person modules)
        {
            firstname.Text = modules.FirstName;
            lastname.Text = modules.LastName;
            patronymicname.Text = modules.PatronymicName;
            date.Text = modules.Date;
        }

        public void SaveData()
        {
            string firstName = firstname.Text;
            string lastName = lastname.Text;
            string patronymicName = patronymicname.Text;
            string birthdate = date.Text;

            if (string.IsNullOrEmpty(birthdate))
            {
                birthdate = "дата невідома";
            }
            else if (!ValidateBirthdate(birthdate))
            {
                MessageBox.Show("Невірний формат дати народження. " +
                    "Введіть дату у форматі 'дд.мм.рррр'. " +
                    "Якщо дата невідома, залиште поле порожнім.", "Помилка");
                return;
            }

            if (ContainsDigits(firstName) || ContainsDigits(lastName) || ContainsDigits(patronymicName))
            {
                MessageBox.Show("Ім'я, прізвище та по батькові не повинні містити цифри.",
                    "Помилка");
                return;
            }

            Person modules = new Person(firstName, lastName, patronymicName, birthdate);
            Data = modules;
            this.Close();

            MessageBox.Show("Дані збережено успішно.", "Повідомлення");
        }

        private bool ValidateBirthdate(string input)
        {
            if (input == "дата невідома")
            {
                return true;
            }

            string pattern = @"^\d{2}\.\d{2}\.\d{4}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        private bool ContainsDigits(string input)
        {
            return input.Any(char.IsDigit);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void canceldata_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Зміни не будуть збережені. " +
                "Продовжити?", "Попередження", MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                string firstLetter = textBox.Text.Substring(0, 1);
                string remainingText = textBox.Text.Substring(1);
                textBox.Text = firstLetter.ToUpper() + remainingText;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
    }
}

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
        public Module Data { get; private set; }
        private Module modules;
        public FormInfo()
        {
            InitializeComponent();
        }
        private Module GetModulesData(FormInfo form)
        {
            return modules;
        }

        public void SaveData()
        {
            string firstName = firstname.Text;
            string lastName = lastname.Text;
            string patronymicName = patronymicname.Text;
            string birthdate = date.Text;

            if (!ValidateBirthdate(birthdate))
            {
                MessageBox.Show("Невірний формат дати народження. Введіть дату у форматі 'дд.мм.рррр'.", "Помилка");
                return;
            }

            Module modules = new Module(firstName, lastName, patronymicName, birthdate);
            Data = modules;
            // Закриття поточної форми
            this.Close();

            MessageBox.Show("Дані збережено успішно.", "Повідомлення");
        }
        private bool ValidateBirthdate(string input)
        {
            // Використання регулярного виразу для перевірки формату дати "дд.мм.рррр"
            string pattern = @"^\d{2}\.\d{2}\.\d{4}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(input);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            SaveData();
        }

        public Module GetModules()
        {
            return modules;
        }

        private void canceldata_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Зміни не будуть збережені. Продовжити?", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        public void GetData(Module modules)
        {
            firstname.Text = modules.FirstName;
            lastname.Text = modules.LastName;
            patronymicname.Text = modules.PatronymicName;
            date.Text = modules.Date;
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

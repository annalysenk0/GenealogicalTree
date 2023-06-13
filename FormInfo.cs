using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            string bithdate = date.Text;

            Module modules = new Module(firstName, lastName, patronymicName, bithdate);
            Data = modules;
            // Закриття поточної форми
            this.Close();

            MessageBox.Show("Дані збережено успішно.", "Повідомлення");
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


    }
}

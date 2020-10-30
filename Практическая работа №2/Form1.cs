//Практическая работа №2
//Ефимкина Марина ИСП-31
//Ввести  n  целых чисел. Найти cумму чисел < 3. Результат вывести на экран.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace Практическая_работа__2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //О программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнила Ефимкина Марина, группа ИСП-31." +
                "Вариант № 5: Ввести  n  целых чисел. " +
                "Найти cумму чисел < 3. Результат вывести на экран. ");
        }

        //Выход
        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Очистить
        private void button3_Click(object sender, EventArgs e)
        {
            ClassLibrary1.Class1.Clear(table);
        }

        //При загрузке формы задаем начальные параметры нашей таблицы
        private void Form1_Load(object sender, EventArgs e)
        {
            table.ColumnCount = 5;
            table.RowCount = 1;
        }

        //Изменяем кол-во столбцов
        private void kolvo1_ValueChanged(object sender, EventArgs e)
        {
            table.ColumnCount = Convert.ToInt32(kolvo1.Value);
        }


        //Рассчитать
        private void button2_Click(object sender, EventArgs e)
        {
            int sum = ClassLibrary1.Class1.Find(table);
            rez.Text = sum.ToString();
        }

        //Сохранить
        private void сохранитьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLibrary1.Class1.SaveFile(table);
        }

        //Открыть
        private void открытьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLibrary1.Class1.OpenFile(table);
        }

        //Заполнить
        private void заполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLibrary1.Class1.Fill(table, Convert.ToInt32(diapazon.Value));
        }
    }
}

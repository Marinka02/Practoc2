using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClassLibrary1
{
    public class Class1
    {
        /// Функция находит сумму чисел<3
        public static int Find(DataGridView table)
        {
            int sum = 0;
            for (int j = 0; j < table.RowCount; j++)
                for (int i = 0; i < table.ColumnCount; i++)
                {
                    if (Convert.ToInt32(table[i, j].Value) < 3)
                        sum += Convert.ToInt32(table[i, j].Value);
                }
            return sum;
        }

        /// Функция заполняет таблицу DataGridView целыми случайными значениями от нуля до указанного максимального значения
        public static void Fill(DataGridView table, int RandMax)
        {
            Random Rand = new Random();
            for (int i = 0; i < table.ColumnCount; i++)
                table[i, 0].Value = Rand.Next(RandMax);
        }

        /// Функция очищает таблицу DataGridView
        public static void Clear(DataGridView table)
        {
            for (int i = 0; i < table.ColumnCount; i++)
                for (int j = 0; j < table.RowCount; j++)
                    table[i, j].Value = " ";
        }

        /// Функция сохраняет в файл таблицу DataGridView
        public static void SaveFile(DataGridView table)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(table.ColumnCount);
                file.WriteLine(table.RowCount);
                for (int i = 0; i < table.ColumnCount; i++)
                    for (int j = 0; j < table.RowCount; j++)
                        file.WriteLine(table[i, j].Value);
                file.Close();
            }
        }

        /// Функция копирует из текстового файла таблицу DataGridVie
        public static void OpenFile(DataGridView table)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            // присваиваю переменным начальные значения
            int columns = 0,
                                rows = 0;

            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(open.FileName);

                // проверка конвертации по очереди
                if (Int32.TryParse(file.ReadLine(), out columns))
                {
                    if (Int32.TryParse(file.ReadLine(), out rows))
                    {
                        table.ColumnCount = columns;
                        table.RowCount = rows;
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка конвертации при чтении");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Произошла ошибка конвертации при чтении");
                    return;
                }

                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        table[i, j].Value = file.ReadLine();
                    }
                }
            }
        }
    }
}
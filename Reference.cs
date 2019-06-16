using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Reference : Form
    {
        public Reference()
        {
            InitializeComponent();
            Ref.Text =
                "| 005 | Сложение | A2 = A1 + A2 |\n" +
                "| 006 | Вычитание | A2 = A1 - A2 |\n" +
                "| 007 | Умножение | A2 = A1 * A2 |\n" +
                "| 008 | Деление | A2 = A1 / A2 |\n" +
                "| 009 | Безусловный переход | RA = A2 |\n" +
                "| 010 | Ввод массива | A1 == pos, A2 == count |\n" +
                "| 011 | Вычисление Omega | A1 <= A2 ? Omega = 2 : Omega = 0 |\n" +
                "| 012 | Условный переход | Omega == 2 ? RA = A2 : RA = A1 |\n" +
                "| 013 | Вывод массива | A1 == pos, A2 == count |\n" +
                "| 014 | Взятие элемента по индексу | A1 == where to look for an index, A2 == what index to write |\n" +
                "| 015 | Завершение программы |\n" +
                "| 016 | Остаток от деления | A2 = A1 % A2 |";
        }
    }
}

using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace BeginerLearnProjrct {
    public partial class FormSort : Form {
        public FormSort() {
            InitializeComponent();
        }
        int[] arr;
        char mode = '1';
        private void buttonGenerate_Click(object sender, EventArgs e) {
            arr = new int[trackBar.Value];
            Random rnd = new Random();
            if(richTextBox1.Text != "") {
                richTextBox1.Text += "\n\n";
            }
            richTextBox1.Text += "Исходный массив: ";
            for(int i = 0;i < arr.Length; i++) {
                arr[i] = rnd.Next(-2056, 2056);
                richTextBox1.Text += arr[i].ToString() + " ";
            }
        }
        private void buttonSort_Click(object sender, EventArgs e) {
            Stopwatch SW = new Stopwatch(); // Создаем объект
            SW.Start(); // Запускаем
            switch(mode) {
                case '1':
                    Sort<int>.BubbleSort(arr);
                    break;
                case '2':
                    Sort<int>.InsertSort(arr);
                    break;
                case '3':
                    Sort<int>.GnomeSort(arr);
                    break;
                case '4':
                    Sort<int>.QuickSort(arr, 0, arr.Length - 1);
                    break;
                default:
                    Sort<int>.BubbleSort(arr);
                    break;
            }
            SW.Stop(); //Останавливаем
            MessageBox.Show(Convert.ToString(SW.ElapsedMilliseconds) + " " + Convert.ToString(SW.ElapsedTicks)); // Время выполнения в миллисекундах
            richTextBox1.Text += "\n\nОтсортированный массив: ";
            for(int i = 0; i < arr.Length; i++) {
                richTextBox1.Text += arr[i].ToString() + " ";
            }
        }
        private void radioButtonBubble_CheckedChanged(object sender, EventArgs e) {
            mode = '1';
        }
        private void radioButtonInsert_CheckedChanged(object sender, EventArgs e) {
            mode = '2';
        }
        private void radioButtonGnome_CheckedChanged(object sender, EventArgs e) {
            mode = '3';
        }
        private void radioButtonQuick_CheckedChanged(object sender, EventArgs e) {
            mode = '4';
        }

        private void buttonClear_Click(object sender, EventArgs e) {
            richTextBox1.Text = "";
        }

        private void trackBar_Scroll(object sender, EventArgs e) {
            label.Text = "Размерность массива: " + trackBar.Value.ToString();
        }
    }
}

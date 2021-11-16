using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cont.Clear();
            openFileDialog1.FileName = @"NewDocument.txt";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;

            try
            {
                StreamReader reader = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                cont.Text = reader.ReadToEnd();
                reader.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void SAVE()
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter writer = new StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.GetEncoding(1251));
                    writer.Write(cont.Text);
                    writer.Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SAVE();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Желаете сохранить документ?", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
                SAVE();
            Application.Restart();
        }

        private void скопироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cont.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFormats.Format format = DataFormats.GetFormat(DataFormats.UnicodeText);
            cont.Paste(format);
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cont.Cut();
        }

        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cont.SelectAll();
        }

        private void снятьВыделениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cont.DeselectAll();
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cont.Undo();
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cont.Redo();
        }
    }
}

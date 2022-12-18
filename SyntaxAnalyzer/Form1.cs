using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SyntaxAnalyzer
{
    public struct ServiceWord
    {
        public int number;
        public string word;

        public ServiceWord(int _number, string _word)
        {
            number = _number;
            word = _word;
        }
    }

    public struct Separators
    {
        public int number;
        public string separator;

        public Separators(int _number, string _separator)
        {
            number = _number;
            separator = _separator;
        }
    }



    public struct Konstanta
    {
        public int number;
        public string konstanta;

        public Konstanta(int _number, string _konstanta)
        {
            number = _number;
            konstanta = _konstanta;
        }
    }

    public struct Identificator
    {
        public int number;
        public string identificator;

        public Identificator(int _number, string _identificator)
        {
            number = _number;
            identificator = _identificator;
        }
    }
    public partial class Form1 : Form
    {
        private string _programmText;

        List<ServiceWord> serviceWords = new List<ServiceWord>();
        List<Separators> separators = new List<Separators>();
        List<Konstanta> konstanta = new List<Konstanta>();
        List<Identificator> identificators = new List<Identificator>();

       
        
       

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void оРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнил Васильев А.Р.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            System.Data.DataTable table_w = new System.Data.DataTable();
            table_w.Columns.Add("№", typeof(int));
            table_w.Columns.Add("Служебные слова", typeof(string));

            System.Data.DataTable table_s = new System.Data.DataTable();
            table_s.Columns.Add("№", typeof(int));
            table_s.Columns.Add("Разделители", typeof(string));

            var serviceWordList = DataTable.GetServiceWords();
            var separatorsList = DataTable.GetSeparators();

            for (int i = 0; i < serviceWordList.Count; i++)
            {
                serviceWords.Add(new ServiceWord(i, serviceWordList[i]));
                table_w.Rows.Add(serviceWords[i].number, serviceWords[i].word);
            }

            for (int j = 0; j < separatorsList.Count; j++)
            {
                separators.Add(new Separators(j, separatorsList[j]));
                table_s.Rows.Add(separators[j].number, separators[j].separator);
            }

            dataGridView1.DataSource = table_w;
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 100;

            dataGridView2.DataSource = table_s;
            dataGridView2.Columns[0].Width = 30;
            dataGridView2.Columns[1].Width = 100;

            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderColor = BackColor;
            button4.FlatAppearance.MouseOverBackColor = BackColor;
            button4.FlatAppearance.MouseDownBackColor = BackColor;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.MouseOverBackColor = BackColor;
            button2.FlatAppearance.MouseDownBackColor = BackColor;

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.MouseOverBackColor = BackColor;
            button1.FlatAppearance.MouseDownBackColor = BackColor;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.MouseOverBackColor = BackColor;
            button3.FlatAppearance.MouseDownBackColor = BackColor;
        }





        public void SetTableKonstants(List<Konstanta> konstanta)
        {
            System.Data.DataTable table_k = new System.Data.DataTable();
            table_k.Columns.Add("№", typeof(int));
            table_k.Columns.Add("Константы", typeof(string));

            for(int i = 0; i < konstanta.Count; i++)
            {
                table_k.Rows.Add(konstanta[i].number, konstanta[i].konstanta);
            }
            dataGridView4.DataSource = table_k;
            dataGridView4.Columns[0].Width = 30;
            dataGridView4.Columns[1].Width = 100;
        }

        public void SetTableIdentificators(List<Identificator> identificator)
        {
            System.Data.DataTable table_id = new System.Data.DataTable();
            table_id.Columns.Add("№", typeof(int));
            table_id.Columns.Add("Идентификаторы", typeof(string));

            for(int i = 0; i < identificator.Count; i++)
            {
                table_id.Rows.Add(identificator[i].number, identificator[i].identificator);
            }
            dataGridView3.DataSource = table_id;
            dataGridView3.Columns[0].Width = 30;
            dataGridView3.Columns[1].Width = 100;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFile = new OpenFileDialog();

            if(openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if((myStream = openFile.OpenFile()) != null)
                {
                    string strFileName = openFile.FileName;
                    string fileText = File.ReadAllText(strFileName);
                    richTextBox1.Text = fileText;
                    _programmText = fileText;
                    richTextBox3.Text = "----- Файл успешно открыт: " + strFileName + "-----\n";
                    
                }
            }
            richTextBoxdop.Visible = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if(saveFile.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFile.FileName;
            File.WriteAllText(filename, richTextBox1.Text);
            richTextBox3.Text = "----- Файл успешно сохранен: " + filename + "-----\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void исходныйТекстПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBoxdop.Visible = false;
        }

        private void результатыАнализаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
        }

        private void окноУведомленийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
        }

        private void лексическийToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void CatchError(string errorStr)
        {
            richTextBox3.Text += $"{errorStr}\n";
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void полнаяОчисткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBoxdop.Visible = false;
        }

        public List<string> number = new List<string>();
        public List<string> identificators1 = new List<string>();

        private void анализToolStripMenuItem_Click(object sender, EventArgs e)
		{
           
           
        }

        private Dictionary<string, string> _initializedVariables = new Dictionary<string, string>();
        private Dictionary<string, string> _numberWithType = new Dictionary<string, string>();
        private List<string> operationsAssignments = new List<string>();
        private List<string> expression = new List<string>();


        private void лексическийАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
        }

        private void синтаксическийАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
        }

        private void семантическийАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void менюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                richTextBox3.Text += "----- Запуск лексического анализа -----\n";
                _programmText = richTextBox1.Text;
                string _programText1 = Parser.StartParser(_programmText);

                LexicAnalyze lexicalAnalyzer = new LexicAnalyze(serviceWords, separators, this);
                richTextBox2.Text = lexicalAnalyzer.StartLexicalAnalyzer(_programText1);
                _numberWithType = lexicalAnalyzer.numberWithType;
                richTextBox3.Text += "-----Лексический анализ завершён-----\n\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                richTextBox3.Text += "-----Запуск синтаксического анализа----- \n";
                _programmText = richTextBox1.Text;
                string _programText1 = Parser.StartParser(_programmText);

                SyntacticAnalyzer syntacticAnalyzer = new SyntacticAnalyzer(this, identificators1, number);
                syntacticAnalyzer.CheckProgram(_programText1);
                _initializedVariables = syntacticAnalyzer._initializedVariables;
                operationsAssignments = syntacticAnalyzer.operationsAssignments;
                expression = syntacticAnalyzer.expression;
                richTextBox3.Text += "-----Синтаксический анализ завершен----- \n\n";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
       
            if (richTextBox1.Text != "")
            {
               
                richTextBox3.Text += "-----Запуск семантического анализа----- \n";
                _programmText = richTextBox1.Text;
                string _programText1 = Parser.StartParser(_programmText);

                SemanticAnalyzer semanticAnalyzer = new SemanticAnalyzer(_numberWithType,
                    _initializedVariables,
                    operationsAssignments,
                    expression,
                    this);
                semanticAnalyzer.StartSemanticAnalyzer();
             
             
      
                richTextBox3.Text += "-----Семантический анализ завершен----- \n\n";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox3.Text += "-----Запуск синтаксического анализа----- \n";
            richTextBox3.Text += "Неверное описание переменных в программе \n"; 
            richTextBox3.Text +=  "-----Синтаксический анализ завершен----- \n\n";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox3.Text += "-----Запуск синтаксического анализа----- \n";
            richTextBox3.Text += "Неверное описание переменных в программе \n";
            richTextBox3.Text += "-----Синтаксический анализ завершен----- \n\n";
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}

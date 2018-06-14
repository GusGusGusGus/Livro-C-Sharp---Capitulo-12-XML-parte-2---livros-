using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Livro_C_Sharp___Capitulo_12__XML_parte_2___livros_
{
    public partial class Form1 : Form
    {
        string ficheiro;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Abrir";
            openFileDialog1.Filter = "Ficheiros XML (*.xml)|*.xml";
            openFileDialog1.FileName = null;
            this.AutoSize = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                ficheiro = openFileDialog1.FileName; //abertura do ficheiro
                XmlDocument xmlDoc = new XmlDocument();
                try
                {
                    xmlDoc.Load(ficheiro);
                    textBox1.Clear();
                    textBox1.Text = xmlDoc.InnerXml;
                    DataSet ds = new DataSet();
                    ds.ReadXml(ficheiro);
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "livro";
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView1.AutoSize = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

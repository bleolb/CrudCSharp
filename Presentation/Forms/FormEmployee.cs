using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Models;
using Domain.ValueObjects;


namespace Presentation.Forms
{
    public partial class FormEmployee : Form
    {
        private EmployeeModel employee = new EmployeeModel(); 
        public FormEmployee()
        {
            InitializeComponent();
            panel1.Enabled = false;
        }
  

        private void FormEmployee_Load(object sender, EventArgs e)
        {
             ListEmployees();
        }
        private void ListEmployees()
        {
            try
            {
                dataGridView1.DataSource = employee.GetAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = employee.FindById(textBox5.Text);
        }

















        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
                
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = employee.FindById(textBox5.Text);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            employee.IdNumber = textBox1.Text;
            employee.Mail = textBox3.Text;
            employee.Name = textBox2.Text;
            employee.Birthday = dateTimePicker1.Value;

            bool valid = new Helps.DataValidation(employee).Validate();
            if (valid == true)
            {
                string result = employee.SaveChanges();
                MessageBox.Show(result);
                ListEmployees();
                Restart();
            }
        }

        private void Restart()
        {
            panel1.Enabled = false;
            textBox1.Clear();
            textBox3.Clear();
            textBox2.Clear();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel1.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                panel1.Enabled = true;
                employee.State = EntityState.Modified;
                employee.IdPk = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
            }
            else
                MessageBox.Show("Select row");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                employee.State = EntityState.Deleted;
                employee.IdPk = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
               string result = employee.SaveChanges();
                MessageBox.Show(result);
                ListEmployees();
            }
            else
                MessageBox.Show("Select row");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

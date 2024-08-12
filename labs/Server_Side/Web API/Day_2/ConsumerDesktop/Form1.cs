using ConsumerDesktop.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace ConsumerDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7299/api/departments");
            var departments = await response.Content.ReadFromJsonAsync<List<DepartmentDTO>>();

            comboBox1.DataSource = departments;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";

            var response2 = client.GetAsync("https://localhost:7299/api/students").Result;
            var students = response2.Content.ReadFromJsonAsync<List<StudentDTO>>().Result;

            dataGridView1.DataSource = students;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            var student = new StudentDTO
            {
                fname = textBox1.Text,
                lname = textBox4.Text,
                address = textBox3.Text,
                age = (int)numericUpDown1.Value,
                deptName = comboBox1.SelectedValue.ToString()
            };

            var response = client.PostAsJsonAsync("https://localhost:7299/api/students", student).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Student added successfully");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show(error);
            }

            Form1_Load(sender, e);
        }
    }
}

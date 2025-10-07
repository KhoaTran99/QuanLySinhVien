using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tuan04_CT3_CSDL.Models;


namespace Tuan04_CT3_CSDL
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

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TẠO ĐỐI TƯỢNG DB
            ModelStudentDB studentDB = new ModelStudentDB();

            //lấy ds sinh viên và khoa
            List<Student> students = studentDB.Students.ToList();
            List<Faculty> faculties = studentDB.Faculties.ToList();

            FillCbbKhoa(faculties);
            FillDGVStudent(students);



        }

        private void FillDGVStudent(List<Student> students)
        {
           //xoá dữ liệu cũ
           dgvStudent.Rows.Clear();

            foreach (Student student in students)
            {
                // tạo dòng mới trong bảng để chứa dữ liệu
                int rowIndex = dgvStudent.Rows.Add();

                // đưa dữ liệu và từng cột trong bảng

                dgvStudent.Rows[rowIndex].Cells[0].Value = student.StudentID;
                dgvStudent.Rows[rowIndex].Cells[1].Value = student.StudentName;
                dgvStudent.Rows[rowIndex].Cells[2].Value = student.Gioitinh;
                dgvStudent.Rows[rowIndex].Cells[3].Value = student.AverageScore;
                dgvStudent.Rows[rowIndex].Cells[4].Value = student.Faculty.FacultyName;



            }








        }

        private void FillCbbKhoa(List<Faculty> faculties)
        {
            cbbKhoa.DataSource = faculties;

            cbbKhoa.DisplayMember = "FacultyName";
            cbbKhoa.ValueMember = "FacultyID";
        }
    }
}

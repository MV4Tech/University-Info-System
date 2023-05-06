using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using UserLoginMariqn;


namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public List<string> StudStatusChoices { get; set; }

        public MainWindow()
        {
            FillStudStatusChoices();
            InitializeComponent();
        }

        public bool flag = false;
    

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr
                FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }

        }


        private void btnCleanForms_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtSurename.Text = "";
            txtFamilyName.Text = "";
            txtFacultet.Text = "";
            txtMajor.Text = "";
            txtOKS.Text = "";
            //txtStatus.Text = "";
            txtFacNumb.Text = "";
            txtCurs.Text = "";
            txtStream.Text = "";
            txtGroup.Text = "";
        }

        private void btnDeactivate_Click(object sender, RoutedEventArgs e)
        {
            txtName.IsEnabled = false;
            txtSurename.IsEnabled = false;
            txtFamilyName.IsEnabled = false;
            txtFacultet.IsEnabled = false;
            txtMajor.IsEnabled = false;
            txtOKS.IsEnabled = false;
            //txtStatus.IsEnabled = false;
            txtFacNumb.IsEnabled = false;
            txtCurs.IsEnabled = false;
            txtStream.IsEnabled = false;
            txtGroup.IsEnabled = false;

        }


        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {
            txtName.IsEnabled = true;
            txtSurename.IsEnabled = true;
            txtFamilyName.IsEnabled = true;
            txtFacultet.IsEnabled = true;
            txtMajor.IsEnabled = true;
            txtOKS.IsEnabled = true;
            //txtStatus.IsEnabled = true;
            txtFacNumb.IsEnabled = true;
            txtCurs.IsEnabled = true;
            txtStream.IsEnabled = true;
            txtGroup.IsEnabled = true;
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            Student s1 = new Student();
          
            
                s1.name = "Ivan";
                s1.surename = "Ivanov";
                s1.familyName = "Ivanov";
                s1.facultet = "FKST";
                s1.major = "KSI";
                s1.educDegree = "Bachelor";
                s1.status = StudStatusChoices[1];
                s1.facultetNumber = 121220175;
                s1.course = "3";
                s1.stream = "10";
                s1.group = "43";


                txtName.Text = s1.name;
                txtSurename.Text = s1.surename;
                txtFamilyName.Text = s1.familyName;
                txtFacultet.Text = s1.facultet;
                txtMajor.Text = s1.major;
                txtOKS.Text = s1.educDegree;
                //txtStatus.Text = s1.status;
                txtFacNumb.Text = Convert.ToString(s1.facultetNumber);
                txtCurs.Text = s1.course;
                txtStream.Text = s1.stream;
                txtGroup.Text = s1.group;

            



        }

        

        private void comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox.Items.Add("");
            foreach (string status in StudStatusChoices)
                comboBox.Items.Add(status);
        }

        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();

            if(countStudents == 3)
            {
                return true;
            }
            return false;
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            if (TestStudentsIfEmpty())
            {
                MessageBox.Show("True");
            }
            else
                MessageBox.Show("False");
        }

        private void CopyTestStudents()
        {
            Student st = new Student();

            st.name = txtName.Text.ToString();
            st.surename = txtSurename.Text.ToString();
            st.familyName = txtFamilyName.Text.ToString();
            st.facultet = txtFacultet.Text.ToString();
            st.major = txtMajor.Text.ToString();
            st.educDegree = txtOKS.Text.ToString();
            st.status = comboBox.SelectedItem.ToString();
            st.facultetNumber = Convert.ToInt32(txtFacNumb.Text.ToString());
            st.course = txtCurs.Text.ToString();
            st.stream = txtStream.Text.ToString();
            st.group = txtGroup.Text.ToString();

            StudentData.TestStudents.Add(st);
            StudentInfoContext context = new StudentInfoContext();
            foreach(Student stud in StudentData.TestStudents)
            {
                context.Students.Add(stud);
            }
                context.SaveChanges();
        }

        private void insertData_Click(object sender, RoutedEventArgs e)
        {
            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
            }
            else
                MessageBox.Show("There is data inside the table.");
        }

        private void CopyTestUsers()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach(User us in UserData.TestUsers)
            {
                context.Users.Add(us);
            }
            context.SaveChanges();
        }

        private void insertDataUser_Click(object sender, RoutedEventArgs e)
        {
            CopyTestUsers();
        }


        private void gradeBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }




    }
}

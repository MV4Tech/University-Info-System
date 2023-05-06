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
using System.Windows.Shapes;


namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for PasswordPopUp.xaml
    /// </summary>
    public partial class PasswordPopUp : Window
    {
        private List<Person> personList;

        //public List<Person> PersonList { get; set; }
        public PasswordPopUp(List<Person> p)
        {
            InitializeComponent();
            personList = p;
        
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
           foreach(Person p in personList){
                if (passworBox.Password.Equals(p.Password))
                {
                    flag = true;
                    ExpenseltHome.key = 0;
                    this.Close();
                }
           }

            if (flag == false)
            {
                MessageBox.Show("Wrong Password");
                passworBox.Password = "";
            }
          
           
        }


/*        public void changeKey()
        {
            ExpenseltHome k = new ExpenseltHome();
            k.key = 0;
        }*/
    }
}

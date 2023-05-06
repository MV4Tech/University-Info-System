using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Collections.ObjectModel;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseltHome.xaml
    /// </summary>
    public partial class ExpenseltHome : Window, INotifyPropertyChanged
    {

        public static int key;

        public ObservableCollection<string> PersonsChecked
        { get; set; }
        public string MainCaptionText { get; set; }
        public List<Person> ExpenseDataSource { get; set; }
        public DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            }
        }




        public ExpenseltHome()
        {
            InitializeComponent();

            LastChecked = DateTime.Now;

            this.DataContext = this;

            PersonsChecked = new ObservableCollection<string>();

            ExpenseDataSource = new List<Person>()
             {
                    new Person()
                    {
                        Name="Mike",
                        Department ="Legal",
                        ImagePath = "/Images/boy.png",
                        Password = "123",
                        Expenses = new List<Expense>()
                        {
                            new Expense() { ExpenseType="Lunch", ExpenseAmount =50 },
                            new Expense() { ExpenseType="Transportation", ExpenseAmount=50 }
                        }
                    },
                    new Person()
                    {
                        Name ="Lisa",
                        Department ="Marketing",
                        ImagePath = "/Images/girl.png",
                        Password = "123",
                        Expenses = new List<Expense>()
                        {
                            new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
                            new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
                        }
                    },
                    new Person()
                    {
                         Name="John",
                         Department ="Engineering",
                         ImagePath = "/Images/boy1.png",
                         Password = "123",
                         Expenses = new List<Expense>()
                         {
                            new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
                            new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
                            new Expense() { ExpenseType="Software", ExpenseAmount=500 }
                         }
                    },
                    new Person()
                    {
                        Name="Mary",
                        Department ="Finance",
                        ImagePath = "/Images/girl2.png",
                        Password = "123",
                        Expenses = new List<Expense>()
                        {
                            new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                        }
                    },
                    new Person()
                    {
                         Name="Theo",
                         Department ="Marketing",
                         ImagePath = "/Images/boy2.png",
                         Password = "123",
                         Expenses = new List<Expense>()
                         {
                            new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                         }
                    },
                    new Person()
                    {
                        Name = "James",
                        Department = "KSI",
                        ImagePath = "/Images/boy3.png",
                        Password = "123",
                        Expenses = new List<Expense>
                        {
                            new Expense{  ExpenseType ="Laptop", ExpenseAmount = 1700},
                            new Expense{  ExpenseType ="Keyboard", ExpenseAmount = 180}
                        }
                    },
                     new Person()
                    {
                        Name = "David",
                        Department = "executive department",
                        ImagePath = "/Images/boy4.png",
                        Password = "123",
                        Expenses = new List<Expense>
                        {
                            new Expense{  ExpenseType ="Book", ExpenseAmount = 25},
                            new Expense{  ExpenseType ="Pen", ExpenseAmount = 1}
                        }
                    },

             };

            MainCaptionText = "View Expense Report :";




        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (peopleListBox.SelectedItem != null && peopleListBox.SelectedItem is Person)
            {
                LastChecked = DateTime.Now;
                PersonsChecked.Add(((Person)peopleListBox.SelectedItem).Name);
            }
        }



        private void viewButton_Click(object sender, RoutedEventArgs e)
        {
            /*
ExpenseReport ep = new ExpenseReport();
ep.Height = this.Height;
ep.Width = this.Width;
ep.ShowDialog();*/
            bool flag = true;
            //changeKey();
            key = 1;
            while (flag == true)
            {
                PasswordPopUp passPop = new PasswordPopUp(ExpenseDataSource);
                passPop.ShowDialog();
                if (key == 0)
                {
                    flag = false;
                }
                else
                {
                    ExpenseltHome eh = new ExpenseltHome();
                    this.Close();
                    eh.ShowDialog();
                }
                Console.WriteLine(key);
                Console.WriteLine(flag);
            }

            ExpenseReport expenseReport = new ExpenseReport(proverkaIme(viewButton.Content.ToString()));
            expenseReport.Height = this.Height;
            expenseReport.Width = this.Width;
            expenseReport.ShowDialog();


        }

        public Person proverkaIme(string asd)
        {
            foreach (Person p in ExpenseDataSource)
            {
                if (viewButton.Content.Equals(p.Name))
                {
                    return p;
                }
            }
            return null;
        }

/*        public void changeKey(){
            key = 1;
           
            }*/


    }
}

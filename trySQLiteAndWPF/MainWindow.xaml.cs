using DemoLibraryN;
using System.Collections.Generic;
using System.Windows;

namespace trySQLiteAndWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<PersonModel> people = new List<PersonModel>();

        public MainWindow()
        {
            InitializeComponent();

            LoadPeopleList();
        }

        private void LoadPeopleList()
        {
            // todo - get real people here
            //people.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            //people.Add(new PersonModel { FirstName = "John", LastName = "Doe" });
            //people.Add(new PersonModel { FirstName = "Mary", LastName = "Smith" });

            people = SqliteDataAccess.LoadPeople();

            WireUpPeopleList();

        }

        private void WireUpPeopleList()
        {
            listPeopleListBox.ItemsSource = null;
            listPeopleListBox.ItemsSource = people;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

            PersonModel p = new PersonModel();

            p.FirstName = firstNameText.Text;
            p.LastName = lastNameText.Text;

            //todo - do something with this item
            //people.Add(p);
            //WireUpPeopleList();

            SqliteDataAccess.SavePerson(p);

            WireUpPeopleList();

            firstNameText.Text = "";
            lastNameText.Text = "";


        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            people = SqliteDataAccess.LoadPeople();

            WireUpPeopleList();
        }
    }
}

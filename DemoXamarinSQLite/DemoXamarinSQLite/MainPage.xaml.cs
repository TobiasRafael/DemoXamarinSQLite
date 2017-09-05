using System;
using Xamarin.Forms;

namespace DemoXamarinSQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(10, 20, 10, 10);
                    break;
                default:
                    Padding = new Thickness(10);
                    break;
            }

            listListView.ItemTemplate = new DataTemplate(typeof(EmployeeCell));
            listListView.RowHeight = 70;


            using (var data = new DataAccess())
            {
              
                listListView.ItemsSource = data.GetEmployees();
            }

            AddButton.Clicked += AddButton_Clicked;
            listListView.ItemSelected += ListListView_ItemSelected;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            using (var data = new DataAccess())
            {

                listListView.ItemsSource = data.GetEmployees();
            }
        }

        private async void ListListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new EditPage((Employee)e.SelectedItem));
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(namesEntry.Text))
            {
                await DisplayAlert("Error", "Insert names", "Accept");
                namesEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(lastnamesEntry.Text))
            {
                await DisplayAlert("Error", "Insert lastnames", "Accept");
                lastnamesEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(salaryEntry.Text))
            {
                await DisplayAlert("Error", "Insert salary amount", "Accept");
                salaryEntry.Focus();
                return;
            }

            var employee = new Employee
            {
                Names = namesEntry.Text,
                LastNames = lastnamesEntry.Text,
                ContractDate = dateContractDatePicker.Date,
                Salary = decimal.Parse(salaryEntry.Text),
                Active = activeSwitch.IsToggled
            };
            using (var data = new DataAccess())
            {
                data.InsertEmployee(employee);
                listListView.ItemsSource = data.GetEmployees();
            }

            namesEntry.Text = string.Empty;
            lastnamesEntry.Text = string.Empty;
            salaryEntry.Text = string.Empty;
            dateContractDatePicker.Date = DateTime.Now;
            activeSwitch.IsToggled = true;
            await DisplayAlert("Confimed", "Employee added", "Accept");
        }
    }
}

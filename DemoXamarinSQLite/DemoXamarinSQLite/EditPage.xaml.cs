
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoXamarinSQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {

        private Employee _employee;
        public EditPage(Employee employee)
        {
            InitializeComponent();

            this._employee = employee;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(10, 20, 10, 10);
                    break;
                default:
                    Padding = new Thickness(10);
                    break;
            }

            namesEntry.Text = employee.Names;
            lastnamesEntry.Text = employee.LastNames;
            contractDatePicker.Date = employee.ContractDate;
            salaryEntry.Text = employee.Salary.ToString();
            activeSwitch.IsToggled = employee.Active;



            refreshButton.Clicked += RefreshButton_Clicked;
            deleteButton.Clicked += DeleteButton_Clicked;

        }

        private async void DeleteButton_Clicked(object sender, System.EventArgs e)
        {
            var cfrm = await DisplayAlert("Confirmation", "Are you sure to delete this employee?", "Yes", "No");
            if (!cfrm)
            {
                return;
            }           

            using (var data = new DataAccess())
            {
                data.DeleteEmployee(_employee);
            }
            await DisplayAlert("Confirmation", "Employee deleted succesfully", "Accept");
            await Navigation.PopAsync();
        }

        private async void RefreshButton_Clicked(object sender, System.EventArgs e)
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

            _employee.Names = namesEntry.Text;
            _employee.LastNames = lastnamesEntry.Text;
            _employee.Salary = decimal.Parse(salaryEntry.Text);
            _employee.ContractDate = contractDatePicker.Date;
            _employee.Active = activeSwitch.IsToggled;

            using (var data = new DataAccess())
            {
                data.UpdateEmployee(_employee);
            }

            await DisplayAlert("Confirmation", "Employee succesfully updated", "Accept");
            await Navigation.PopAsync();

        }
    }
}
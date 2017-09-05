using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoXamarinSQLite
{
    public class EmployeeCell : ViewCell
    {
        public EmployeeCell()
        {
            var idEmployeeLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };

            idEmployeeLabel.SetBinding(Label.TextProperty, new Binding("IDEmployee"));

            var completeNameLabel = new Label
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            completeNameLabel.SetBinding(Label.TextProperty, new Binding("CompleteName"));

            var contractDateLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            contractDateLabel.SetBinding(Label.TextProperty, new Binding("ContractDateEdited"));

            var salaryLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End
            };

            salaryLabel.SetBinding(Label.TextProperty, new Binding("EditedSalary"));

            var activeSwitch = new Switch
            {
                IsEnabled = false,
                HorizontalOptions = LayoutOptions.End
            };

            activeSwitch.SetBinding(Switch.IsToggledProperty, new Binding("Active"));

            var line1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    idEmployeeLabel, completeNameLabel
                },
            };




            var line2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    contractDateLabel, salaryLabel, activeSwitch,
                },
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    line1,line2,
                },
            };

        }

    }
}

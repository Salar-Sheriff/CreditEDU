using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SchoolCreditSystem
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        void SignInButton_Clicked(System.Object sender, System.EventArgs e)
        {

            
            if(StudentIDEntry.Text == null || StudentIDEntry.Text.Equals(""))
            {

                DisplayAlert("Hey There!", "You forgot to enter your Student ID", "okay");
                return;
            }


            if(SchoolIDPicker.SelectedItem == null)
            {
                DisplayAlert("Hey There!", "You forgot to pick your school", "okay");
                return;
            }


            string selectedSchoolName = SchoolIDPicker.SelectedItem.ToString();

            

            if(selectedSchoolName.Equals("Screaming Eagle Highschool"))
            {
                Navigation.PushAsync(new MainPage("994", StudentIDEntry.Text));
            }
            else if (selectedSchoolName.Equals("Bald Eagle Intermediate School"))
            {
                Navigation.PushAsync(new MainPage("993", StudentIDEntry.Text));
            }
            else if (selectedSchoolName.Equals("Golden Eagle Elementary School"))
            {
                Navigation.PushAsync(new MainPage("990", StudentIDEntry.Text));
            }
           else if (selectedSchoolName.Equals("Tawny Eagle YR Elementary School"))
            {
                Navigation.PushAsync(new MainPage("991", StudentIDEntry.Text));
            }
            else if (selectedSchoolName.Equals("Eagle Summer School"))
            {
                Navigation.PushAsync(new MainPage("998", StudentIDEntry.Text));
            }
        }
    }
}

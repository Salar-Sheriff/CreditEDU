using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SchoolCreditSystem
{
    public partial class MainPage : MasterDetailPage
    {

        string schoolID;
        string studentID;


        public MainPage(string _schoolID, string _studentID)
        {
            InitializeComponent();
            IsPresented = false;
            NavigationPage.SetHasNavigationBar(this, false);

            schoolID = _schoolID;
            studentID = _studentID;


            Detail = new NavigationPage(new HomePage(schoolID, studentID));
           
        }
        public void OnLabelTappedProfile(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new HomePage(schoolID, studentID, "This is to make sure things are not recalculated"));
            IsPresented = false;
        }
        
        public void OnLabelTappedStore(object sender, EventArgs args)
        {

            //Detail = new NavigationPage(new TemporaryStore());
            Detail = new NavigationPage(new StorePage());
            IsPresented = false;
        }
        
        public void OnLabelTappedInformation(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new InformationPage());
            IsPresented = false;
        }
        public void OnLabelTappedCart(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ShoppingCart(new List<Classes.ShopItem>()));
            IsPresented = false;
        }

        public void OnLabelTappedSignOut(object sender, EventArgs args)
        {
            Navigation.PushAsync(new SignInPage()); 
            
        }

    }
}

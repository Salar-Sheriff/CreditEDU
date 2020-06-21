using System;
using System.Collections.Generic;
using SchoolCreditSystem.Classes;
using Xamarin.Forms;

namespace SchoolCreditSystem
{
    public partial class ShoppingCart : ContentPage
    {
        List<ShopItem> shopcart;

        int creditCost;
        int selectedIndex;
        public ShoppingCart(List<ShopItem> cartstuff)
        {
            InitializeComponent();
            shopcart = cartstuff;
            ShoppingCartListView.ItemsSource = shopcart;

            //Count the total credit cost
            for(int i = 0; i < shopcart.Count; i++)
            {

                creditCost += shopcart[i].creditCount;
            }

            //display on label

            TotalCostLabel.Text = "Total: " + creditCost + " credits";

        }

        void RedeemButton_Clicked(System.Object sender, System.EventArgs e)
        {

            HomePage.totalCredits -= creditCost;
            HomePage.totalCreditsSpent += creditCost;
            creditCost = 0;
            Navigation.PushAsync(new ReceiptPage(shopcart));
        }

        private void Remove_Button_Clicked(object sender, EventArgs e)
        {


            creditCost -= shopcart[selectedIndex].creditCount;
            shopcart.RemoveAt(selectedIndex);
            ShoppingCartListView.ItemsSource = null;
            ShoppingCartListView.ItemsSource = shopcart;
            TotalCostLabel.Text = "Total: " + creditCost + " credits";

        }

        private void ShoppingCartListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedIndex = e.SelectedItemIndex;
        }
    }
}

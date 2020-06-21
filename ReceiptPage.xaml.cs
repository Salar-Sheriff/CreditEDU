using System;
using System.Collections.Generic;
using System.Linq;
using SchoolCreditSystem.Classes;
using Xamarin.Forms;

namespace SchoolCreditSystem
{
    public partial class ReceiptPage : ContentPage
    {
        public ReceiptPage(List<ShopItem> shoppingCart)
        {
            InitializeComponent();

            string DisplayCodes = "";

            for (int i = 0; i < shoppingCart.Count; i++)
            {
                DisplayCodes = DisplayCodes + RandomString(10) + "\n";

            }
            CodesToRedeemLabel.Text = DisplayCodes;

            FirstNameLabel.Text = HomePage.firstName + " " + HomePage.lastName;
            

            AddressLabel.Text = HomePage.studentMailingAddress;


            CreditBalanceLabel.Text = "Credit Balance: " + HomePage.totalCredits;
            CreditUseLabel.Text = "Credits Used: " + HomePage.totalCreditsSpent;
        }


        
        static Random random = new Random();
        public static string RandomString(int length)
        {


            string[] companies = {"Walmart: ", "Amazon: ", "Ebay: ", "Target: "};

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            Random rnd = new Random();
            int num = companies.Length - 1;

            string _output = companies[num] + new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return _output;
        }
    }
}

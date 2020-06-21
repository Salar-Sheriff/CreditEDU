using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolCreditSystem.Classes;
using Xamarin.Forms;


namespace SchoolCreditSystem
{
    public partial class StorePage : ContentPage
    {
        List<string> subjects = new List<string>
            {
                "Food Vouchers",
                "School Supplies",
                "Clothes",
                "College Fund",
                "Extracurricular Funds",
            };
        List<ImageSource> imgsources = new List<ImageSource>
        {
            "foodCoupon.jpg",
            "foodCoupon.jpg",
            "foodCoupon.jpg",
            "foodCoupon.jpg",
            "eraser.jpg",
            "pencil.png",
            "calculator.jpg",
            "sharpener.jpg",
            "tshirt.jpg",
            "jeans.jpg",
            "jacket.jpg",
            "shorts.jpg",
            "college.jpg",
            "college.jpg",
            "college.jpg",
            "college.jpg",
            "ball.jpg",
            "signup.jpg",
            "debate.png",
            "mathtextbook.jpg"

        };
        List<string> descript = new List<string>
        {
            "$10 Food Stamps - 2 Credits",
            "$20 Food Stamps - 4 Credits",
            "$25 Food Stamps - 6 Credits",
            "$40 Food Stamps - 8 Credits",
            "Erasers - 5 Credits",
            "Pencils - 3 Credits",
            "Calculator - 30 Credits",
            "Sharpener - 4 Credits",
            "T-Shirt - 60 Credits",
            "Jeans - 80 Credits",
            "Jacket - 40 Credits",
            "Shorts - 40 Credits",
            "College Funds - $1000 - 30 Credits",
            "College Funds - $2500 - 50 Credits",
            "College Funds - $5000 - 80 Credits",
            "College Funds - $75000 - 120 Credits",
            "Balls - 10 Credits",
            "Sports Sign Up - 15 Credits",
            "Debate Sign up - 30 Credits",
            "Academic Olympiad Textbook - 50 Credits"
        };
        List<int> cred = new List<int>
        {
            2,
            4,
            6,
            8,
            5,
            3,
            30,
            4,
            60,
            80,
            40,
            40,
            30,
            50,
            80,
            120,
            10,
            15,
            30,
            50

        };
        List<ShopItem> cart = new List<ShopItem>();
        public StorePage()
        {
            InitializeComponent();
            foreach (string item in subjects)
            {
                picker.Items.Add(item);
            }
            picker.SelectedIndex = 1;
            InitializeStoreImages();
        }
        void InitializeStoreImages()
        {
            int SelectIndex = picker.SelectedIndex;
            if (SelectIndex == 0)
            {
                FirstName.Source = imgsources[0];
                FirstItemSubjectLabel.Text = descript[0];
                SecondName.Source = imgsources[1];
                SecondItemSubjectLabel.Text = descript[1];
                ThirdName.Source = imgsources[2];
                ThirdItemSubjectLabel.Text = descript[2];
                FourthName.Source = imgsources[3];
                FourthItemSubjectLabel.Text = descript[3];
            }
            if (SelectIndex == 1)
            {
                FirstName.Source = imgsources[4];
                FirstItemSubjectLabel.Text = descript[4];
                SecondName.Source = imgsources[5];
                SecondItemSubjectLabel.Text = descript[5];
                ThirdName.Source = imgsources[6];
                ThirdItemSubjectLabel.Text = descript[6];
                FourthName.Source = imgsources[7];
                FourthItemSubjectLabel.Text = descript[7];
            }
            if (SelectIndex == 2)
            {
                FirstName.Source = imgsources[8];
                FirstItemSubjectLabel.Text = descript[8];
                SecondName.Source = imgsources[9];
                SecondItemSubjectLabel.Text = descript[9];
                ThirdName.Source = imgsources[10];
                ThirdItemSubjectLabel.Text = descript[10];
                FourthName.Source = imgsources[11];
                FourthItemSubjectLabel.Text = descript[11];
            }
            if (SelectIndex == 3)
            {
                FirstName.Source = imgsources[12];
                FirstItemSubjectLabel.Text = descript[12];
                SecondName.Source = imgsources[13];
                SecondItemSubjectLabel.Text = descript[13];
                ThirdName.Source = imgsources[14];
                ThirdItemSubjectLabel.Text = descript[14];
                FourthName.Source = imgsources[15];
                FourthItemSubjectLabel.Text = descript[15];
            }
            if (SelectIndex == 4)
            {
                FirstName.Source = imgsources[16];
                FirstItemSubjectLabel.Text = descript[16];
                SecondName.Source = imgsources[17];
                SecondItemSubjectLabel.Text = descript[17];
                ThirdName.Source = imgsources[18];
                ThirdItemSubjectLabel.Text = descript[18];
                FourthName.Source = imgsources[19];
                FourthItemSubjectLabel.Text = descript[19];
            }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int SelectIndex = picker.SelectedIndex;
            if (SelectIndex == 0)
            {
                FirstName.Source = imgsources[0];
                FirstItemSubjectLabel.Text = descript[0];
                SecondName.Source = imgsources[1];
                SecondItemSubjectLabel.Text = descript[1];
                ThirdName.Source = imgsources[2];
                ThirdItemSubjectLabel.Text = descript[2];
                FourthName.Source = imgsources[3];
                FourthItemSubjectLabel.Text = descript[3];
            }
            if (SelectIndex == 1)
            {
                FirstName.Source = imgsources[4];
                FirstItemSubjectLabel.Text = descript[4];
                SecondName.Source = imgsources[5];
                SecondItemSubjectLabel.Text = descript[5];
                ThirdName.Source = imgsources[6];
                ThirdItemSubjectLabel.Text = descript[6];
                FourthName.Source = imgsources[7];
                FourthItemSubjectLabel.Text = descript[7];
            }
            if (SelectIndex == 2)
            {
                FirstName.Source = imgsources[8];
                FirstItemSubjectLabel.Text = descript[8];
                SecondName.Source = imgsources[9];
                SecondItemSubjectLabel.Text = descript[9];
                ThirdName.Source = imgsources[10];
                ThirdItemSubjectLabel.Text = descript[10];
                FourthName.Source = imgsources[11];
                FourthItemSubjectLabel.Text = descript[11];
            }
            if (SelectIndex == 3)
            {
                FirstName.Source = imgsources[12];
                FirstItemSubjectLabel.Text = descript[12];
                SecondName.Source = imgsources[13];
                SecondItemSubjectLabel.Text = descript[13];
                ThirdName.Source = imgsources[14];
                ThirdItemSubjectLabel.Text = descript[14];
                FourthName.Source = imgsources[15];
                FourthItemSubjectLabel.Text = descript[15];
            }
            if (SelectIndex == 4)
            {
                FirstName.Source = imgsources[16];
                FirstItemSubjectLabel.Text = descript[16];
                SecondName.Source = imgsources[17];
                SecondItemSubjectLabel.Text = descript[17];
                ThirdName.Source = imgsources[18];
                ThirdItemSubjectLabel.Text = descript[18];
                FourthName.Source = imgsources[19];
                FourthItemSubjectLabel.Text = descript[19];
            }
        }

        async void First_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            bool buy = await DisplayAlert("ADD TO CART", "Are you sure you want to buy this?", "YES", "NO");
            if (buy == true)
            {
                cart.Add(new ShopItem(FirstItemSubjectLabel.Text, cred[(picker.SelectedIndex * 4)], FirstName.Source));
                await Navigation.PushAsync(new ShoppingCart(cart));
            }
        }
        async void Second_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            bool buy = await DisplayAlert("ADD TO CART", "Are you sure you want to buy this?", "YES", "NO");
            if (buy == true)
            {
                cart.Add(new ShopItem(SecondItemSubjectLabel.Text, cred[(picker.SelectedIndex * 4) + 1], SecondName.Source));
                await Navigation.PushAsync(new ShoppingCart(cart));
            }
        }
        async void Third_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            bool buy = await DisplayAlert("ADD TO CART", "Are you sure you want to buy this?", "YES", "NO");
            if (buy == true)
            {
                cart.Add(new ShopItem(ThirdItemSubjectLabel.Text, cred[(picker.SelectedIndex * 4) + 2], ThirdName.Source));
                await Navigation.PushAsync(new ShoppingCart(cart));
            }
        }
        async void Fourth_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            bool buy = await DisplayAlert("ADD TO CART", "Are you sure you want to buy this?", "YES", "NO");
            if (buy == true)
            {
                cart.Add(new ShopItem(FourthItemSubjectLabel.Text, cred[(picker.SelectedIndex * 4) + 3], FourthName.Source));
                await Navigation.PushAsync(new ShoppingCart(cart));
            }
        }
        void Go_To_Cart(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ShoppingCart(cart));
        }

    }
}

using System;
using Xamarin.Forms;

namespace TechnicalTest.Views
{
    public partial class DetailTip : ContentPage
    {
        public DetailTip()
        {
            InitializeComponent();
        }
        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            myPicker.Focus();
        }
    }
}

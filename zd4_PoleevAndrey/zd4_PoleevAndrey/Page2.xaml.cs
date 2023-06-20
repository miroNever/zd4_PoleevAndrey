using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd4_PoleevAndrey
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 :ContentPage
    {
        public Page2 ()
        {
            InitializeComponent();
        }
        private void USDChanged (object sender, TextChangedEventArgs e)
        {
            if (usdEntry.Text != "")
            {
                eurLabel.Text = (double.Parse(usdEntry.Text) * 1.075).ToString();
            }
        }
    }
}
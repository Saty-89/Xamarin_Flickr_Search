using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFlickr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public ICommand NavigateCommand { get; private set; }

        public HomePage()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                await Navigation.PushAsync((Page)Activator.CreateInstance(pageType));
            });

            BindingContext = this;
        }
    }
}
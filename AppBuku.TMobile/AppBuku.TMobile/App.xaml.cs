using Xamarin.Forms;

namespace AppBuku.TMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            // Set properties untuk aplikasi 
            this.Properties.Add("BaseWebUri", "http://appbuku.somee.com/");
            this.Properties.Add("WebUsername", "u007lavina");
            this.Properties.Add("WebPassword", "u007lav-@aqw72");


            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

using AppBuku.Models;
using AppBuku.Models.Data;
using AppBuku.TMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppBuku.TMobile.ViewModels
{
    public class BukuViewModel : BaseViewModel
    {
        Services.IBukuDataStore GetDataStore()
        {
            return DependencyService.Get<Services.IBukuDataStore>();
        }


        public BukuViewModel()
        {
            baseBukuProcessing = GetDataStore().GetBukuProcessing();
            bukuSet = baseBukuProcessing.GetAll();
            Title = "Daftar Buku";
            selectedBuku = null;
        }

        private BukuProcessing baseBukuProcessing;

        private List<Buku> bukuSet;
        public List<Buku> BukuSet
        {
            get { return bukuSet; }
            set { SetProperty(ref bukuSet, value); }
        }

        private ICommand cmdReload;
        public ICommand CmdReload
        {
            get
            {
                if (cmdReload == null)
                {
                    cmdReload = new Command(PerformCmdReload);
                }

                return cmdReload;
            }
        }

        private void PerformCmdReload()
        {
            IsBusy = true;
            BukuSet = baseBukuProcessing.GetAll();
            IsBusy = false;
        }

        private ICommand cmdAddBuku;
        public ICommand CmdAddBuku
        {
            get
            {
                if (cmdAddBuku == null)
                {
                    cmdAddBuku = new Command(PerformCmdAddBuku);
                }

                return cmdAddBuku;
            }
        }

        private async void PerformCmdAddBuku()
        {
            await Shell.Current.GoToAsync(nameof(BukuEditPage));
        }

        public Buku selectedBuku;
        public Buku SelectedBuku
        {
            get => selectedBuku;
            set
            {
                SetProperty(ref selectedBuku, value);
                PerformBukuTapped(value);
            }
        }

        private Command<Buku> bukuTapped;
        public Command<Buku> BukuTapped
        {
            get
            {
                if (bukuTapped == null)
                {
                    bukuTapped = new Command<Buku>(PerformBukuTapped);
                }

                return bukuTapped;
            }
        }

        async void PerformBukuTapped(Buku item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync(
                $"{nameof(BukuEditPage)}?{nameof(BukuEditViewModel.TheId)}={item.Id}");
        }

        public void OnAppearing()
        {
            IsBusy = true;
            // SelectedBuku = null;
        }
    }
}

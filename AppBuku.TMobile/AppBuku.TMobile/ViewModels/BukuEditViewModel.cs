using AppBuku.Models;
using AppBuku.Models.Data;
using Xamarin.Forms;
using System.Windows.Input;

namespace AppBuku.TMobile.ViewModels
{
    [QueryProperty(nameof(TheId), nameof(TheId))]
    public class BukuEditViewModel : BaseViewModel
    {
        Services.IBukuDataStore GetDataStore()
        {
            return DependencyService.Get<Services.IBukuDataStore>();
        }

        public BukuEditViewModel()
        {
            bukuEdit = new Buku();
            baseBukuProcessing = GetDataStore().GetBukuProcessing();
            hapusIsVisible = false;
            Title = "Buku (Baru)";
        }
        bool isNewItem = true;

        private BukuProcessing baseBukuProcessing;

        private Buku bukuEdit;
        public Buku BukuEdit
        {
            get { return bukuEdit; }
            set { SetProperty(ref bukuEdit, value); }
        }


        private string theId;
        public string TheId
        {
            get
            {
                return theId;
            }
            set
            {
                theId = value;
                LoadById(value);
            }
        }

        private void LoadById(string theId)
        {
            if (string.IsNullOrEmpty(theId))
                return;

            int id = 0;
            if (int.TryParse(theId, out id) == false)
                return;

            Buku b1 = baseBukuProcessing.Get(id);
            BukuEdit = b1;
            isNewItem = false;
            HapusIsVisible = true;
            Title = "Edit Buku";
        }

        private ICommand cmdBatal;
        public ICommand CmdBatal
        {
            get
            {
                if (cmdBatal == null)
                {
                    cmdBatal = new Command(PerformCmdBatal);
                }

                return cmdBatal;
            }
        }

        private async void PerformCmdBatal()
        {
            await Shell.Current.GoToAsync("..");
        }

        private ICommand cmdHapus;
        public ICommand CmdHapus
        {
            get
            {
                if (cmdHapus == null)
                {
                    cmdHapus = new Command(PerformCmdHapus);
                }

                return cmdHapus;
            }
        }

        private async void PerformCmdHapus()
        {
            bool jwb = await Application.Current.MainPage.DisplayAlert("Hapus data",
                "Apakah anda yakin untuk menghapus data ini?", "Ya", "Tidak");
            if (jwb)
            {
                baseBukuProcessing.Delete(BukuEdit.Id);
                await Shell.Current.GoToAsync("..");
            }
        }

        private ICommand cmdSimpan;
        public ICommand CmdSimpan
        {
            get
            {
                if (cmdSimpan == null)
                {
                    cmdSimpan = new Command(PerformCmdSimpan);
                }

                return cmdSimpan;
            }
        }

        private async void PerformCmdSimpan()
        {
            if (isNewItem)
            {
                baseBukuProcessing.Insert(BukuEdit);
            }
            else
            {
                baseBukuProcessing.Update(BukuEdit);
            }
            await Shell.Current.GoToAsync("..");
        }

        private bool hapusIsVisible;
        public bool HapusIsVisible
        {
            get => hapusIsVisible;
            set => SetProperty(ref hapusIsVisible, value);
        }
    }
}

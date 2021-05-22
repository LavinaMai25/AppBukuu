using AppBuku.Models.Data;
using AppBuku.Models;
using Xamarin.Essentials;

namespace AppBuku.TMobile.Services
{
    public class BukuDataStore : IBukuDataStore
    {
        BukuProcessing _bukuProcessing;

        public BukuDataStore()
        {
            _bukuProcessing = MakeBukuProcessing();

        }

        public BukuProcessing GetBukuProcessing()
        {
            return _bukuProcessing;
        }

        // pengolahan data buku
        private BukuProcessing MakeBukuProcessing()
        {
            string dbname = "buku.litedb";
            string dbFilename =
                System.IO.Path.Combine(FileSystem.AppDataDirectory, dbname);

            //if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP)
            //{

            //    //Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            //    string pathUtama = Environment.GetFolderPath(
            //        Environment.SpecialFolder.ApplicationData);
            //    dbFilename = System.IO.Path.Combine(pathUtama, dbname);
            //}

            BukuProcessing bukuProcessing =
                            new BukuProcessing(dbFilename);

            var bukuSet = bukuProcessing.GetAll();
            if (bukuSet.Count <= 0) // apabila tidak ada data buku
            {
                foreach (Buku item in Buku.Contoh())
                {
                    bukuProcessing.Insert(item);
                }

                bukuSet = bukuProcessing.GetAll();
            }
            return bukuProcessing;
        }


    }
}

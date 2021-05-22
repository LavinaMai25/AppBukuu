using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppBuku.Models.Data
{

    public class BukuProcessing
    {
        private string dbFilename;
        private string namaTabel = "buku";

        public BukuProcessing(string filename)
        {
            dbFilename = filename;
        }

        public List<Buku> GetAll()
        {
            // Buat koneksi database
            using (var db = new LiteDatabase(dbFilename))
            {
                // ambil koleksi
                var col = db.GetCollection<Buku>(namaTabel);
                return col.FindAll().ToList();
            }
        }

        public Buku Get(int id)
        {
            // Buat koneksi database
            using (var db = new LiteDatabase(dbFilename))
            {
                // ambil koleksi
                var col = db.GetCollection<Buku>(namaTabel);
                return col.FindById(id);
            }
        }

        // boleh void, boleh pakai bool 
        public string Insert(Buku buku)
        {
            try
            {
                // Buat koneksi database
                using (var db = new LiteDatabase(dbFilename))
                {
                    // ambil koleksi
                    var col = db.GetCollection<Buku>(namaTabel);
                    // lakukan proses insert
                    var id = col.Insert(buku);
                    return "S:" + id.ToString();
                }
            }
            catch (Exception ex)
            {
                return "E:" + ex.Message;
            }
        }

        public string Update(Buku buku)
        {
            try
            {
                // Buat koneksi database
                using (var db = new LiteDatabase(dbFilename))
                {
                    // ambil koleksi
                    var col = db.GetCollection<Buku>(namaTabel);

                    bool ada = col.Update(buku);
                    if (!ada)
                        return "E:Not Found";
                    else
                        return "S:" + buku.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                return "E:" + ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                // Buat koneksi database
                using (var db = new LiteDatabase(dbFilename))
                {
                    // ambil koleksi
                    var col = db.GetCollection<Buku>(namaTabel);

                    bool ada = col.Delete(id);
                    if (!ada)
                    {
                        return "E:Not Found";
                    }
                    else
                    {
                        return "S:" + id.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "E:" + ex.Message;
            }
        }
    }
}

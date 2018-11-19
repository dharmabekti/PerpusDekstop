using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerpusDekstop.DAO
{
    class Buku
    {
        //Attribute
        private string judul, pengarang, penerbit;
        private int tahun, id_kategori;

        //Constructor
        public Buku(string judul, string pengarang, string penerbit, int tahun, int id_kategori)
        {
            this.Judul = judul;
            this.Pengarang = pengarang;
            this.Penerbit = penerbit;
            this.Tahun = tahun;
            this.Id_kategori = id_kategori;
        }

        //Method
        public string Judul { get => judul; set => judul = value; }
        public string Pengarang { get => pengarang; set => pengarang = value; }
        public string Penerbit { get => penerbit; set => penerbit = value; }
        public int Tahun { get => tahun; set => tahun = value; }
        public int Id_kategori { get => id_kategori; set => id_kategori = value; }
    }
}

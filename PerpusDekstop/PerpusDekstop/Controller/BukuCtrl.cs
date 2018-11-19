using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using PerpusDekstop.DAO;

namespace PerpusDekstop.Controller
{
    class BukuCtrl
    {
        BukuDAO buku = new BukuDAO();

        public DataTable getBuku()
        {
            return buku.getBuku();
        }

        public DataTable getKategori()
        {
            return buku.getKategori();
        }

        public bool tambahBuku(Buku B)
        {
            return buku.tambahBuku(B);
        }

        public bool ubahBuku(Buku B, int idBuku)
        {
            return buku.ubahBuku(B, idBuku);
        }

        public bool hapusBuku(int id_buku)
        {
            return buku.hapusBuku(id_buku);
        }
    }
}

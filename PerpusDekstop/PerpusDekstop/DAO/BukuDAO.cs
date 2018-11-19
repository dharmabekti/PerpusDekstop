using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using PerpusDekstop.DAO;


namespace PerpusDekstop.DAO
{
    class BukuDAO
    {
        static DBConnection dbCon = new DBConnection();
        SqlConnection __sqlCon = new SqlConnection(dbCon.ConnectionString());
        SqlCommand command;
        SqlDataReader reader;
        SqlDataAdapter da;

        //Constructor
        public BukuDAO() {

        }

        public DataTable getBuku()
        {
            try
            {
                string query = @"SELECT b.id_buku, b.judul, b.pengarang, b. penerbit, b.tahun, 
                    k.nama_kategori FROM TBL_BUKU b 
                    JOIN TBL_KATEGORI k ON b.ID_KATEGORI = k.ID_KATEGORI";

                DataTable dt = new DataTable();
                command = new SqlCommand(query, __sqlCon);
                __sqlCon.Open();
                reader = command.ExecuteReader();

                dt.Load(reader);
                __sqlCon.Close();

                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable getKategori()
        {
            try
            {
                string query = @"SELECT * FROM TBL_KATEGORI";
                da = new SqlDataAdapter(query, __sqlCon);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool tambahBuku(Buku B)
        {
            try
            {
                string query = @"INSERT INTO TBL_BUKU(judul, pengarang, penerbit, tahun, id_kategori)
                    VALUES(@judul, @pengarang, @penerbit, @tahun, @id_kategori)";

                command = new SqlCommand(query, __sqlCon);
                command.Parameters.AddWithValue("@judul", B.Judul);
                command.Parameters.AddWithValue("@pengarang", B.Pengarang);
                command.Parameters.AddWithValue("@penerbit", B.Penerbit);
                command.Parameters.AddWithValue("@tahun", B.Tahun);
                command.Parameters.AddWithValue("@id_kategori", B.Id_kategori);
                __sqlCon.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (__sqlCon.State == ConnectionState.Open)
                {
                    __sqlCon.Close();
                }
            }
        }

        public bool ubahBuku(Buku B, int idBuku)
        {
            try
            {
                string query = @"UPDATE TBL_BUKU SET judul = @judul, pengarang = @pengarang, 
                    penerbit = @penerbit, tahun = @tahun, id_kategori = @id_kategori
                    WHERE id_buku = @idbuku";

                command = new SqlCommand(query, __sqlCon);
                command.Parameters.AddWithValue("@judul", B.Judul);
                command.Parameters.AddWithValue("@pengarang", B.Pengarang);
                command.Parameters.AddWithValue("@penerbit", B.Penerbit);
                command.Parameters.AddWithValue("@tahun", B.Tahun);
                command.Parameters.AddWithValue("@id_kategori", B.Id_kategori);
                command.Parameters.AddWithValue("@idbuku", idBuku);
                __sqlCon.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (__sqlCon.State == ConnectionState.Open)
                {
                    __sqlCon.Close();
                }
            }
        }

        public bool hapusBuku(int id_buku)
        {
            try
            {
                string query = @"DELETE FROM TBL_BUKU WHERE id_buku = @id_buku";

                command = new SqlCommand(query, __sqlCon);
                command.Parameters.AddWithValue("@id_buku", id_buku);
                __sqlCon.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (__sqlCon.State == ConnectionState.Open)
                {
                    __sqlCon.Close();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PerpusDekstop.Controller;
using PerpusDekstop.DAO;
using System.Data;

namespace PerpusDekstop
{
    public partial class Form1 : Form
    {
        BukuCtrl buku = new BukuCtrl();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            
            cbKategori.DataSource = buku.getKategori();
            cbKategori.ValueMember = "ID_KATEGORI";
            cbKategori.DisplayMember = "NAMA_KATEGORI";
        }

        private void RefreshGrid()
        {
            gvBuku.DataSource = buku.getBuku();

            //Untuk mengubah judul header Gridview
            gvBuku.Columns[0].HeaderText = "ID";
            gvBuku.Columns[1].HeaderText = "JUDUL BUKU";
            gvBuku.Columns[2].HeaderText = "PENGARANG";
            gvBuku.Columns[3].HeaderText = "PENERBIT";
            gvBuku.Columns[4].HeaderText = "TAHUN";
            gvBuku.Columns[5].HeaderText = "KATEGORI";

            //Untuk mengubah lebar kolom di Gridview
            gvBuku.Columns[0].Width = 50;
            gvBuku.Columns[1].Width = 250;
            gvBuku.Columns[2].Width = 100;
            gvBuku.Columns[3].Width = 100;
            gvBuku.Columns[4].Width = 50;
            gvBuku.Columns[5].Width = 100;
        }

        private void clearData()
        {
            txtJudul.Text = string.Empty;
            txtPenerbit.Text = string.Empty;
            txtPengarang.Text = string.Empty;
            txtTahun.Text = string.Empty;
            txtId.Text = string.Empty;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                string judul = txtJudul.Text;
                string pengarang = txtPengarang.Text;
                string penerbit = txtPenerbit.Text;
                int tahun = int.Parse(txtTahun.Text);
                int id_kategori = int.Parse(cbKategori.SelectedValue.ToString());
                
                Buku B = new Buku(judul, pengarang, penerbit, tahun, id_kategori);
                // Jika txtId null, berarti menambahkan data baru
                if (txtId.Text == string.Empty)
                {
                    if (buku.tambahBuku(B))
                    {
                        MessageBox.Show("Buku Berhasil Ditambahkan", "INFORMATION",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Gagal Menambahkan Buku", "WARNING",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else // Jika txtId not null, berarti mengubah data
                {
                    if (buku.ubahBuku(B, int.Parse(txtId.Text) ))
                    {
                        MessageBox.Show("Buku Berhasil Diubah", "INFORMATION",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Gagal Mengubah Buku", "WARNING",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                clearData();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "ERROR",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getColumn(DataGridView dg, int i)
        {
            string kolom = null;
            try
            {
                kolom = dg[dg.Columns[i].Index, dg.CurrentRow.Index].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "ERROR",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return kolom;
        }

        private void gvBuku_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = getColumn(gvBuku, 0);
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length > 0)
            {
                // mengambil nilai dari index pertama (judul)
                txtJudul.Text = getColumn(gvBuku, 1);

                // mengambil nilai dari index kedua (pengarang)
                txtPengarang.Text = getColumn(gvBuku, 2);

                // mengambil nilai dari index ketiga (penerbit)
                txtPenerbit.Text = getColumn(gvBuku, 3);

                // mengambil nilai dari index keempat (tahun)
                txtTahun.Text = getColumn(gvBuku, 4); 
            }
            else
            {
                MessageBox.Show("Pilih buku yang akan diubah", "WARNING",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if(txtId.Text.Length > 0)
            {
                DialogResult dr = MessageBox.Show("Yakin Ingin Menghapus Buku?", "Konfirmasi", 
                    MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (buku.hapusBuku(int.Parse(txtId.Text)))
                    {
                        RefreshGrid();
                        MessageBox.Show("Buku Telah Dihapus", "Informasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clearData();
            }
            else
            {
                MessageBox.Show("Pilih buku yang akan dihapus", "WARNING",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

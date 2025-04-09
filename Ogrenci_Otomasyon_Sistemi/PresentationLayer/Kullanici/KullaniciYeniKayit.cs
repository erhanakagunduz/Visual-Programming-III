using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ogrenci_Otomasyon_Sistemi.PocosLayer; //poco katmanını kullanacağız
using Ogrenci_Otomasyon_Sistemi.dbConn; //VT bağlanacağız
using Ogrenci_Otomasyon_Sistemi.BusinessLogicLayer; //iş katmanını kullanacağız

// Kullanıcı arayüzü katmanı (Presentation Layer) içindeki formları kullanmak için gereklidir
using Ogrenci_Otomasyon_Sistemi.PresentationLayer;

// Kullanıcı ile ilgili formların bulunduğu namespace
namespace Ogrenci_Otomasyon_Sistemi.PresentationLayer.Kullanici
{
    public partial class KullaniciYeniKayit : Form
    {
        private TblKullanicilarBLL _tblKullanicilarBLL;

        // Kurucu metot (Constructor) - Form oluşturulduğunda çağrılır
        public KullaniciYeniKayit()
        {
            // Form bileşenlerini başlatır
            //Form elemanlarını başlatan metottur. (Örn: Buton, TextBox vb.)
            InitializeComponent(); 
            _tblKullanicilarBLL = new TblKullanicilarBLL();
        }


        public void Listele()
        {
            VeriTabaniBaglantisi yeniBaglanti = new VeriTabaniBaglantisi();
            SqlCommand sorgu = new SqlCommand("Select * From tbl_kullanicilar", yeniBaglanti.baglanti);

            DataTable dataTable = new DataTable();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sorgu);
            sqlDataAdapter.Fill(dataTable);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            dataGridView1.DataSource = bindingSource;


        }

        // Ana Menü butonuna tıklandığında çalışan olay metodu
        private void btnAnaMenu_Click(object sender, EventArgs e)
        {
            // Ana Menü formunu oluşturur
            AnaMenu girisEkrani = new AnaMenu();

            // Ana Menü formunu açar
            girisEkrani.Show();

            // Mevcut formu kapatır
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TblKullanicilarPoco kullanicilar = new TblKullanicilarPoco();

            kullanicilar = _tblKullanicilarBLL.kaydetKullanici(txtID.Text,txtTcKimlikNo.Text,txtKullaniciAdi.Text,txtSifre.Text,txtIsim.Text,txtSoyisim.Text,txtBirimId.Text);

            MessageBox.Show("Yeni Kayıt İşlemi Başarılı","Mesaj Kutusu",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);

            Listele();

            txtID.Text = "";
            txtBirimId.Text = "";
            txtIsim.Text = "";
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            txtTcKimlikNo.Text = "";
            txtSoyisim.Text = "";

        }

        private void KullaniciYeniKayit_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTcKimlikNo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtKullaniciAdi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSifre.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtIsim.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSoyisim.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtBirimId.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();


        }
    }
}

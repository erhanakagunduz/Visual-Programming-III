using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ogrenci_otomasyon_sistemi.PresentationLayer;

namespace ogrenci_otomasyon_sistemi
{
    public partial class OturumAcilis : Form
    {
        public OturumAcilis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaMenu giris_ekrani = new AnaMenu();
            giris_ekrani.Show();
            this.Hide();
        }
    }
}

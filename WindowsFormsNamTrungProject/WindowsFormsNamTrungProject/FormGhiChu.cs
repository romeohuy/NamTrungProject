using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NamTrungProject
{
    public partial class FormGhiChu : Form
    {
        public string ghichu_ = null;
        public FormGhiChu()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ghichu_ = txtGhichu.Text;
            this.Dispose();
        }
    }
}

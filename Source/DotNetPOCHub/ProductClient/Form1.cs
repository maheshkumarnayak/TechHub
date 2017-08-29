using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductService.ProductInfoClient client = new ProductService.ProductInfoClient("BasicHttpBinding_IProductInfo");
            ProductService.Product obj = new ProductService.Product();
            obj.Name = txtProdName.Text;
            obj.Descripation = txtProdDesc.Text;
            obj.CPU = Convert.ToDouble(txtCPU.Text);
            obj.DiscountPer = Convert.ToSingle(txtDiscount.Text);
            var result= client.Insert(obj);
        }
    }
}

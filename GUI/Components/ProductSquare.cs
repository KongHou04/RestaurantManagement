using BUS.Models;
using DTO;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class ProductSquare : Button
    {
        public Product Product { get; set; }
        Main MainForm { get; set; }
        public ProductSquare(Main mainForm, Product product, Size size, Point point)
        {
            this.Product = product;
            this.Location = point;
            this.Size = size;
            this.MainForm = mainForm;
            Load();
        }
        private void Load()
        {
            Label tableNameLabel = new Label();
            Label priceLabel = new Label();

            tableNameLabel.Width = (int)(Width * 0.8);
            tableNameLabel.Text = this.Product.Name;
            tableNameLabel.Location = new Point((int)(Width * 0.1), (int)(Height * 0.4));
            tableNameLabel.ForeColor = Color.Black;
            tableNameLabel.Font = new Font(Font.FontFamily, 13, FontStyle.Bold);
            tableNameLabel.TextAlign = ContentAlignment.MiddleCenter;

            priceLabel.Width = (int)(Width * 0.4);
            priceLabel.Text = this.Product.UnitPrice.ToString();
            priceLabel.Location = new Point((int)(Width * 0.3), (int)(Height * 0.7));
            priceLabel.ForeColor = Color.Black;
            priceLabel.Font = new Font(Font.FontFamily, 9);
            priceLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(priceLabel);

            this.Controls.Add(tableNameLabel);
            this.BackColor = Color.LightGray;
            this.MouseClick += this.MainForm.ShowTableInfor;
        }
    }
}

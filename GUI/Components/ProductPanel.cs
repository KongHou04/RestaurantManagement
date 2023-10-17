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
    public class ProductPanel : Panel
    {
        List<Product> Products { get; set; }
        Category Category { get; set; }
        Main MainForm { get; set; }
        List<Product> ProductsClone{ get; set; } = new List<Product>();
        List<ProductSquare> ProductSquares { get; set; } = new List<ProductSquare>();
        public int Space { get; set; }
        public int ItemSize { get; set; }
        public int ItemTop { get; set; }
        public int VerticalSpace { get; set; }
        public bool IsShowTotal { get; set; }

        public ProductPanel(Main mainForm, List<Product> products, Category category, Size size, int itemSize, int space)
        {
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.MainForm = mainForm;
            this.Products = products;
            this.Size = size;
            this.Category = category;
            this.ItemSize = itemSize;
            this.Space = space;
            this.ItemTop = 70;
            this.VerticalSpace = 20;
            this.Load();
        }

        public void ConfigureItemTopnVSpace(int itemTop, int vSpace)
        {
            this.VerticalSpace = vSpace;
            this.ItemTop = itemTop;
            this.Load();
        }

        private void UpdateTableList()
        {
            this.ProductsClone = new List<Product>(this.Products);
            RemoveTableSquare();
            int i = 0;
            int j = 0;
            this.ProductsClone.ForEach((p) =>
            {
                this.ProductSquares.Add(new ProductSquare(this.MainForm, p, new Size(ItemSize, ItemSize), new Point(i * (ItemSize + Space) + Space, j * (ItemSize + this.VerticalSpace) + this.ItemTop)));
                j = (i == 4) ? j + 1 : j;
                i = (i == 4) ? 0 : i + 1;
            });
        }

        public void Load()
        {
            UpdateTableList();
            this.ProductSquares.ForEach((tq) =>
            {
                this.Controls.Add(tq);
            });
        }

        private void RemoveTableSquare()
        {
            this.ProductSquares.ForEach(pq =>
            {
                this.Controls.Remove(pq);
            });
            this.ProductSquares.Clear();
        }
    }
}

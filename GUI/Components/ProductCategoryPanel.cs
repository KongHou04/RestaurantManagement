using DTO;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class ProductCategoryPanel : Panel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public Category Category { get; set; }
        Main MainForm { get; set; }

        public ProductCategoryPanel(Main mainForm, List<Category> categories, List<Product> products, Size size, Category category)
        {
            this.Categories = categories;
            this.Products = products;
            this.Size = size;
            this.Location = new Point(15, 10);
            this.Category = category;
            this.MainForm = mainForm;
            this.Load();
        }

        private void Load()
        {
            CategoryContainerPanel categoryContainerPanel = new CategoryContainerPanel(this.MainForm, this.Categories, new Size(200, this.Height), new Point(0, 0), this.Category);
            this.Controls.Add(categoryContainerPanel);
            List<Product> loadProducts = this.Products.Where(p => p.CategoryID == this.Category.ID).ToList();
            ProductContainerPanel productContainerPanel = new ProductContainerPanel(this.MainForm, loadProducts, new Size(740, this.Height), new Point(210, 0), this.Category);
            this.Controls.Add(productContainerPanel);
        }
    }
}

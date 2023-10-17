using DTO;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class CategorySquare : Button
    {
        public Category Category;
        Main MainForm { get; set; }
        bool IsTargeted = false;
        public CategorySquare(Main mainForm, Category category, Size size, Point point, bool isTargeted)
        {
            this.Category = category;
            this.Location = point;
            this.Size = size;
            this.MainForm = mainForm;
            this.IsTargeted = isTargeted;
            Load();
        }
        private void Load()
        {
            Label tableNameLabel = new Label();

            tableNameLabel.Width = (int)(Width * 0.4);
            tableNameLabel.Location = new Point((int)(Width * 0.3), 11);
            tableNameLabel.Text = this.Category.Name;
            tableNameLabel.ForeColor = Color.Black;
            tableNameLabel.Font = new Font(Font.FontFamily, 13, FontStyle.Bold);
            tableNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            tableNameLabel.AutoSize = false;

            this.Controls.Add(tableNameLabel);
            if (this.IsTargeted)
                this.BackColor = Color.Silver;
            else
                this.BackColor = Color.LightGray;
            this.Click += this.MainForm.button2_Click;
        }
    }
}

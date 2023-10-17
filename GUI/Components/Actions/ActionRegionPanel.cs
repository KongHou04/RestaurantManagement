using BUS.Repository.Implements.Setters;
using BUS.Repository.Interfaces.Setters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components.Actions
{
    public class ActionRegionPanel : Panel
    {
        private bool isAddPanel;
        private Button btnAdd = new Button();
        private Button btnClear = new Button();
        private Button btnSave = new Button();
        private Button btnDelete = new Button();
        private new DTO.Region? Region;
        private Label lblTitle = new Label();
        private Label lblName = new Label();
        private Label lblDescription = new Label();
        private TextBox txtBoxName = new TextBox();
        private TextBox txtBoxDescription = new TextBox();
        private IRegionBUS regionBUS;

        public ActionRegionPanel(IRegionBUS regionBUS, Size size, Point point, bool isAddPanel = true, DTO.Region? region = null) 
        { 
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Size = size;
            this.Location = point;
            this.Region = region;
            this.isAddPanel = isAddPanel;
            this.regionBUS = regionBUS;

            this.Load();
        }

        private void Load()
        {
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = ContentAlignment.MiddleCenter;
            this.btnAdd.Size = new Size(150, 50);
            this.btnAdd.Location = new Point((int)(this.Width * 0.9) - 150, (int)(this.Height * 0.9));
            this.btnAdd.Click += async (o, e) =>
            {
                MessageBox.Show(await regionBUS.AddRegion(this.txtBoxName.Text, true, this.txtBoxDescription.Text));
            };

            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = ContentAlignment.MiddleCenter;
            this.btnClear.Size = new Size(150, 50);
            this.btnClear.Location = new Point((int)(this.Width * 0.9) - 320, (int)(this.Height * 0.9));
            this.btnClear.Click += BtnClear_Click;

            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = ContentAlignment.MiddleCenter;
            this.btnDelete.Size = new Size(150, 50);
            this.btnDelete.Location = new Point((int)(this.Width * 0.1), (int)(this.Height * 0.9));

            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = ContentAlignment.MiddleCenter;
            this.btnSave.Size = new Size(150, 50);
            this.btnSave.Location = new Point((int)(this.Width * 0.9) - 150, (int)(this.Height * 0.9));

            this.lblTitle.Text = "Add new Region";
            this.lblTitle.AutoSize = false;
            this.lblTitle.Size = new Size(400, 30);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new Point((int)(this.Width * 0.5) - 200, 10);
            this.lblTitle.Font = new Font(Font.FontFamily, 13, FontStyle.Bold);

            this.lblName.Text = "Name";
            this.lblName.AutoSize = false;
            this.lblName.Size = new Size(100, 30);
            this.lblName.TextAlign = ContentAlignment.MiddleLeft;
            this.lblName.Location = new Point((int)(this.Width * 0.1), 140);

            this.lblDescription.Text = "Description";
            this.lblDescription.AutoSize = false;
            this.lblDescription.Size = new Size(100, 30);
            this.lblDescription.TextAlign = ContentAlignment.MiddleLeft;
            this.lblDescription.Location = new Point((int)(this.Width * 0.1), 180);

            this.txtBoxName.Size = new Size(300, 30);
            this.txtBoxName.Location = new Point((int)(this.Width * 0.1) + 150, 140);

            this.txtBoxDescription.Size = new Size(300, 30);
            this.txtBoxDescription.Location = new Point((int)(this.Width * 0.1) + 150, 180);


            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.txtBoxDescription);


            this.Controls.Add(btnClear);
            if (this.isAddPanel)
            {
                this.Controls.Add(btnAdd);
            }
            else
            {
                this.Controls.Add(btnDelete);
                this.Controls.Add(btnSave);
            }
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            this.txtBoxName.Text = string.Empty;
            this.txtBoxDescription.Text = string.Empty;
        }
    }
}

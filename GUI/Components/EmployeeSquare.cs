using DTO;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class EmployeeSquare : Panel
    {
        string imagePath = @"../../../Images/";
        Employee Employee { get; set; }
        Main MainForm { get; set; }
        PictureBox PictureBox = new PictureBox();
        TextBox NameTxtBox = new TextBox();
        TextBox EmailTxtBox = new TextBox();
        public EmployeeSquare(Main mainForm, Employee employee, Size size, Point point)
        {
            this.Employee = employee;
            this.Location = point;
            this.Size = size;
            this.MainForm = mainForm;
            Load();
        }

        public void ChangeImagePath(string imagePath)
        {
            this.imagePath = imagePath;
        }
        private void Load()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            
            this.PictureBox.Image = Image.FromFile(imagePath + ((this.Employee.Avatar == null)? "0.png" : this.Employee.Avatar));
            this.PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox.Width = this.Width;
            this.PictureBox.Height = (int)(this.Width * 1.3);
            this.PictureBox.Location = new Point(0, 0);

            this.NameTxtBox.AutoSize = false;
            this.NameTxtBox.Width = this.Width;
            this.NameTxtBox.Height = 30;
            this.NameTxtBox.Location = new Point(0, (int)(this.Width * 1.3));
            this.NameTxtBox.Text = this.Employee.Name;
            this.NameTxtBox.ForeColor = Color.Black;
            this.NameTxtBox.Font = new Font(Font.FontFamily, 11);
            this.NameTxtBox.ReadOnly = true;
            this.NameTxtBox.TextAlign = HorizontalAlignment.Center;

            this.EmailTxtBox.AutoSize = false;
            this.EmailTxtBox.Size = new Size(this.Width, 20);
            this.EmailTxtBox.Location = new Point(0, (int)(this.Width * 1.3) + 30);
            this.EmailTxtBox.Text = this.Employee.Email;
            this.EmailTxtBox.ForeColor = Color.Black;
            this.EmailTxtBox.Font = new Font(Font.FontFamily, 9);
            this.EmailTxtBox.TextAlign = HorizontalAlignment.Center;
            this.EmailTxtBox.ReadOnly = true;

            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.NameTxtBox);
            this.Controls.Add(this.EmailTxtBox);
            this.Click += this.MainForm.button3_Click;
        }
    }
}

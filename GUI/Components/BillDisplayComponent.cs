using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class BillDisplayComponent : Panel
    {
        public Bill Bill { get; set; }
        Label Label1 { get; set; } = new Label();
        Label Label2 { get; set; } = new Label();
        Label Label3 { get; set; } = new Label();
        Label Label4 { get; set; } = new Label();
        Label Label5 { get; set; } = new Label();
        public BillDisplayComponent(Bill bill, Size size, Point point)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Bill = bill;
            this.Size = size;
            this.Location = point;
            this.Font = new Font(Font.FontFamily, 11);

            this.Label1.Text = this.Bill.ID.ToString();
            this.Label1.AutoSize = false;
            this.Label1.Size = new Size((int)(this.Width*0.1), this.Height);
            this.Label1.Location = new Point(0, 0);

            this.Label2.Text = this.Bill.CustomerName;
            this.Label2.AutoSize = false;
            this.Label2.Size = new Size((int)(this.Width * 0.2), this.Height);
            this.Label2.Location = new Point((int)(this.Width * 0.1), 0);

            this.Label3.Text = this.Bill.Total.ToString();
            this.Label3.AutoSize = false;
            this.Label3.Size = new Size((int)(this.Width * 0.2), this.Height);
            this.Label3.Location = new Point((int)(this.Width * 0.3), 0);

            this.Label4.Text = this.Bill.BillTime.ToShortDateString();
            this.Label4.AutoSize = false;
            this.Label4.Size = new Size((int)(this.Width * 0.3), this.Height);
            this.Label4.Location = new Point((int)(this.Width * 0.5), 0);

            this.Label5.Text = (this.Bill.OrderID == null)? "unknown" : this.Bill.OrderID.ToString();
            this.Label5.AutoSize = false;
            this.Label5.Size = new Size((int)(this.Width * 0.1), this.Height);
            this.Label5.Location = new Point((int)(this.Width * 0.8), 0);

            this.Load();
        }

        public void Load()
        {
            this.Controls.Add(Label1);
            this.Controls.Add(Label2);
            this.Controls.Add(Label3);
            this.Controls.Add(Label4);
            this.Controls.Add(Label5);
        }

    }
}

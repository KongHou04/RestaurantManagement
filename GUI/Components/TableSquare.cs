using BUS.Models;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class TableSquare : Button
    {
        public TableOrder TableOrder { get; set; }
        Main MainForm { get; set; }
        bool isShowTotal = false;
        public TableSquare(Main mainForm, TableOrder tableOrder, Size size, Point point, bool isShowTotal)
        {
            TableOrder = tableOrder;
            this.Location = point;
            this.Size = size;
            this.MainForm = mainForm;
            this.isShowTotal = isShowTotal;
            Load();
        }
        private void Load()
        {
            Label tableNameLabel = new Label();
            Label totalLabel = new Label();

            tableNameLabel.Width = (int)(Width * 0.8);
            tableNameLabel.Text = TableOrder.Table.Name;
            tableNameLabel.Location = new Point((int)(Width * 0.1), (int)(Height*0.4));
            tableNameLabel.ForeColor = Color.Black;
            tableNameLabel.Font = new Font(Font.FontFamily, 13, FontStyle.Bold);
            tableNameLabel.TextAlign = ContentAlignment.MiddleCenter;

            if (isShowTotal)
            {
                totalLabel.Width = (int)(Width * 0.4);
                totalLabel.Text = TableOrder.Total.ToString();
                totalLabel.Location = new Point((int)(Width * 0.3), (int)(Height * 0.8));
                totalLabel.ForeColor = Color.Black;
                totalLabel.Font = new Font(Font.FontFamily, 9);
                totalLabel.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(totalLabel);
            }

            this.Controls.Add(tableNameLabel);
            this.BackColor = Color.LightGray;
            this.MouseClick += this.MainForm.ShowTableInfor;
        }


    }
}

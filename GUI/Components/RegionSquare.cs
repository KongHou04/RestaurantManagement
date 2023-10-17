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
    public class RegionSquare : Button
    {
        private DTO.Region _region;
        public new DTO.Region Region => _region;
        Main MainForm { get; set; }
        bool IsTargeted = false;
        public RegionSquare(Main mainForm, DTO.Region region, Size size, Point point, bool isTargeted)
        {
            _region = region;
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
            tableNameLabel.Text = this.Region.Name;
            tableNameLabel.ForeColor = Color.Black;
            tableNameLabel.Font = new Font(Font.FontFamily, 13, FontStyle.Bold);
            tableNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            tableNameLabel.AutoSize = false;

            this.Controls.Add(tableNameLabel);
            if (this.IsTargeted)
                this.BackColor = Color.Silver;
            else
                this.BackColor = Color.LightGray;
            this.Click += this.MainForm.button3_Click;
        }


    }
}

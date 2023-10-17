using DTO;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class BillContainerPanel : Panel
    {
        List<Bill> Bills { get; set; }
        SplitContainer SplitContainer { get; set; }
        public int ItemSize { get; set; }
        Main MainForm { get; set; }

        public BillContainerPanel(Main mainForm, List<Bill> bills, Size size, Point point)
        {
            this.MainForm = mainForm;
            this.Bills = bills;
            this.Size = size;
            this.Location = point;
            this.Name = "Bill";
            this.Font = new Font(Font.FontFamily, 15);

            SplitContainer = new SplitContainer();
            SplitContainer.Dock = DockStyle.Fill;
            SplitContainer.FixedPanel = FixedPanel.Panel1;
            SplitContainer.Size = this.Size;
            SplitContainer.Location = new Point(0, 0);
            SplitContainer.Name = "splitContainer";
            SplitContainer.Panel1.BackColor = Color.FromArgb(224, 224, 224);
            SplitContainer.Panel2.BackColor = Color.FromArgb(224, 224, 224);
            SplitContainer.SplitterDistance = 80;
            SplitContainer.Orientation = Orientation.Horizontal;
            SplitContainer.SplitterWidth = 1;
            SplitContainer.Panel2.AutoScroll = true;
            SplitContainer.BackColor = Color.Black;

            ItemSize = (int)(this.Width * 0.8);

            this.Controls.Add(SplitContainer);
            this.Load();
        }
        private void Load()
        {
            ControlsPanel regionControlsPanel = new ControlsPanel(this.MainForm, this.Size.Width, true, "Add New Bill");
            this.SplitContainer.Panel1.Controls.Add(regionControlsPanel);
            BillPanel billPanel = new BillPanel(/*new Forms.Main(),*/ this.Bills, new Size(this.Width, this.Height - 80), 25, (int)(this.Width * 0.04));
            billPanel.ConfigureItemTopnVSpace(20, 5);
            this.SplitContainer.Panel2.Controls.Add(billPanel);
        }



    }
}

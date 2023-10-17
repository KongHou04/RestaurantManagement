using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Components
{
    public class RegionContainerPanel : Panel
    {
        List<DTO.Region> Regions { get; set; }
        SplitContainer SplitContainer { get; set; }
        public int ItemSize { get; set; }
        Main MainForm { get; set; }
        new DTO.Region Region { get; set; }

        public RegionContainerPanel(Main mainForm, List<DTO.Region> regions, Size size, Point point, DTO.Region region)
        {
            this.Regions = regions;
            this.Size = size;
            this.Location = point;
            this.Name = "Regions";
            this.Font = new Font(Font.FontFamily, 15);
            this.MainForm = mainForm;
            this.Region = region;

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
            int i = new int();
            ControlsPanel regionControlsPanel = new ControlsPanel(this.MainForm, this.Size.Width, true, "Add New Region");
            regionControlsPanel.ConfigureAddButtonEvent("region");
            this.SplitContainer.Panel1.Controls.Add(regionControlsPanel);
            Regions.ForEach(r =>
            {
                this.SplitContainer.Panel2.Controls.Add(new RegionSquare(this.MainForm, r, new Size(ItemSize, 50), new Point((int)(this.Width * 0.1), i * (50 + 10) + 20), (r.ID == this.Region.ID)? true : false));
                i += 1;
            });
        }
    }
}

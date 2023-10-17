using DTO;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class TableRegionPanel : Panel
    {
        public List<DTO.Region> Regions {  get; set; }
        public List<Table> Tables { get; set; }
        public new DTO.Region Region { get; set; }
        Main MainForm { get; set; }

        public TableRegionPanel(Main mainForm, List<DTO.Region> regions, List<Table> tables, Size size, DTO.Region region)
        {
            this.Regions = regions;
            this.Tables = tables;
            this.Size = size;
            this.Location = new Point(15, 10);
            this.Region = region;
            this.MainForm = mainForm;
            this.Load();
        }

        private void Load()
        {
            RegionContainerPanel regionContainerPanel = new RegionContainerPanel(this.MainForm, this.Regions, new Size(200, this.Height), new Point(0, 0), this.Region);
            this.Controls.Add(regionContainerPanel);
            List<Table> loadTables = this.Tables.Where(t => t.RegionID == this.Region.ID).ToList();
            TableContainerPanel tableContainerPanel = new TableContainerPanel(this.MainForm, loadTables, new Size(740, this.Height), new Point(210, 0), this.Region);
            this.Controls.Add(tableContainerPanel);
        }

    }
}

using BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using GUI.Forms;

namespace GUI.Components
{
    public class TableOrderPanel : Panel
    {
        public List<TableOrder> TableOrders { get; set; }
        public List<DTO.Region> Regions { get; set; }
        TabControl TabControl { get; set; }
        Main MainForm { get; set; }
        public TableOrderPanel(Main mainForm, List<TableOrder> tableOrders, List<DTO.Region> regions, int size)
        {
            this.Dock = DockStyle.Fill;
            this.TableOrders = tableOrders;
            this.Regions = regions;
            this.TabControl = new TabControl();
            this.TabControl.Width = size;
            this.TabControl.Dock = DockStyle.Fill;
            this.Font = new Font(Font.FontFamily, 16);
            this.Controls.Add(TabControl);
            this.MainForm = mainForm;
            LoadTabPage();
        }

        private void LoadTabPage()
        {
            
            Regions.ForEach(r =>
            {
                List<TableOrder> toByRegion = TableOrders.Where(to => to.Table.RegionID == r.ID).ToList();
                this.TabControl.TabPages.Add(new TableTabPage(this.MainForm, toByRegion, r, new Size(1000, 550)));
            });
        }


    }
}

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
    public class TableContainerPanel : Panel
    {
        List<Table> Tables { get; set; }
        new DTO.Region Region { get; set; }
        SplitContainer SplitContainer { get; set; }
        List<TableOrder> TableOrders { get; set; } = new List<TableOrder>();
        public int ItemSize { get; set; }
        Main MainForm { get; set; }

        public TableContainerPanel(Main mainForm, List<Table> tables, Size size, Point point, DTO.Region region)
        {
            this.MainForm = mainForm;
            this.Region = region;
            this.Tables = tables;
            this.Size = size;
            this.Location = point;
            this.Name = "Table";
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

            this.Tables.ForEach((t) =>
            {
                this.TableOrders.Add(new TableOrder(t));
            });

            this.Controls.Add(SplitContainer);
            this.Load();
        }
        private void Load()
        {
            ControlsPanel regionControlsPanel = new ControlsPanel(this.MainForm, this.Size.Width, true, "Add New Table");
            this.SplitContainer.Panel1.Controls.Add(regionControlsPanel);
            TablePanel tablePanel = new TablePanel(new Forms.Main(), this.TableOrders, this.Region, new Size(this.Width, this.Height - 80), (int)(this.Width * 0.15), (int)(this.Width * 0.04), false);
            tablePanel.ConfigureItemTopnVSpace(20, 20);
            this.SplitContainer.Panel2.Controls.Add(tablePanel);
        }
    }
}

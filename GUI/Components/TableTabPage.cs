using BUS.Models;
using DTO;
using GUI.Forms;
using System.Net.Http.Headers;

namespace GUI.Components
{
    public class TableTabPage : TabPage
    {
        List<TableOrder> TableOrders { get; set; }
        new DTO.Region Region { get; set; }
        CheckBox CheckBox { get; set; }
        public TablePanel VisiblePanel { get; set; }
        Main MainForm { get; set; }


        public TableTabPage(Main mainForm, List<TableOrder> tableOrders, DTO.Region region, Size size)
        {
            this.TableOrders = tableOrders;
            this.Region = region;
            this.Text = Region.Name;
            this.Size = size;
            this.CheckBox = new CheckBox();
            this.CheckBox.Text = "Show ordered tables";
            this.CheckBox.Location = new Point(790, 25);
            this.CheckBox.Size = new Size(150, 20);
            this.CheckBox.Font = new Font(Font.FontFamily, 9);
            this.Controls.Add(this.CheckBox);
            this.Font = new Font(Font.FontFamily, 13);
            this.CheckBox.Click += CheckBox_Click;
            this.TableOrders = this.TableOrders.OrderBy(to => to.Table.ID).ToList();
            this.MainForm = mainForm;
            this.Controls.Add(VisiblePanel);
            this.VisiblePanel = new TablePanel(mainForm, TableOrders, Region, this.Size, (int)(this.Width * 0.15), (int)(this.Width * 0.035), true);
            this.Controls.Add(this.VisiblePanel);
            CheckBox_Click(new object(), new EventArgs());
        }

        private void CheckBox_Click(object? sender, EventArgs e)
        {
            VisiblePanel.Load(this.CheckBox.Checked);
        }

    }
}

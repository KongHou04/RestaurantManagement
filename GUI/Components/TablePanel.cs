using BUS.Models;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class TablePanel : Panel
    {
        List<TableOrder> TableOrders { get; set; }
        new DTO.Region Region { get; set; }
        Main MainForm { get; set; }
        List<TableOrder> TableOrdersClone { get; set; } = new List<TableOrder>();
        List<TableSquare> TableSquares { get; set; } = new List<TableSquare>();
        public int Space { get; set; }
        public int ItemSize { get; set; }
        public int ItemTop { get; set; }
        public int VerticalSpace { get; set; }
        public bool IsShowTotal { get; set; }

        public TablePanel(Main mainForm, List<TableOrder> tableOrders, DTO.Region region, Size size, int itemSize, int space, bool isShowTotal)
        {
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.MainForm = mainForm;
            this.TableOrders = tableOrders;
            this.Size = size;
            this.Region = region;
            this.ItemSize = itemSize;
            this.Space = space;
            this.IsShowTotal = isShowTotal;
            this.ItemTop = 70;
            this.VerticalSpace = 20;
            this.Load(false);
        }

        public void ConfigureItemTopnVSpace(int itemTop, int vSpace)
        {
            this.VerticalSpace = vSpace;
            this.ItemTop = itemTop;
            this.Load();
        }

        private void UpdateTableList(bool isShowOrderd)
        {
            this.TableOrdersClone = new List<TableOrder>(this.TableOrders);
            RemoveTableSquare();
            int i = 0;
            int j = 0;
            if (isShowOrderd)
                TableOrdersClone = TableOrdersClone.Where(to => to.OrderID != null).ToList();
            TableOrdersClone.ForEach((tor) =>
            {
                TableSquares.Add(new TableSquare(this.MainForm, tor, new Size(ItemSize, ItemSize), new Point(i * (ItemSize + Space) + Space, j * (ItemSize + this.VerticalSpace) + this.ItemTop), this.IsShowTotal));
                j = (i == 4) ? j + 1 : j;
                i = (i == 4) ? 0 : i + 1;
            });
        }

        public void Load(bool isShowOrderd = false)
        {
            UpdateTableList(isShowOrderd);
            TableSquares.ForEach((tq) =>
            {
                this.Controls.Add(tq);
            });
        }

        private void RemoveTableSquare()
        {
            TableSquares.ForEach(tq =>
            {
                this.Controls.Remove(tq);
            });
            TableSquares.Clear();
        }

    }
}

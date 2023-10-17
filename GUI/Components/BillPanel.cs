using DTO;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class BillPanel : Panel
    {
        List<Bill> Bills { get; set; }
        List<Bill> BillsClone { get; set; } = new List<Bill>();
        List<BillDisplayComponent> BillDisplayComponents { get; set; } = new List<BillDisplayComponent>();
        public int Space { get; set; }
        public int ItemSize { get; set; }
        public int ItemTop { get; set; }
        public int VerticalSpace { get; set; }


        public BillPanel(/*Main mainForm,*/ List<Bill> bills, Size size, int itemSize, int space)
        {
            this.Bills = bills;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            //this.MainForm = mainForm;
            this.Size = size;
            this.ItemSize = itemSize;
            this.Space = space;
            this.ItemTop = 20;
            this.VerticalSpace = 10;
            this.Load();
        }

        public void ConfigureItemTopnVSpace(int itemTop, int vSpace)
        {
            this.VerticalSpace = vSpace;
            this.ItemTop = itemTop;
            this.Load();
        }

        private void UpdateTableList()
        {
            this.BillsClone = new List<Bill>(this.Bills);
            RemoveTableSquare();
            int i = 0;
            this.BillsClone.ForEach((b) =>
            {
                this.BillDisplayComponents.Add(new BillDisplayComponent(/*this.MainForm*/ b, new Size((int)(this.Width*0.8), 25), new Point((int)(this.Width * 0.1), i * (ItemSize + this.VerticalSpace) + this.ItemTop)));
                i += 1;
            });
        }

        public void Load()
        {
            UpdateTableList();
            this.BillDisplayComponents.ForEach((bc) =>
            {
                this.Controls.Add(bc);
            });
        }

        private void RemoveTableSquare()
        {
            this.BillDisplayComponents.ForEach(eq =>
            {
                this.Controls.Remove(eq);
            });
            this.BillDisplayComponents.Clear();
        }
    }
}

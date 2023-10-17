using DTO;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class EmployeePanel : Panel
    {
        List<Employee> Employees { get; set; }
        Main MainForm { get; set; }
        List<Employee> EmployeesClone { get; set; } = new List<Employee>();
        List<EmployeeSquare> EmployeeSquares { get; set; } = new List<EmployeeSquare> ();
        public int Space { get; set; }
        public int ItemSize { get; set; }
        public int ItemTop { get; set; }
        public int VerticalSpace { get; set; }

        public EmployeePanel(Main mainForm, List<Employee> employees, Size size, int itemSize, int space)
        {
            this.Employees = employees;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.MainForm = mainForm;
            this.Size = size;
            this.ItemSize = itemSize;
            this.Space = space;
            this.ItemTop = 70;
            this.VerticalSpace = 20;
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
            this.EmployeesClone = new List<Employee>(this.Employees);
            RemoveTableSquare();
            int i = 0;
            int j = 0;
            this.EmployeesClone.ForEach((e) =>
            {
                this.EmployeeSquares.Add(new EmployeeSquare(this.MainForm, e, new Size(ItemSize, (int)(ItemSize*1.7) - 6), new Point(i * (ItemSize + Space) + Space, j * (ItemSize + this.VerticalSpace) + this.ItemTop)));
                j = (i == 4) ? j + 1 : j;
                i = (i == 4) ? 0 : i + 1;
            });
        }

        public void Load()
        {
            UpdateTableList();
            this.EmployeeSquares.ForEach((tq) =>
            {
                this.Controls.Add(tq);
            });
        }

        private void RemoveTableSquare()
        {
            this.EmployeeSquares.ForEach(eq =>
            {
                this.Controls.Remove(eq);
            });
            this.EmployeeSquares.Clear();
        }
    }
}

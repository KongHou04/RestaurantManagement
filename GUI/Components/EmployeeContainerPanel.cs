using DTO;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class EmployeeContainerPanel : Panel
    {
        List<Employee> Employees { get; set; }
        SplitContainer SplitContainer { get; set; }
        public int ItemSize { get; set; }
        Main MainForm { get; set; }

        public EmployeeContainerPanel(Main mainForm, List<Employee> employees, Size size, Point point)
        {
            this.MainForm = mainForm;
            this.Employees = employees;
            this.Size = size;
            this.Location = point;
            this.Name = "Employee";
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
            ControlsPanel regionControlsPanel = new ControlsPanel(this.MainForm, this.Size.Width, true, "Add New Employee", "Employee");
            regionControlsPanel.AddTitle = true;
            regionControlsPanel.ConfigureLocation(new Point(700, 27), new Point(500, 25), new Point(0, 25));
            regionControlsPanel.ConfigureSize(new Size(200, 30), new Size(150, 30), new Size(150, 30));
            this.SplitContainer.Panel1.Controls.Add(regionControlsPanel);
            EmployeePanel employeePanel = new EmployeePanel(new Forms.Main(), this.Employees, new Size(this.Width, this.Height - 80), (int)(this.Width * 0.15), (int)(this.Width * 0.04));
            employeePanel.ConfigureItemTopnVSpace(20, 20);
            this.SplitContainer.Panel2.Controls.Add(employeePanel);
        }
    }
}

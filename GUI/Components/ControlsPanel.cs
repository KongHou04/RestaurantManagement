using GUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Components
{
    public class ControlsPanel : Panel
    {
        Button BtnAdd { get; set; } = new Button();
        TextBox TxBoxSearch { get; set; }
        Label TitleLabel { get; set; } = new Label();
        bool AddButtonNew { get; set; }
        public bool AddTitle { get; set; } = false;

        Main MainForm { get; set; }

        public ControlsPanel(Main mainForm, int width, bool addButtonNew, string? buttonAddText = null, string? title = null)
        {
            this.Width = width;
            this.AddButtonNew = addButtonNew;
            this.MainForm = mainForm;
            
            this.TxBoxSearch = new TextBox();
            this.TxBoxSearch.Width = (int)(this.Width * 0.8);
            this.TxBoxSearch.Text = "Search by Name";
            this.TxBoxSearch.Left = (int)(this.Width * 0.1);
            this.TxBoxSearch.Font = new Font(Font.FontFamily, 9);
            this.TxBoxSearch.Top = 10;
            this.Height = 100;

            if (AddButtonNew)
            {
                this.BtnAdd.Text = buttonAddText;
                this.BtnAdd.Width = (int)(this.Width * 0.8);
                this.BtnAdd.Height = 30;
                this.BtnAdd.Left = (int)(this.Width * 0.1);
                this.BtnAdd.Font = new Font(Font.FontFamily, 10, FontStyle.Bold);
                this.BtnAdd.Top = 40;
                this.Height = 80;
            }

            this.TitleLabel.Width = 150;
            this.TitleLabel.Text = title ?? String.Empty;
            this.TitleLabel.Font = new Font(Font.FontFamily, 17, FontStyle.Bold);

            Load();
        }

        public void Load()
        {
            this.Controls.Add(this.TxBoxSearch);
            if (AddButtonNew)
                this.Controls.Add(this.BtnAdd);
            if (AddTitle)
                this.Controls.Add(this.TitleLabel);
        }

        public void ConfigureLocation(Point? searchPoint, Point? buttonPoint = null, Point? titlePoint = null)
        {
            this.TxBoxSearch.Location = searchPoint?? this.TxBoxSearch.Location;
            this.BtnAdd.Location = buttonPoint?? this.BtnAdd.Location;
            this.TitleLabel.Location = titlePoint?? this.TitleLabel.Location;

            Load();
        }

        public void ConfigureSize(Size? searchSize, Size? buttonSize = null, Size? titleSize = null)
        {
            this.TxBoxSearch.Size = searchSize ?? this.TxBoxSearch.Size;
            this.BtnAdd.Size = buttonSize ?? this.BtnAdd.Size;
            this.TitleLabel.Size = titleSize ?? this.TitleLabel.Size;
            Load();
        }

        public void ConfigureAddButtonEvent(string eventName)
        {
            switch (eventName)
            {
                case "region":
                    this.BtnAdd.Click += this.MainForm.ShowRegionForm;
                    break;
            }
        }
    }
}

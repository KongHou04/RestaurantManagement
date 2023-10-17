using BUS.Handler;
using BUS.Models;
using BUS.Repository.Implements.Getters;
using BUS.Repository.Implements.Setters;
using BUS.Repository.Interfaces.Setters;
using DAO.Context;
using DAO.Repository.Implements;
using DAO.Repository.Interfaces;
using DTO;
using GUI.Components;
using GUI.Components.Actions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class Main : Form
    {
        ITableOrderGetter toGetter { get; set; }
        IRegionDAO regionDAO { get; set; }
        ITableDAO tableDAO { get; set; }
        IProductDAO productDAO { get; set; }
        ICategoryDAO categoryDAO { get; set; }
        IEmployeeDAO employeeDAO { get; set; }
        IAccountBUS accountBUS { get; set; }
        IBillDAO billDAO { get; set; }
        IRegionBUS regionBUS { get; set; }
        public Main()
        {
            InitializeComponent();
            ITableDAO tableDAO = new TableDAO(new RMDbContext());
            ITODetailsDAO toDetailsDAO = new TODetailsDAO(new RMDbContext());
            IOrderDAO orderDAO = new OrderDAO(new RMDbContext());
            toGetter = new TableOrderGetter(tableDAO, toDetailsDAO, orderDAO);
            regionDAO = new RegionDAO(new RMDbContext());
            this.tableDAO = new TableDAO(new RMDbContext());
            this.productDAO = new ProductDAO(new RMDbContext());
            this.categoryDAO = new CategoryDAO(new RMDbContext());
            this.employeeDAO = new EmployeeDAO(new RMDbContext());
            this.accountBUS = new AccountBUS(new AccountDAO(new RMDbContext()));
            this.billDAO = new BillDAO(new RMDbContext());
            this.regionBUS = new RegionBUS(new  RegionDAO(new RMDbContext()));
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            splitContainer.Panel2.Controls.Clear();
            List<TableOrder> tableOrders = await toGetter.GetTableOrders();
            TableOrderPanel toPanel = new TableOrderPanel(this, tableOrders, await regionDAO.GetAll(), 1000);
            splitContainer.Panel2.Controls.Add(toPanel);
        }

        public void ShowTableInfor(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                TableSquare tableSquare = (TableSquare)sender;
                MessageBox.Show(tableSquare.TableOrder.OrderID.ToString());
            }
        }

        public async void button2_Click(object? sender, EventArgs e)
        {
            Category? category = null;
            try
            {
                if (sender is CategorySquare)
                {
                    CategorySquare regionSquare = (CategorySquare)sender;
                    category = regionSquare.Category;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            splitContainer.Panel2.Controls.Clear();
            List<Category> categories = await categoryDAO.GetAll();
            List<Product> products = await productDAO.GetAll();
            ProductCategoryPanel productCategoryPanel = new ProductCategoryPanel(this, categories, products, new Size(950, 640), (category == null) ? categories[0] : category);
            splitContainer.Panel2.Controls.Add(productCategoryPanel);

        }

        public async void button3_Click(object? sender, EventArgs e)
        {
            DTO.Region? region = null;
            try
            {
                if (sender is RegionSquare)
                {
                    RegionSquare regionSquare = (RegionSquare)sender;
                    region = regionSquare.Region;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            splitContainer.Panel2.Controls.Clear();
            List<DTO.Region> regions = await regionDAO.GetAll();
            List<Table> tables = await tableDAO.GetAll();
            TableRegionPanel tableRegionPanel = new TableRegionPanel(this, regions, tables, new Size(950, 640), (region == null) ? regions[0] : region);
            splitContainer.Panel2.Controls.Add(tableRegionPanel);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            splitContainer.Panel2.Controls.Clear();
            List<Employee> employees = await employeeDAO.GetAll();
            EmployeeContainerPanel employeeContainerPanel = new EmployeeContainerPanel(this, employees, new Size(950, 640), new Point(15, 10));
            splitContainer.Panel2.Controls.Add(employeeContainerPanel);

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            splitContainer.Panel2.Controls.Clear();
            List<Bill> bills = await billDAO.GetAll();
            BillContainerPanel billContainerPanel = new BillContainerPanel(this, bills, new Size(950, 640), new Point(15, 10));
            splitContainer.Panel2.Controls.Add(billContainerPanel);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            splitContainer.Panel2.Controls.Clear();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //var a = await accountBUS.Login("superadmin", "0123456789", false);
            //if (a != null)
            //    MessageBox.Show("Login successfully");
            ActionRegionPanel actionRegionPanel = new ActionRegionPanel(this.regionBUS, new Size(950, 640), new Point(15, 10));
            this.splitContainer.Panel2.Controls.Add(actionRegionPanel);
        }
        public void ShowRegionForm(object? sender, EventArgs e)
        {
            this.splitContainer.Panel2.Controls.Clear();
            DTO.Region? region = null;
            try
            {
                if (sender is ControlsPanel)
                    region = null;
            }
            catch
            {

            }
            ActionRegionPanel actionRegionPanel = new ActionRegionPanel(this.regionBUS, new Size(950, 640), new Point(15, 10), true, region);
            this.splitContainer.Panel2.Controls.Add(actionRegionPanel);
        }

    }
}

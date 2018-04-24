using MoneyFarm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyFarm
{
    public partial class EditForm : Form
    {
        public EditForm(IOrderedQueryable<Category> categories, DataGridViewRow log)
        {
            InitializeComponent();
            
            CategorylistBox.Text = log.Cells[1].Value.ToString();
        }
    }
}

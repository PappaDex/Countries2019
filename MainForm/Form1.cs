using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Countries;
namespace MainForm
{
    public partial class WorldCountries : Form
    {
        private CountryRepository _countryRepository = new CountryRepository();
        private BindingSource _tableBindingSource = new BindingSource();
        public WorldCountries()
        {
            InitializeComponent();
            _tableBindingSource.DataSource = _countryRepository.GetCountriesList();
    }
        private void WorldCountries_Load(object sender, EventArgs e)
        {
            dataGridViewCountries.DataSource = _tableBindingSource;
        }
        private void dataGridViewCountries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

      
    }
}

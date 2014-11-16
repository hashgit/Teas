using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Autofac;
using TeaStall.ApplicationBuilder;
using TeaStall.Services.Models;

namespace Admin
{
    public partial class Main : Form
    {
        private readonly ITeaStallServiceManager _serviceManager;
        private IDictionary<string, CustomerDto> _customers;
        private readonly CustomerViewModel _viewModel;

        public Main()
        {
            InitializeComponent();
            ContainerManager.BuildContainer();

            _serviceManager = ContainerManager.Current.Resolve<ITeaStallServiceManager>();
            _viewModel = new CustomerViewModel();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listview = sender as ListView;
            if (listview.SelectedItems.Count > 0)
            {
                var customer = _customers[listView1.SelectedItems[0].Name];
                _viewModel.Id = customer.Id;

                // should be an event on viewModel to update UI but this will do for now
                _viewModel.FirstName = textBox1.Text = customer.FirstName;
                _viewModel.LastName = textBox2.Text = customer.LastName;
                _viewModel.DoB = dateTimePicker1.Value = customer.DoB;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            try
            {
                button.Enabled = false;
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private void LoadCustomers()
        {
            var customers = _serviceManager.GetCustomers();
            _customers = new Dictionary<string, CustomerDto>();
            listView1.Items.Clear();
            customers.ForEach(c =>
            {
                _customers.Add(c.Id, c);
                listView1.Items.Add(c.Id, c.FirstName, null);
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            try
            {
                button.Enabled = false;
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                    throw new Exception("First Name is required");

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                    throw new Exception("Last Name is required");

                var customer = new CustomerDto()
                {
                    FirstName = _viewModel.FirstName,
                    LastName = _viewModel.LastName,
                    DoB = _viewModel.DoB,
                    Id = _viewModel.Id
                };

                if (_serviceManager.SaveCustomer(customer))
                    LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _viewModel.Reset();
            textBox1.Text = textBox2.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _viewModel.FirstName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _viewModel.LastName = textBox2.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _viewModel.DoB = dateTimePicker1.Value;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                var item = listBox2.Items[listBox2.SelectedIndex] as ContentViewModel;
                textBox4.Text = item.Price.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                (sender as Button).Enabled = false;
                LoadBases();
                LoadFlavors();
                LoadToppings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                (sender as Button).Enabled = true;                
            }
        }

        private IDictionary<string, ToppingDto> _toppings;
        private void LoadToppings()
        {
            var toppings = _serviceManager.GetToppings();
            _toppings = new Dictionary<string, ToppingDto>();
            listBox3.Items.Clear();
            toppings.ForEach(b =>
            {
                _toppings.Add(b.Id, b);
                listBox3.Items.Add(new ContentViewModel() { Id = b.Id, Name = b.Topping, Price = b.Price });
            });
        }

        private IDictionary<string, FlavorDto> _flavors;
        private void LoadFlavors()
        {
            var flavors = _serviceManager.GetFlavors();
            _flavors = new Dictionary<string, FlavorDto>();
            listBox2.Items.Clear();
            flavors.ForEach(b =>
            {
                _flavors.Add(b.Id, b);
                listBox2.Items.Add(new ContentViewModel() { Id = b.Id, Name = b.Flavor, Price = b.Price });
            });
        }


        private IDictionary<string, TeaBaseDto> _bases;
        private void LoadBases()
        {
            var bases = _serviceManager.GetTeaBases();
            _bases = new Dictionary<string, TeaBaseDto>();
            listBox1.Items.Clear();
            bases.ForEach(b =>
            {
                _bases.Add(b.Id, b);
                listBox1.Items.Add(new ContentViewModel() { Id = b.Id, Name = b.Base, Price = b.Price });
            });
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var item = listBox1.Items[listBox1.SelectedIndex] as ContentViewModel;
                textBox3.Text = item.Price.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0)
            {
                var item = listBox3.Items[listBox3.SelectedIndex] as ContentViewModel;
                textBox5.Text = item.Price.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetPrice(sender as Button, listBox1, textBox3, "base");
        }

        private void SetPrice(Button sender, ListBox listBox, TextBox textBox, string type)
        {
            try
            {
                sender.Enabled = false;
                if (listBox.SelectedIndex >= 0)
                {
                    var item = listBox.Items[listBox.SelectedIndex] as ContentViewModel;
                    if (_serviceManager.SetBasePrice(item.Id, double.Parse(textBox.Text), type))
                        LoadBases();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sender.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetPrice(sender as Button, listBox2, textBox4, "flavor");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetPrice(sender as Button, listBox3, textBox5, "topping");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox6.Text))
                if (_serviceManager.AddBase(textBox6.Text))
                {
                    LoadBases();
                    textBox6.Text = string.Empty;
                }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox7.Text))
                if (_serviceManager.AddFlavor(textBox7.Text))
                {
                    LoadFlavors();
                    textBox7.Text = string.Empty;
                }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox8.Text))
                if (_serviceManager.AddTopping(textBox8.Text))
                {
                    LoadToppings();
                    textBox8.Text = string.Empty;
                }
        }
    }
}

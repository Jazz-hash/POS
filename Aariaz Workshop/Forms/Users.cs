using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aariaz_Workshop
{
    public partial class Users : Form
    {
        aaraiz_dbEntities data = new aaraiz_dbEntities();
        int id;
        AlertMessages alert;


        public Users()
        {
            InitializeComponent();
            DataLoad();
            ComboBoxData();
        }

        private void ComboBoxData()
        {
            var company = from item in data.tradingcompanies
                          where item.Status == true
                          select new
                          {
                              Id = item.Id,
                              Company = item.Company
                          };
            var site = from item in data.operatingsites
                       where item.Status == true
                       select new
                       {
                           Id = item.Id,
                           Site = item.Site
                       };
            comboBox4.DataSource = company.ToList();
            comboBox4.ValueMember = "Id";
            comboBox4.DisplayMember = "Company";
            comboBox3.DataSource = site.ToList();
            comboBox3.ValueMember = "Id";
            comboBox3.DisplayMember = "Site";
            comboBox2.DataSource = company.ToList();
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "Company";
            comboBox1.DataSource = site.ToList();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Site";

        }



        private void Add_new_user_btn_Click(object sender, EventArgs e)
        {
            users_mini_screen.SelectedTab = add_new_user_tab;
        }

        private void Update_user_btn_Click(object sender, EventArgs e)
        {
            if (!((int)metroGrid1.CurrentRow.Cells[0].Value <= 0))
            {
                id = (int)metroGrid1.CurrentRow.Cells[0].Value;
                user userdata = data.users.Find(id);
                metroTextBox9.Text = userdata.Name;
                metroTextBox10.Text = userdata.Username;
                metroTextBox7.Text = userdata.Email;
                metroTextBox8.Text = userdata.Password;
                metroTextBox11.Text = userdata.Password;
                comboBox3.SelectedItem = userdata.OperatingSite_id;
                comboBox4.SelectedItem = userdata.TradingCompany_id;
                pictureBox2.Image = byteArrayToImage(userdata.Image);
                users_mini_screen.SelectedTab = update_user_tab;
            }

        }

        private void Back_to_users_home_btn_Click(object sender, EventArgs e)
        {
            users_mini_screen.SelectedTab = main_users_tab;
        }



        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
           
           
        }

        Regex reg = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

        private void Add_new_user_db_btn_Click(object sender, EventArgs e)
        {
            string password;
           
           
            var usernames = from item in data.users
                            select new
                            {
                                username = item.Username
                            };
            var emails = from item in data.users
                         select new
                         {
                             email = item.Email
                         };
            foreach (var item in usernames)
            {
                if (metroTextBox2.Text == item.username)
                {
                    label19.Visible = true;
                }
                else
                {
                    label19.Visible = false;

                }

            }
            foreach (var item in emails)
            {
                if (metroTextBox3.Text == item.email)
                {
                    label20.Visible = true;
                }
                else
                {
                    label20.Visible = false;

                }

            }
            if (label19.Visible == true || label20.Visible == true)
            {
                //alert = new AlertMessages("User of enter your email !!", AlertMessages.alertType.error);
                //alert.BringToFront();
                //alert.Show();
            }
            else if (user_image_box.Image == null)
            {
                alert = new AlertMessages("Please insert a user picture !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if (metroTextBox1.Text == "")
            {
                alert = new AlertMessages("Please enter a valid name !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if (!reg.IsMatch(metroTextBox3.Text))
            {
                alert = new AlertMessages("Please enter a valid email !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if (metroTextBox2.Text == "")
            {
                // username
                alert = new AlertMessages("Please enter a valid username !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if (metroTextBox3.Text == "")
            {
                alert = new AlertMessages("Please enter a valid email !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if (metroTextBox5.Text == "")
            {
                alert = new AlertMessages("Please enter a valid Password !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if (metroTextBox4.Text != metroTextBox5.Text)
            {
                alert = new AlertMessages("Passwords not matched !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else
            {
                
                if (user_image_box.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    user_image_box.Image.Save(ms, user_image_box.Image.RawFormat);
                    byte[] image = ms.ToArray();
                    password = metroTextBox4.Text;
                    user userData = new user()
                    {
                        Name = metroTextBox1.Text,
                        Username = metroTextBox2.Text,
                        Email = metroTextBox3.Text,
                        Password = password,
                        OperatingSite_id = Convert.ToInt32(comboBox1.SelectedValue),
                        TradingCompany_id = Convert.ToInt32(comboBox2.SelectedValue),
                        Role = "user",
                        Status = true,
                        Image = image,

                    };
                    data.users.Add(userData);
                    data.SaveChanges();
                    DataLoad();
                    alert = new AlertMessages("User registered !!", AlertMessages.alertType.success);
                    alert.BringToFront();
                    alert.Show();
                    users_mini_screen.SelectedTab = main_users_tab;


                }

            }

        }

        private void Refresh_users_list_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void BunifuImageButton3_Click(object sender, EventArgs e)
        {
            if(metroTextBox9.Text == "")
            {
                alert = new AlertMessages("Please enter a valid name !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if (!reg.IsMatch(metroTextBox7.Text))
            {
                alert = new AlertMessages("Please enter a valid email !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if(metroTextBox10.Text == "")
            {
                alert = new AlertMessages("Please enter a valid username !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if (metroTextBox7.Text == "")
            {
                alert = new AlertMessages("Please enter a valid email !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if (metroTextBox8.Text == "")
            {
                alert = new AlertMessages("Please enter a valid Password !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if (pictureBox2.Image == null)
            {
                alert = new AlertMessages("Please insert a user picture !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else if (metroTextBox8.Text != metroTextBox11.Text)
            {
                alert = new AlertMessages("Passwords not matched !!", AlertMessages.alertType.error);
                alert.BringToFront();
                alert.Show();
            }
            else
            {
                user userdata = data.users.Find(id);
                userdata.Name = metroTextBox9.Text;
                userdata.Username = metroTextBox10.Text;
                userdata.Email = metroTextBox7.Text;
                userdata.Password = metroTextBox8.Text;
                data.SaveChanges();
                DataLoad();
                users_mini_screen.SelectedTab = main_users_tab;
            }
            

        }

        private void Delete_users_btn_Click(object sender, EventArgs e)
        {
            if (!((int)metroGrid1.CurrentRow.Cells[0].Value <= 0))
            {
                id = (int)metroGrid1.CurrentRow.Cells[0].Value;
                user userdata = data.users.Find(id);
                userdata.Status = false;
                data.SaveChanges();
                DataLoad();

            }
        }



        private void DataLoad()
        {

            var userData = from item in data.users
                           where item.Status == true
                           select new
                           {
                               Id = item.Id,
                               Name = item.Name,
                               Username = item.Username,
                               Email = item.Email,
                               Password = "*********",
                               Role = item.Role,
                           };

            if (userData != null)
            {
                metroGrid1.DataSource = userData.ToList();

            }
        }
        private void DataLoad_with_password()
        {

            var userData = from item in data.users
                           where item.Status == true
                           select new
                           {
                               Id = item.Id,
                               Name = item.Name,
                               Username = item.Username,
                               Email = item.Email,
                               Password = item.Name,
                               Role = item.Role,
                           };

            if (userData != null)
            {
                metroGrid1.DataSource = userData.ToList();

            }
        }


        private void search_without_password()
        {
            var userData = from item in data.users
                           where item.Role == bunifuMaterialTextbox1.Text || item.Name == bunifuMaterialTextbox1.Text
                           select new
                           {
                               Id = item.Id,
                               Name = item.Name,
                               Username = item.Username,
                               Email = item.Email,
                               Password = "*********",
                               Role = item.Role,
                           };
            if (userData != null)
            {
                metroGrid1.DataSource = userData.ToList();

            }
        }
        private void search_with_password()
        {
            var userData = from item in data.users
                           where item.Role == bunifuMaterialTextbox1.Text || item.Name == bunifuMaterialTextbox1.Text
                           select new
                           {
                               Id = item.Id,
                               Name = item.Name,
                               Username = item.Username,
                               Email = item.Email,
                               Password = item.Password,
                               Role = item.Role,
                           };
            if (userData != null)
            {
                metroGrid1.DataSource = userData.ToList();

            }
        }
        private void BunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text != "")
            {
                if (materialCheckBox1.Checked == true)
                {
                    search_with_password();

                }
                else
                {
                    search_without_password();

                }

            }
            else
            {
                if (materialCheckBox1.Checked == true)
                {
                    DataLoad();

                }
                else
                {
                    DataLoad_with_password();
                }
            }
        }

        private void MaterialCheckBox1_CheckStateChanged(object sender, EventArgs e)
        {

            if (materialCheckBox1.Checked != true)
            {
                bunifuMaterialTextbox1.Text = "";
                DataLoad();
            }

        }

        private void MaterialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MaterialCheckBox1_Click(object sender, EventArgs e)
        {
            if (materialCheckBox1.Checked != false)
            {
                Admin_authentication authentication = new Admin_authentication();
                authentication.ShowDialog();
                if (Admin_authentication.allow_user == true)
                {
                    materialCheckBox1.Checked = true;
                    DataLoad_with_password();

                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "You must be an admin to complete this action !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    materialCheckBox1.Checked = false;
                    DataLoad();

                }
            }

        }
        OpenFileDialog fileDialog = new OpenFileDialog();

        private void Browse_user_image_btn_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                user_image_box.Image = Image.FromFile(fileDialog.FileName);
            }
        }
    }
}

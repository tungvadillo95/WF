using C1.Win.C1Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyC1
{
    public partial class Form3 : Form
    {
        string path = "User ID=sa;Password=123456;Server=.\\SQLEXPRESS;Database=21-wpc;Integrated Security=true;Pooling=true;";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int breed_id;
        public Form3()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            this.KeyDown += new KeyEventHandler(Function_KeyDown);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void breed_identifi_no_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(breed_identifi_no.Text))
            {
                con.Open();
                cmd = new SqlCommand($"select * from breed_cow where breed_identifi_no = '{breed_identifi_no.Text}'", con);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        breed_id = (int)reader["breed_id"];
                        breed_identifi_no.Text = reader["breed_identifi_no"].ToString();
                        breed_name.Text = reader["breed_name"].ToString();
                        switch (reader["breed_class"].ToString())
                        {
                            case "1":
                                breed_class_1.Checked = true;
                                break;

                            case "2":
                                breed_class_2.Checked = true;
                                break;
                        }
                        if (reader["breed_birthday"].ToString() != string.Empty)
                        {
                            breed_birthday.Value = (DateTime)reader["breed_birthday"];
                        }
                        else
                        {
                            breed_birthday.Value = null;
                        }
                        if (reader["breed_nm"].ToString() != string.Empty)
                        {
                            breed_nm.Value = (int)reader["breed_nm"];
                        }
                        if (reader["breed_milk"].ToString() != string.Empty)
                        {
                            breed_milk.Value = (int)reader["breed_milk"];
                        }
                        if (reader["breed_somatic_cell_cnt"].ToString() != string.Empty)
                        {
                            breed_somatic_cell_cnt.Value = (decimal)reader["breed_somatic_cell_cnt"];
                        }
                        if (reader["breed_production_life"].ToString() != string.Empty)
                        {
                            breed_production_life.Value = (decimal)reader["breed_production_life"];
                        }
                        if (reader["breed_conception_index"].ToString() != string.Empty)
                        {
                            breed_conception_index.Value = (decimal)reader["breed_conception_index"];
                        }
                        if (reader["breed_body_shape"].ToString() != string.Empty)
                        {
                            breed_body_shape.Value = (decimal)reader["breed_body_shape"];
                        }
                        if (reader["breed_tpi"].ToString() != string.Empty)
                        {
                            breed_tpi.Value = (int)reader["breed_tpi"];
                        }
                        breed_beta_casein.Text = reader["breed_beta_casein"].ToString();
                        breed_note.Text = reader["breed_note"].ToString();
                    }
                }
                breed_identifi_no.BorderColor = SystemColors.WindowFrame; ;
                breed_identifi_no.ForeColor = SystemColors.WindowText;
                con.Close();
            }
        }

        private void breed_class_2_CheckedChanged(object sender, EventArgs e)
        {
            reset_panel_breed_class1();
            panel_breed_class1.Enabled = false;
        }

        private void breed_class_1_CheckedChanged(object sender, EventArgs e)
        {
            panel_breed_class1.Enabled = true;
            reset_panel_breed_class1();
        }
        private void reset_panel_breed_class1()
        {
            breed_nm.Value = null;
            breed_milk.Value = null;
            breed_somatic_cell_cnt.Value = null;
            breed_production_life.Value = null;
            breed_conception_index.Value = null;
            breed_body_shape.Value = null;
            breed_tpi.Value = null;
            breed_beta_casein.Text = null;
        }
        void Function_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "F2":
                    ResetData();
                    break;
                case "F4":
                    OpenDialog();
                    break;
                case "F5":
                    DeleteBreed();
                    break;
                case "F9":
                    if (this.breed_id > 0)
                        UpdateBreed();
                    else
                        CreateBreed();
                    break;
                case "F12":
                    Close();
                    break;
            }
        }
        void ResetData()
        {
            this.breed_id = 0;
            breed_identifi_no.Text = null;
            breed_name.Text = null;
            breed_birthday.Value = null;
            breed_note.Text = null;
            reset_panel_breed_class1();
        }
        void CreateBreed()
        {
            if (!CheckValidate())
            {
                MessageBox.Show("Form not valid !");
                return;
            }
            con.Open();
            var query = "INSERT INTO breed_cow" +
            "(breed_identifi_no, breed_name, breed_birthday, breed_class, breed_nm, breed_milk, breed_somatic_cell_cnt,breed_production_life," +
            "breed_conception_index, breed_body_shape, breed_tpi,breed_beta_casein, breed_note, breed_regi_date, breed_up_date)" +
            $"VALUES ('{breed_identifi_no.Text}'" +
                    $",'{breed_name.Text}'" +
                    $",{(breed_birthday.ValueIsDbNull ? "null" : $"'{breed_birthday.Value.ToString()}'")}" +
                    $",'{(breed_class_1.Checked ? "1" : "2")}' " +
                    $",{(breed_nm.ValueIsDbNull ? "null" : breed_nm.Text)}" +
                    $",{(breed_milk.ValueIsDbNull ? "null" : breed_milk.Text)}" +
                    $",{(breed_somatic_cell_cnt.ValueIsDbNull ? "null" : breed_somatic_cell_cnt.Text)}" +
                    $",{(breed_production_life.ValueIsDbNull ? "null" : breed_production_life.Text)}" +
                    $",{(breed_conception_index.ValueIsDbNull ? "null" : breed_conception_index.Text)}" +
                    $",{(breed_body_shape.ValueIsDbNull ? "null" : breed_body_shape.Text)}" +
                    $",{(breed_tpi.ValueIsDbNull ? "null" : breed_tpi.Text)}" +
                    $",'{(breed_beta_casein.ValueIsDbNull ? "null" : breed_beta_casein.Text)}'" +
                    $",'{breed_note.Text}'" +
                    $",'{DateTime.UtcNow.Date}'" +
                    $",'{DateTime.UtcNow.Date}');";
            cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() == 1)
            {
                cmd = new SqlCommand($"select * from breed_cow where breed_identifi_no = '{breed_identifi_no.Text}'", con);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.breed_id = (int)reader["breed_id"];
                    }
                }
                MessageBox.Show("Create success");
            }
            con.Close();
        }
        void UpdateBreed()
        {
            if (!CheckValidate())
            {
                MessageBox.Show("Form not valid !");
                return;
            }
            con.Open();
            var query = "UPDATE breed_cow " +
            $"SET breed_name = '{breed_name.Text}'" +
                    $",breed_birthday= {(breed_birthday.ValueIsDbNull ? "null" : $"'{breed_birthday.Value.ToString()}'")}" +
                    $",breed_class = '{(breed_class_1.Checked ? "1" : "2")}' " +
                    $",breed_nm = {(breed_nm.ValueIsDbNull ? "null" : breed_nm.Text)}" +
                    $",breed_milk = {(breed_milk.ValueIsDbNull ? "null" : breed_milk.Text)}" +
                    $",breed_somatic_cell_cnt = {(breed_somatic_cell_cnt.ValueIsDbNull ? "null" : breed_somatic_cell_cnt.Text)}" +
                    $",breed_production_life = {(breed_production_life.ValueIsDbNull ? "null" : breed_production_life.Text)}" +
                    $",breed_conception_index = {(breed_conception_index.ValueIsDbNull ? "null" : breed_conception_index.Text)}" +
                    $",breed_body_shape = {(breed_body_shape.ValueIsDbNull ? "null" : breed_body_shape.Text)}" +
                    $",breed_tpi = {(breed_tpi.ValueIsDbNull ? "null" : breed_tpi.Text)}" +
                    $",breed_beta_casein = '{(breed_beta_casein.ValueIsDbNull ? "null" : breed_beta_casein.Text)}'" +
                    $",breed_note = '{breed_note.Text}'" +
                    $",breed_up_date = '{DateTime.UtcNow.Date}'" +
                    $"WHERE breed_id = {this.breed_id}";
            cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Update success");
            }
            con.Close();
        }
        void DeleteBreed()
        {
            if(this.breed_id > 0)
            {
                con.Open();
                var query = $"DELETE FROM breed_cow WHERE breed_id = {this.breed_id} ;";
                cmd = new SqlCommand(query, con);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Delete success");
                }
                con.Close();
                ResetData();
            }
            else
            {
                MessageBox.Show("Breed not found");
            }
        }
        private void reset_data_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void create_breed_Click(object sender, EventArgs e)
        {
            if (this.breed_id > 0)
                UpdateBreed();
            else
                CreateBreed();
        }
        private bool CheckValidate()
        {
            if (!CheckFiedRequired()
                || !breed_nm_IsValid()
                || !breed_nm_IsValid()
                || !breed_tpi_IsValid()
                || !breed_milk_IsValid()
                || !breed_somatic_cell_cnt_IsValid()
                || !breed_conception_index_IsValid()
                || !breed_body_shape_IsValid()
                || !breed_beta_casein_IsValid()
                || !breed_note_IsValid())
                return false;
            return true;
        }

        private bool CheckFiedRequired()
        {
            bool check = true;
            if (string.IsNullOrEmpty(breed_identifi_no.Text)) 
            {
                breed_identifi_no.BorderColor = Color.Red;
                breed_identifi_no.ForeColor = Color.Red;
                check = false;
            }
            if (string.IsNullOrEmpty(breed_name.Text))
            {
                breed_name.BorderColor = Color.Red;
                breed_name.ForeColor = Color.Red;
                check = false;
            }
            return check;
        }

        private bool ValidateInt(string value, int integer_part)
        {
            if (value.Length > integer_part)
                return false;
            return true;
        }
        private bool ValidateDecimal(string value,int integer_part, int decimal_part)
        {
            if (integer_part < 1) return false;
            var regex = @"^-?(0|[1-9]\d{0," + (integer_part - 1) + @"})([,\.]\d{1,"+ decimal_part + @"})?$";
            if(Regex.IsMatch(value, regex))
            {
                return true;
            }
            return false;
        }

        private void breed_nm_TextChanged(object sender, EventArgs e)
        {
            if(!breed_nm_IsValid())
            {
                //MessageBox.Show("ＮＭ＄ not valid !");
                breed_nm.BorderColor = Color.Red;
                breed_nm.ForeColor = Color.Red;
            }
            else
            {
                breed_nm.BorderColor = SystemColors.WindowFrame; ;
                breed_nm.ForeColor = SystemColors.WindowText;
            }
        }
        private bool breed_nm_IsValid()
        {
            if (!string.IsNullOrEmpty(breed_nm.Text) && !ValidateInt(breed_nm.Text, 4))
                return false;
            return true;
        }

        private void breed_milk_TextChanged(object sender, EventArgs e)
        {
            if (!breed_milk_IsValid())
            {
                //MessageBox.Show("Ｍｉｌｋ not valid !");
                breed_milk.BorderColor = Color.Red;
                breed_milk.ForeColor = Color.Red;
            }
            else
            {
                breed_milk.BorderColor = SystemColors.WindowFrame; ;
                breed_milk.ForeColor = SystemColors.WindowText;
            }
        }
        private bool breed_milk_IsValid()
        {
            if (!string.IsNullOrEmpty(breed_milk.Text) && !ValidateInt(breed_milk.Text, 4))
                return false;
            return true;
        }

        private void breed_tpi_TextChanged(object sender, EventArgs e)
        {
            if (!breed_tpi_IsValid())
            {
                //MessageBox.Show("ＴＰＩ not valid !");
                breed_tpi.BorderColor = Color.Red;
                breed_tpi.ForeColor = Color.Red;
            }
            else
            {
                breed_tpi.BorderColor = SystemColors.WindowFrame; ;
                breed_tpi.ForeColor = SystemColors.WindowText;
            }
        }

        private bool breed_tpi_IsValid()
        {
            if (!string.IsNullOrEmpty(breed_tpi.Text) && !ValidateInt(breed_tpi.Text, 4))
                return false;
            return true;
        }

        private void breed_beta_casein_TextChanged(object sender, EventArgs e)
        {
            if (!breed_beta_casein_IsValid())
            {
                //MessageBox.Show("βカゼイン not valid !");
                breed_beta_casein.BorderColor = Color.Red;
                breed_beta_casein.ForeColor = Color.Red;
            }
            else
            {
                breed_beta_casein.BorderColor = SystemColors.WindowFrame; ;
                breed_beta_casein.ForeColor = SystemColors.WindowText;
            }
        }

        private bool breed_beta_casein_IsValid()
        {
            if (!string.IsNullOrEmpty(breed_beta_casein.Text) && breed_beta_casein.Text.Length > 4)
                return false;
            return true;
        }

        private void breed_somatic_cell_cnt_TextChanged(object sender, EventArgs e)
        {
            if (!breed_somatic_cell_cnt_IsValid())
            {
                //MessageBox.Show("体細胞数 not valid !");
                breed_somatic_cell_cnt.BorderColor = Color.Red;
                breed_somatic_cell_cnt.ForeColor = Color.Red;
            }
            else
            {
                breed_somatic_cell_cnt.BorderColor = SystemColors.WindowFrame; ;
                breed_somatic_cell_cnt.ForeColor = SystemColors.WindowText;
            }
        }
        private bool breed_somatic_cell_cnt_IsValid()
        {
            if (!string.IsNullOrEmpty(breed_somatic_cell_cnt.Text) && !ValidateDecimal(breed_somatic_cell_cnt.Text, 3, 1))
                return false;
            return true;
        }

        private void breed_production_life_TextChanged(object sender, EventArgs e)
        {
            if (!breed_production_life_IsValid())
            {
                //MessageBox.Show("生産寿命 not valid !");
                breed_production_life.BorderColor = Color.Red;
                breed_production_life.ForeColor = Color.Red;
            }
            else
            {
                breed_production_life.BorderColor = SystemColors.WindowFrame; ;
                breed_production_life.ForeColor = SystemColors.WindowText;
            }
        }
        private bool breed_production_life_IsValid()
        {
            if (!string.IsNullOrEmpty(breed_production_life.Text) && !ValidateDecimal(breed_production_life.Text, 3, 1))
                return false;
            return true;
        }

        private void breed_conception_index_TextChanged(object sender, EventArgs e)
        {
            if (!breed_conception_index_IsValid())
            {
                //MessageBox.Show("受胎指数 not valid !");
                breed_conception_index.BorderColor = Color.Red;
                breed_conception_index.ForeColor = Color.Red;
            }
            else
            {
                breed_conception_index.BorderColor = SystemColors.WindowFrame; ;
                breed_conception_index.ForeColor = SystemColors.WindowText;
            }
        }
        private bool breed_conception_index_IsValid()
        {
            if (!string.IsNullOrEmpty(breed_conception_index.Text) && !ValidateDecimal(breed_conception_index.Text, 4, 2))
                return false;
            return true;
        }

        private void breed_body_shape_TextChanged(object sender, EventArgs e)
        {
            if (!breed_body_shape_IsValid())
            {
                //MessageBox.Show("体型 not valid !");
                breed_body_shape.BorderColor = Color.Red;
                breed_body_shape.ForeColor = Color.Red;
            }
            else
            {
                breed_body_shape.BorderColor = SystemColors.WindowFrame; ;
                breed_body_shape.ForeColor = SystemColors.WindowText;
            }
        }
        private bool breed_body_shape_IsValid()
        {
            if (!string.IsNullOrEmpty(breed_body_shape.Text) && !ValidateDecimal(breed_body_shape.Text, 4, 2))
                return false;
            return true;
        }

        private void breed_note_TextChanged(object sender, EventArgs e)
        {
            if (!breed_note_IsValid())
            {
                //MessageBox.Show("メモ not valid !");
                breed_note.ForeColor = Color.Red;
            }
            else
            {
                breed_note.ForeColor = SystemColors.WindowText;
            }
        }
        private bool breed_note_IsValid()
        {
            if (!string.IsNullOrEmpty(breed_beta_casein.Text) && breed_beta_casein.Text.Length > 200)
                return false;
            return true;
        }

        private void breed_name_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(breed_name.Text))
            {
                breed_identifi_no.BorderColor = SystemColors.WindowFrame; ;
                breed_identifi_no.ForeColor = SystemColors.WindowText;
            }
        }

        private void c1Button13_Click(object sender, EventArgs e)
        {
            DeleteBreed();
        }

        private void c1Button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            OpenDialog();
        }

        private void c1Button4_Click(object sender, EventArgs e)
        {

        }
        private void OpenDialog()
        {
            var form4 = new Form4();
            form4.ShowDialog();
        }
    }
}

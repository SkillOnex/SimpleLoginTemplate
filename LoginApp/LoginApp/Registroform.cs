using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Registroform : Form
    {
        public Registroform()
        {
            InitializeComponent();
        }

        //Conecta com o banco de dados e grava User/senha
        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= C:\Users\SkillOnex\Documents\Visual Studio 2019\Templates\ProjectTemplates\Visual C#\LoginApp\LoginApp\LoginApp\Database1.mdf;Integrated Security=True;Connect Timeout=30");
                {
                    string register = "INSERT INTO Login VALUES('" + RUsertext.Text.Trim() + "','" + RPasstext.Text.Trim() + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(register, conn);
                    DataTable dta = new DataTable();
                    sda.Fill(dta);
                    if (dta.Rows.Count == 1)
                    {
                        MessageBox.Show("Usuario ou senha invalidos!");
                    }
                    else
                    {
                        Loginform loginform = new Loginform();
                        this.Hide();
                        loginform.Show();
                        MessageBox.Show("Conta criada!");
                    }
                }
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RUsertext_TextChanged(object sender, EventArgs e)
        {

        }

        
        private bool isvalid()
        {
            if (RUsertext.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Por favor preencha o campos de usuario!");
                return false;
            }
            else if (RPasstext.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Por favor preencha o campos de senha!");
                return false;
            }
            return true;
        }
     }
}

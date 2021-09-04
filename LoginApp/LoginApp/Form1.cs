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
    public partial class Loginform : Form
    {
        
        public Loginform()
        {
            InitializeComponent();
        }
        //Abrir um novo form quando clicar no criar uma conta
        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registroform registroform = new Registroform();
            
            registroform.Show();
        }
        
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // Validar as credenciais de Usuario/senha e efetuar o login
        // Paremetro de SqlConnection(@"Coloque seu banco de dados"
        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                
                {
                    SqlConnection conn = new SqlConnection(@"");
                    string query = "SELECT * FROM Login WHERE Usuario = '" + Usertext.Text.Trim() + "' AND Password = '" + Passtext.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dta = new DataTable();
                    sda.Fill(dta);
                    if (dta.Rows.Count == 1)
                    {
                        MessageBox.Show("Login feito com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Usuario ou senha invalidos!");
                    }
                }
            }
        }

        //verificar se os campos de usuario e senha estao vazios/no banco de dados
        private bool isvalid()
        {
            if (Usertext.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Usuario não encontrado!");
                return false;
            }else if (Passtext.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Senha não encontrada!");
                    return false;
            }
            return true;
        }

        private void Usertext_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

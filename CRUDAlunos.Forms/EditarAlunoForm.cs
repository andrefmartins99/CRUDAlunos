using System;
using System.Windows.Forms;
using Biblioteca;

namespace CRUDAlunos.Forms
{
    public partial class EditarAlunoForm : Form
    {
        Aluno editado;

        Form1 form;

        public EditarAlunoForm(Form1 form, Aluno editado)
        {
            InitializeComponent();
            this.editado = editado;
            this.form = form;

            txtId.Text = editado.ID.ToString();
            txtPrimeiroNome.Text = editado.Nome;
            txtApelido.Text = editado.Apelido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaForm())
            {
                editado.Nome = txtPrimeiroNome.Text;
                editado.Apelido = txtApelido.Text;

                form.InitLista();
                this.Close();
            }
        }

        private bool ValidaForm()
        {
            bool output = true;

            if (string.IsNullOrEmpty(txtPrimeiroNome.Text))
            {
                MessageBox.Show("Insira o seu primeiro nome", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                output = false;
            }

            if (string.IsNullOrEmpty(txtApelido.Text))
            {
                MessageBox.Show("Insira o seu apelido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                output = false;
            }

            return output;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O aluno não vai ser editado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Close();
        }
    }
}

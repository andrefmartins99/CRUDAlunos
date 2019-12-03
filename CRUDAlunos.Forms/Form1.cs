using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRUDAlunos.Forms
{
    public partial class Form1 : Form
    {
        List<Aluno> Alunos;

        int contaAlunos = 1;

        public Form1()
        {
            Alunos = new List<Aluno>();
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Aluno novoAluno;

            if (ValidaForm())
            {
                /*novoAluno = new Aluno();

                novoAluno.ID = contaAlunos;
                novoAluno.Nome = txtPrimeiroNome.Text;
                novoAluno.Apelido = txtApelido.Text;*/

                novoAluno = new Aluno
                {
                    ID = contaAlunos,
                    Nome = txtPrimeiroNome.Text,
                    Apelido = txtApelido.Text,
                };

                Alunos.Add(novoAluno);
                contaAlunos++;

                InitLista();
            }
            else
            {
                MessageBox.Show("Preencha corretamente os dados e tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtPrimeiroNome.Text = string.Empty;
            txtApelido.Text = string.Empty;
        }

        public void InitLista()
        {
            listBoxAlunos.DataSource = null;
            listBoxAlunos.DataSource = Alunos;
            listBoxAlunos.DisplayMember = "NomeCompleto";
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
            if (txtPrimeiroNome.Text != string.Empty && txtApelido.Text != string.Empty)
            {
                MessageBox.Show("O aluno não vai ser guardado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPrimeiroNome.Text = string.Empty;
                txtApelido.Text = string.Empty;
            }
        }

        private void btnApagarAluno_Click(object sender, EventArgs e)
        {
            Aluno alunoAApagar = (Aluno)listBoxAlunos.SelectedItem;

            Aluno apagado = null;

            if (alunoAApagar != null)
            {
                foreach (Aluno aluno in Alunos)
                {
                    if (alunoAApagar.ID == aluno.ID)
                    {
                        apagado = aluno;
                    }
                }

                if (apagado != null)
                {
                    DialogResult resposta;

                    resposta = MessageBox.Show($"Tem a certeza que pretende apagar o {apagado.NomeCompleto}", "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (DialogResult.OK == resposta)
                    {
                        Alunos.Remove(apagado);
                        InitLista();
                    }
                }
            }
        }

        private void btnEditarAluno_Click(object sender, EventArgs e)
        {
            Aluno alunoAEditar = (Aluno)listBoxAlunos.SelectedItem;

            Aluno editado = null;

            if (alunoAEditar != null)
            {
                foreach (Aluno aluno in Alunos)
                {
                    if (alunoAEditar.ID == aluno.ID)
                    {
                        editado = aluno;
                    }
                }

                if (editado != null)
                {
                    //abrir a nova form para editar
                    EditarAlunoForm editarAlunoForm = new EditarAlunoForm(this, editado);
                    editarAlunoForm.Show();
                }
            }
        }
    }
}

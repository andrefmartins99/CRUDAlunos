namespace Biblioteca
{
    public class Aluno
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public string NomeCompleto
        {
            get
            {
                return $"{Nome} {Apelido}";
            }
        }

        //Polimorfismo
        public override string ToString()
        {
            return $"{ID} {Nome} {Apelido}";
        }
    }
}

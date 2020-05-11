namespace FIT.Projeto.Aula1.OO
{
    public interface IFala 
    {
        string Falar();
    }

    public abstract class Pessoa
    {
        public Pessoa(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    public class PessoaFisica : Pessoa, IFala
    {
        public PessoaFisica(string name, string cpf) : base(name)
        {
            Cpf = cpf;
        }
        public string Cpf { get; set; }
        public string Falar()
        {
            return "falando...";
        }
    }

    public class PessoaJuridica : Pessoa, IFala
    {
        public PessoaJuridica(string name, string cnpj) : base(name)
        {
            Cnpj = Cnpj;
        }
        public string Cnpj { get; set; }
        public string Falar()
        {
            return "Fazendo propaganda...";
        }
    }
}
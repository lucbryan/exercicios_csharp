using System.Linq;

namespace exercicio4
{

    public class Usuario
    {
        public string Email { get; }
        public string Nome { get; }
        public string Senha { get; }

        public Usuario(string email, string nome)
        {
            this.Email = email;
            this.Nome = nome;
            this.Senha = Guid.NewGuid().ToString();
        }
    }
    public class Program
    {
        public static List<Usuario> IdentificaDuplicados(List<Usuario>? array)
        {
            try
            {
                return array.GroupBy(f => f.Email)
                .Where(g => g.Count() > 1)
                .SelectMany(g => g)
                .ToList();            
            }
            catch { return null; }
        }

        public static void Imprime(List<Usuario>lista)
        {
            if(lista != null) { Console.WriteLine("{"+ string.Join(",", lista.Select(p=>p.Nome)) + "}");}
            else{ Console.WriteLine("ERRO");}
        }


        public static void Main(string[] args)
        {

            Imprime(IdentificaDuplicados(new List<Usuario> {
                new Usuario("jc@cmu.com.br", "João Carlos"),
                new Usuario("ana@cmu.com.br", "Ana Maria"),
                new Usuario("pedro@cmu.com.br", "Pedro Almeida"),
                new Usuario("joaozin@cmu.com.br", "João Marcelo")})); // new List<Usuario> {}

            Imprime(IdentificaDuplicados(new List<Usuario> {
                new Usuario("joaozin@cmu.com.br", "João Carlos"),
                new Usuario("ana@cmu.com.br", "Ana Maria"),
                new Usuario("pedro@cmu.com.br", "Pedro Almeida"),
                new Usuario("joaozin@cmu.com.br", "João Marcelo")})); // new List<Usuario> {Usuario{"João Carlos"}, Usuario{"João Marcelo"}}

            Imprime(IdentificaDuplicados(new List<Usuario> {})); // new List<Usuario> {}
                
            Imprime(IdentificaDuplicados(null)); // ERRO
        }
    }
}


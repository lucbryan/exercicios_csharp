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
        public static List<Usuario> OrdenaUsuarios(List<Usuario> array)
        {

            try
            {
                if (array.GroupBy(x => x.Nome).Any(g => g.Count() > 1))
                {
                    throw new InvalidOperationException("Usuários com nomes repetidos.");
                }
                    return array.OrderBy(a => a.Nome).ToList();
            }
            catch { return null;}
        }
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Imprime(OrdenaUsuarios(new List<Usuario> {
                new Usuario("jc@cmu.com.br", "João Carlos"),
                new Usuario("ana@cmu.com.br", "Ana Maria"),
                new Usuario("pedro@cmu.com.br", "Pedro Almeida"),
                new Usuario("joaozin@cmu.com.br", "João Marcelo")})); // new List<Usuario> {Usuario{"Ana Maria"}, Usuario{"João Carlos"}, Usuario{"João Marcelo"}, Usuario{"Pedro Almeida"} }

            Imprime(OrdenaUsuarios(new List<Usuario> {})); // new List<Usuario> {}

            Imprime(OrdenaUsuarios(new List<Usuario> {
                new Usuario("jc@cmu.com.br", "João Carlos"),
                new Usuario("ana@cmu.com.br", "Ana Maria"),
                new Usuario("pedro@cmu.com.br", "Pedro Almeida"),
                new Usuario("joaozin@cmu.com.br", "João Carlos")})); // ERRO

            Imprime(OrdenaUsuarios(null)); // ERRO
        }
        public static void Imprime(List<Usuario> lista)
        {
            if(lista != null) { Console.WriteLine("{"+ string.Join(",", lista.Select(p=>p.Nome)) + "}");}
            else{ Console.WriteLine("ERRO");}
        }
    }
}


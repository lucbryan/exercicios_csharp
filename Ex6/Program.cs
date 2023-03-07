using System.Linq;

namespace exercicio6
{
    public class Program
    {
        public static List<List<int>> QuebraLista(List<int> array, int y)
        {
            int numero_listas;
            List<int> lista = new List<int>();
            List<List<int>> lista_das_lista = new List<List<int>>();

            // Se o y for maior que o número de elementos, havera apenas uma sublista contendo todos itens.
            if (y > array.Count()) { lista = array.GetRange(0, array.Count()); lista_das_lista.Add(lista); }

            else
            {
                numero_listas = array.Count() / y;

                if (array.Count() % y != 0) { numero_listas++; }

                bool is_ = array.Count() % y != 0; // é fracionario
                int u = 0;

                for (int i = 0; i < numero_listas; i++)
                {
                    if (is_ == true && u == array.Count() - 1)
                    {
                        lista = array.GetRange(u, 1);
                    }
                    else
                    {
                        lista = array.GetRange(u, y);
                        u += y;
                    }
                    lista_das_lista.Add(lista);

                }
            }

            return lista_das_lista;
        }

        public static void Imprime(List<List<int>> listaDeListas)
        {
            string listaConcatenadaStr = "";
            foreach (var lista in listaDeListas)
            {
                listaConcatenadaStr += "[" + string.Join(",", lista) + "] ";
            }
            Console.WriteLine("{" + listaConcatenadaStr + "}\n");
        }
        
        public static void Main(string[] args)
        {
            // Exemplos para teste. Sinta-se à vontade para completar com outros testes!

            Imprime(QuebraLista(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3)); // new List<List<int>>{new List<int>{1, 2, 3}, new List<int>{4, 5, 6}, new List<int>{7, 8, 9}, new List<int>{10}}
            Imprime(QuebraLista(new List<int> { 2, 4, 6, 8, 10, 12, 14, 16 }, 4)); // new List<List<int>>{new List<int>{2, 4, 6, 8}, new List<int>{10, 12, 14, 16}}
            Imprime(QuebraLista(new List<int> { 2, 4, 6, 8, 10, 12, 14, 16 }, 40)); // new List<List<int>>{new List<int>{2, 4, 6, 8, 10, 12, 14, 16}}
            Imprime(QuebraLista(new List<int> { }, 4)); // new List<int>{}

            Console.ReadKey();
        }
    }
}


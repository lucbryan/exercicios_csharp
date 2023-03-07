namespace exercicio2
{
    public class Program
    {    
        public static int ContaAparicoes(string frase, string palavra)
        {

            int aparicoes = 0;

            for(int i = 0; i < frase.Length; i++)
            {
                if(frase[i] == palavra[0]){
                    try
                    {
                        if (frase.Substring(i, palavra.Length) == palavra) { aparicoes++; }
                        i += palavra.Length - 1;
                    }
                    catch { break; }
                }
            }
            return aparicoes;
        }
        public static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(ContaAparicoes("Banana", "a")); // 3
            Console.WriteLine(ContaAparicoes("Banana", "na")); // 2
            Console.WriteLine(ContaAparicoes("Banana", "ka")); // 0
            Console.WriteLine(ContaAparicoes("BBBBBBBBB", "BB")); // 4
            Console.WriteLine(ContaAparicoes("Paralelepipedo", "le")); // 2
            Console.WriteLine(ContaAparicoes("Paralelepipedo", "lele")); // 1
            Console.WriteLine(ContaAparicoes("O rato roeu a roupa do rei de roma", "ro")); // 3
            Console.ReadLine();
        }
    }
}


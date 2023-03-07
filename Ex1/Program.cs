using System.Linq;


namespace exercicio1
    {
        public class Program
        {
            public static List<string> FiltraTerminadasEmA(List<string> array)
            {
                return array.Where(p => p.EndsWith("a")).ToList();
            }
            public static void Main(string[] args)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Imprime(FiltraTerminadasEmA(new List<string> { "Pera", "Maçã", "Banana", "Uva", "Abacate" })); // new List<string> {"Pera", "Banana", "Uva"}
                Imprime(FiltraTerminadasEmA(new List<string> { "BANANA", "AZEITE", "Sacola", "MERCADO" })); // new List<string> {"BANANA", "Sacola"}
                Imprime(FiltraTerminadasEmA(new List<string> { })); // new List<string> {}
                Imprime(FiltraTerminadasEmA(new List<string> { "Vaca", "Leão", "Tigre", "Coiote", "Baleia", "Gato", "Lontra", "Iguana" })); // new List<string> {"Vaca", "Baleia", "Lontra", "Iguana"}
                Imprime(FiltraTerminadasEmA(new List<string> { "AUSTRALIA", "BRASIL", "ARGENTINA", "ALEMANHA", "CANADÁ", "VENEZUELA", "URUGUAI", "PARAGUAI" })); // new List<string> {"AUSTRÁLIA", "ARGENTINA", "ALEMANHA", "VENEZUELA"}
                Console.ReadLine();

            }
            public static void Imprime(List<string> array)
            {
                Console.WriteLine("{" + string.Join(", ", array) + "}");
            }
    }
}
    


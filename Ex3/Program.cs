namespace exercicio3
{
    public class Program
    {
        public static string ContaDias(string data1, string data2)
        {
            try
            {
                var Data1 = ConverteParaDataTime(data1);
                var Data2 = ConverteParaDataTime(data2);

                if (Data1 > Data2){
                    return Convert.ToString(Data1.Subtract(Data2).TotalDays);
                }   
                return Convert.ToString(Data2.Subtract(Data1).TotalDays);
            }
            catch(Exception e) { return String.Format("ERRO: {0}",e.Message); }
        }
        public static DateTime ConverteParaDataTime(string d)
        {
            var data = d.Split('-');
            return new DateTime(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), Convert.ToInt32(data[2]));
        }


        public static void Main(string[] args)
        {
            // Exemplos para teste. Sinta-se à vontade para completar com outros testes!

            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine(ContaDias("2023-02-01", "2023-02-02")); // 1
            Console.WriteLine(ContaDias("2023-02-01", "2023-02-15")); // 14
            Console.WriteLine(ContaDias("2023-02-01", "2022-02-01")); // 365
            Console.WriteLine(ContaDias("2022-02-01", "2023-02-01")); // 365
            Console.WriteLine(ContaDias("2023-02-01", "2023-02-01")); // 0
            Console.WriteLine(ContaDias("2023-02-01", "2023/02/01")); // ERRO
            Console.WriteLine(ContaDias("2000-04-11", "2023-03-07")); // 8365
        }
    }
}


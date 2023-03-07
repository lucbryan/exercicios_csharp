using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace exercicio8
{
    public class CMCar
    {
        private List<Frota> frotas = new List<Frota>();
        public Frota AdicionarFrota { set { frotas.Add(value); } }

        public List<Frota> Frotas { get { return frotas; } set { frotas = value; } }

        public int VeiculosXPortas(int portas)
        {
            return frotas.SelectMany(f => f.Veiculos)
            .Count(v => v.PortasSimples == portas && v.TipoVeiculo == "CARRO");
        }

        public List<Veiculo> MaisAntigos()
        {
            var juncao_frotas = frotas.SelectMany(f => f.Veiculos).ToList();
            juncao_frotas = juncao_frotas.OrderBy(v => v.Ano_Veiculo).ToList();
            return juncao_frotas.ToList().FindAll(v => v.Ano_Veiculo == juncao_frotas[0].Ano_Veiculo);
        }

        public int MaisVans()
        {
            int mais_vans = 0;
            int frota_maior = 0;

            for(int i = 0; i < frotas.Count(); i++)
            {
                int vans_ = frotas[i].Veiculos.Count(f => f.TipoVeiculo == "VAN");
                if(vans_ > mais_vans) { mais_vans = vans_;  frota_maior = i + 1; }
            }

            return frota_maior;
        }
    }

    public class Frota 
    {
        private string nome = "";
        private string cnpj = "";
        List<Veiculo> veiculos = new List<Veiculo>();

        public string Nome { get { return nome; } set { nome = value; } }
        public string CNPJ { get { return cnpj; } set { cnpj = value; } }
        public List<Veiculo> Veiculos { get { return veiculos; } set { veiculos = value; } }
        public Veiculo AdicionarVeiculo { set { veiculos.Add(value); } }
        public int Quantidade_Veiculos { get { return veiculos.Count();} }

        public Frota(string nome, string CNPJ)
        {
            this.nome = nome;
            this.CNPJ = CNPJ;
        }
        public int CapacidadeTotal()
        {
            int capacidade_total = 0;
            foreach(var veiculo in veiculos) { 
                capacidade_total += veiculo.Capacidade();
            }
            return capacidade_total;
        }

        public double MediaKm()
        {
            double kms_total = 0;
            foreach (var veiculo in veiculos)
            {
                kms_total += veiculo.Quilometros_Rodados;
            }
            return kms_total / veiculos.Count();
        }

        public List<Veiculo> MaisNovos()
        {
            List<Veiculo> veiculos_mais_novos = new List<Veiculo>();
            var veiculos_ordenados = veiculos.OrderBy(v => v.Ano_Veiculo).ToList();
            return veiculos_ordenados.FindAll(f => f.Ano_Veiculo == veiculos_ordenados[veiculos_ordenados.Count() - 1].Ano_Veiculo);

        }
        public List<Veiculo> MaisRodados()
        {
            List<Veiculo> veiculos_mais_rodados = new List<Veiculo>();
            var veiculos_ordenados = veiculos.OrderBy(f => f.Quilometros_Rodados).ToList();
            return veiculos_ordenados.FindAll(f => f.Quilometros_Rodados == veiculos_ordenados[veiculos_ordenados.Count()-1].Quilometros_Rodados);

        }

        public void OrdenaVeiculos()
        {
            for (int i = 0; i < veiculos.Count(); i++)
            {
                for (int j = i; j < veiculos.Count(); j++)
                {

                    if (veiculos[i].Ano_Veiculo < veiculos[j].Ano_Veiculo)
                    {
                        var aux = veiculos[i];
                        veiculos[i] = veiculos[j];
                        veiculos[j] = aux;
                    }
                }

            }

        }
    }
    public class Veiculo 
    {
        private int ano_veiculo;
        private double quilometros_rodados;
        private int portas_simples;
        private string  marca = "";
        private string tipo_de_veiculo = "";

        public int Ano_Veiculo { get { return ano_veiculo; } set { ano_veiculo = value; } }
        public double Quilometros_Rodados { get { return quilometros_rodados; } set { quilometros_rodados = value; } }
        public string Marca { get { return marca; } set { marca = value; } }
        public int PortasSimples { get { return portas_simples; } set { portas_simples = value; } }
        public string TipoVeiculo { get { return tipo_de_veiculo; } set { tipo_de_veiculo = value; } }
        public virtual int Capacidade() { return 0; }

    }
    public class Carro : Veiculo 
    {
        public override int Capacidade() { return 5; }
    }
    public class Moto : Veiculo 
    {
        public override int Capacidade() { return 2; }
    }
    public class Van : Veiculo {

        private const int portas_de_correr = 1;
        public override int Capacidade() { return 12; }
    }

    public class Program
    {

        private static Veiculo TipoVeiculo(string tipo_veiculo)
        {
            switch (tipo_veiculo)
            {
                case "VAN":
                    {
                        Van van = new Van();
                        return van;
                    }

                case "CARRO":
                    {
                        Carro carro = new Carro();
                        return carro;
                    }

                case "MOTO":
                    {
                        Moto moto = new Moto();
                        return moto;
                    }
            }
            return null;
        }

        private static List<Veiculo> InstanciarVeiculos(string file_name)
        {
            List<Veiculo> veiculos = new List<Veiculo>();
            StreamReader arquivoVeiculos = new StreamReader(String.Format("Arquivos/{0}.txt", file_name));
            while (!arquivoVeiculos.EndOfStream)
            {
                var linha = arquivoVeiculos.ReadLine();
                var dados_veiculo = linha.Split(":")[1].Split(";");

                var tipo_veiculo = dados_veiculo[0].Split(" ")[1].ToUpper();
                var ano_veiculo = dados_veiculo[0].Split(" ")[5];
                var quilometros = dados_veiculo[1].Split(" ")[1];
                var veiculo = TipoVeiculo(tipo_veiculo);

                veiculo.Marca = dados_veiculo[0];
                veiculo.Ano_Veiculo = Convert.ToInt32(ano_veiculo);
                veiculo.Quilometros_Rodados = Convert.ToDouble(quilometros);
                veiculo.TipoVeiculo = tipo_veiculo;

                if (tipo_veiculo != "MOTO") { veiculo.PortasSimples = Convert.ToInt32(dados_veiculo[2].Split(" ")[1]); }

                veiculos.Add(veiculo);
            }
            return veiculos;
        }

        public static void Main(string[] args)
        {

            CMCar CmCar_ = new CMCar();

            Frota frota1 = new Frota("Cooperativa de veículos CMCar LTDA", "03.019.756/0001-70");
            Frota frota2 = new Frota("Consórcio de veículos CMCar S.A", "26.402.504/0001-21");

            frota1.Veiculos = InstanciarVeiculos("Frota1");
            frota2.Veiculos = InstanciarVeiculos("Frota2");

            CmCar_.AdicionarFrota = frota1;
            CmCar_.AdicionarFrota = frota2;


            Console.WriteLine("");

            // a) A quantidade de veículos da frota 1. Resposta: 10

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(String.Format("Quantidade de veículas na frota 1 : {0}.",frota1.Quantidade_Veiculos));
            Console.WriteLine("------------------------------------------------------------");

            // b) A quantidade de carros com 4 portas na empresa. Resposta: 3

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format("Quantidade de carros com 4 portas: {0}.", CmCar_.VeiculosXPortas(4)));
            Console.WriteLine("------------------------------------------------------------");


            // c) O total de lugares (capacidade) disponíveis da frota 1. Resposta: 82

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("Quantidade total de lugares disponíveis na frota 1: {0}.", CmCar_.Frotas[0].CapacidadeTotal())) ;
            Console.WriteLine("------------------------------------------------------------");


            // d) A média de quilômetros rodados de todos os veículos da frota 2. Resposta: 24.487,5

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(String.Format("Media de Km's rodados na frota 2: {0}.", CmCar_.Frotas[1].MediaKm()));
            Console.WriteLine("------------------------------------------------------------");


            // e) O(s) veículo(s) mais novo(s) da frota 1 (retornar em forma de lista, pois pode haver mais de um). Resposta: Veiculo 4 e Veiculo 10

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Os veículos mais novos da frota 1: \n");
            CmCar_.Frotas[0].MaisNovos().ForEach(v => Console.WriteLine(v.Marca));
            Console.WriteLine("------------------------------------------------------------");


            // f) O(s) veículo(s) mais rodado(s) da frota 2 (retornar em forma de lista, pois pode haver mais de um). Resposta: Veiculo 11 e Veiculo 14

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Os veículos mais rodados da frota 2: \n");
           CmCar_.Frotas[1].MaisRodados().ForEach(v => Console.WriteLine(v.Marca + " " + v.Quilometros_Rodados));
            Console.WriteLine("------------------------------------------------------------");



            // g) O(s) veículo(s) mais antigo(s) da empresa (retornar em forma de lista, pois pode haver mais de um). Resposta: Veiculo 5

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Os veículos mais antigos da empresa: \n");
            CmCar_.MaisAntigos().ForEach(v => Console.WriteLine(v.Marca + " " + v.Quilometros_Rodados));
            Console.WriteLine("------------------------------------------------------------");



            // h) A frota com a maior quantidade de vans (retornar em forma de lista, pois pode haver mais de um) Resposta: Frota 1
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A frota com maior quantidade de vans: " + CmCar_.MaisVans()) ;

            Console.ReadKey();

        }

    }
}

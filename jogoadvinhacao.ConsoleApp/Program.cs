namespace jogoadvinhacao.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Exibição do menu do jogo 
                int totalDeTentativas = ExibirMenu();

                // Geração de número secreto
                Random geradorDeNumeros = new Random();
                int numeroSecreto = geradorDeNumeros.Next(1, 21);

                // Loop de tentativas do jogo
                for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
                {
                    //Menu do Jogo
                    int numeroDigitado = MenuDoJogo(tentativa, totalDeTentativas);

                    // resultado do jogo
                    bool ehFinalizado= ResultadoDoJogo(numeroDigitado, numeroSecreto, tentativa, totalDeTentativas);
                    if (ehFinalizado)
                    {
                        break;
                    }

                    Console.WriteLine("Aperte ENTER para continuar...");
                    Console.ReadLine();
                }

                Console.Write("Deseja continuar? (S/N): ");
                string opcaoContinuar = Console.ReadLine()!.ToUpper();

                if (opcaoContinuar != "S")
                    break;
            }
        }
        
        static int ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Jogo de Adivinhação");
            Console.WriteLine("---------------------------------");

            // Escolha de dificuldade
            Console.WriteLine("Escolha um nível de dificuldade:");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Fácil (10 tentativas)");
            Console.WriteLine("2 - Médio (5 tentativas)");
            Console.WriteLine("3 - Difícil (3 tentativas)");
            Console.WriteLine("---------------------------------");

            int totalDeTentativas = 0;

            Console.Write("Digite sua escolha: ");

            string entrada = Console.ReadLine()!;

            if (entrada == "1")
                totalDeTentativas = 10;
            else if (entrada == "2")
                totalDeTentativas = 5;
            else if (entrada == "3")
                totalDeTentativas = 3;

            return totalDeTentativas;
        }

        static bool ResultadoDoJogo(int numeroDigitado, int numeroSecreto, int tentativa, int totalDeTentativas)
        {
            if (numeroDigitado == numeroSecreto)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Parabéns! Você acertou!");
                Console.WriteLine("----------------------------------------");
                return true;
            }

            if (tentativa == totalDeTentativas)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Que pena! Você usou todas as tentativas. O número era {numeroSecreto}.");
                Console.WriteLine("----------------------------------------");
                return true;
            }

            else if (numeroDigitado > numeroSecreto)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("O número digitado é maior que o número secreto.");
                Console.WriteLine("----------------------------------------");
                return false;
            }
            else
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("O número digitado é menor que o número secreto.");
                Console.WriteLine("----------------------------------------");
                return false;
            }
        }

        static int MenuDoJogo(int tentativa, int totalDeTentativas)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Tentativa {tentativa} de {totalDeTentativas}");
            Console.WriteLine("----------------------------------------");

            // Lógica do jogo
            Console.Write("Digite um número entre 1 e 20: ");
            int numeroDigitado = Convert.ToInt32(Console.ReadLine());
            return numeroDigitado;
        }
    }

}

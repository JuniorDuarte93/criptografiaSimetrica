using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication28
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declarando variáveis.

            string frase, frase2, resposta = "s"; // Variáveis simples do tipo texto.
            int[] vetor, vetor2; // Variáveis homogênea e unidimensional do tipo inteira (numérico).
            char[] text; // Variável simples do tipo caracter.

            //A chave
            int chave = 0, chave2 = 0, valorInteiro, valorInteiro2;
            bool repchave, repchave2, eNumeroInteiro, eNumeroInteiro2; // Variáveis simples do tipo boleana.
            string chaveVerifica, chaveVerifica2;


            while (resposta == "s")
            {
                Console.ForegroundColor = ConsoleColor.White; // Alterando para a cor branca.
                Console.WriteLine("==========================================================================");
                Console.WriteLine("|                                                                        | ");
                Console.WriteLine("|                       Criptografia (Simétrica)                         | ");
                Console.WriteLine("|                                                                        | ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray; // Alterando para a cor padrão (cinza).

                // Criptografando
                Console.WriteLine("Digite um número inteiro como chave para criptografar:");
                repchave = true;
                //Verificando se a chave digitada é um número inteiro.
                while (repchave == true)
                {
                    //Variável que que será testada
                    chaveVerifica = Console.ReadLine();

                    //Validando se é inteiro utilizando o recurso TryParse
                    //No método passamos primeiro uma string, e depois a saída "out"
                    eNumeroInteiro = int.TryParse(chaveVerifica, out valorInteiro);  //Variável que terá o valor, caso seja inteiro (valorInteiro).

                    //Verificando se é um número
                    if (eNumeroInteiro)
                    {
                        chave = valorInteiro;
                        repchave = false;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red; // Alterando para a cor vermelha.
                        Console.WriteLine("Por favor, digite um número inteiro como chave para criptografar:");
                        Console.ForegroundColor = ConsoleColor.Gray; // Alterando para a cor padrão (cinza).
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Digite uma mensagem a ser criptografada:");
                frase = Console.ReadLine();
                Console.WriteLine();

                // Atribuindo módulo ao vetor
                vetor = new Int32[frase.Length]; // O tamanho do vetor, será de acordo com o tamanho da frase.
                text = new char[frase.Length]; // O tamanho do vetor, será de acordo com o tamanho da frase.

                Console.WriteLine("Mensagem criptograda:");
                for (int i = 0; i < frase.Length; i++) // Para i de 0 até o tamanho da frase, 1 em 1, faça.
                {
                    vetor[i] = frase[i]; // Cada letra da frase é armazenada em um espaço do vetor.
                    vetor[i] = vetor[i] + ((chave % 23) + 23) % 23; // Para cada espaço do vetor, será feito este cálculo.
                    text[i] = Convert.ToChar(vetor[i]); // Vetor(text) recebendo a  vetor (vetor) convertida em char (caracteres).

                    //Escrevendo o texto criptografado.
                    Console.Write(Convert.ToChar(vetor[i]));
                }


                //=========================================================================================================

                // Criando a pasta e o arquivo (.txt)

                // Variáveis
                string text1 = new string(text); // Variável criada para receber o vetor (text), convertido em string.
                string usuarioLogado = System.Environment.UserName; // Variável criada para receber o nome do usuário logado no windows.

                // Criando a pasta
                string Mensagens_Criptografadas = @"C://Users//" + usuarioLogado + "//Desktop//Mensagens_Criptografadas"; //Determinando o nome e local onde a pasta será criada.
                Directory.CreateDirectory(Mensagens_Criptografadas); // Criando a pasta.

                // Criando o arquivo (.txt)
                string Mensagem_Criptografada = @"C://Users//" + usuarioLogado + "//Desktop//Mensagens_Criptografadas//Mensagem_Criptografada" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt"; //Determinando o nome e local onde será salvo o arquivo (.txt).
                StreamWriter writer = new StreamWriter(Mensagem_Criptografada); //Determinado a criação do arquivo, assim que o ocorrer o fechamento do arquivo.

                //Determinado o que será salvo no arquivo(.text).
                writer.WriteLine("=============================================");
                writer.WriteLine("|         Criptografia (Simétrica)          |");
                writer.WriteLine("=============================================");
                writer.WriteLine();
                writer.WriteLine("Chave Utilizada: " + chave);
                writer.WriteLine("Mensagem Original: " + frase);
                writer.WriteLine("Mensagem Criptografada: " + text1);
                writer.WriteLine();
                writer.WriteLine("=============================================");
                writer.WriteLine("Data e Hora");
                writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                writer.Close();
                //Fechando o arquivo.

                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green; // Alterando a cor para verde.
                Console.WriteLine("Mensagem salva na Área de Trabalho na pasta 'Mensagens_Criptografadas' ");
                Console.ForegroundColor = ConsoleColor.White; // Alterando para a cor branca.

                Console.WriteLine("");
                Console.WriteLine("==========================================================================");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray; // Alterando para a cor padrão (cinza).

                //=========================================================================================================

                // Descriptografando
                Console.WriteLine("Digite o mesmo número inteiro como chave para descriptografar:");
                repchave2 = true;
                //Verificando se a chave digitada é um número inteiro.
                while (repchave2 == true)
                {
                    //Variável que que será testada
                    chaveVerifica2 = Console.ReadLine();

                    //Validando se é inteiro utilizando o recurso TryParse
                    //No método passamos primeiro uma string, e depois a saída "out"
                    eNumeroInteiro2 = int.TryParse(chaveVerifica2, out valorInteiro2);  //Variável que terá o valor, caso seja inteiro (valorInteiro).

                    //Verificando se é um número
                    if (eNumeroInteiro2)
                    {
                        chave2 = valorInteiro2;
                        repchave2 = false;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red; // Alterando para a cor vermelha.
                        Console.WriteLine("Por favor, digite o mesmo número inteiro como chave para descriptografar:");
                        Console.ForegroundColor = ConsoleColor.Gray; // Alterando para a cor padrão (cinza).
                    }
                }

                Console.WriteLine();

                Console.WriteLine("Digite a mensagem a ser descriptografada:");
                frase2 = Console.ReadLine();
                vetor2 = new Int32[frase2.Length];
                Console.WriteLine();

                Console.WriteLine("Mensagem descriptografada:");
                for (int i = 0; i < frase2.Length; i++)
                {
                    vetor2[i] = frase2[i];
                    vetor2[i] = vetor2[i] - ((chave2 % 23) + 23) % 23;

                    Console.Write(Convert.ToChar(vetor2[i]));
                }

                Console.ForegroundColor = ConsoleColor.White; // Alterando para a cor branca.
                Console.WriteLine("\n");
                Console.WriteLine("==========================================================================");
                Console.ForegroundColor = ConsoleColor.Gray; // Alterando para a cor padrão (cinza).

                Console.WriteLine("");
                Console.WriteLine("Deseja criptografar uma nova mensagem?\n\ns = sim. \nn = não.");
                resposta = Console.ReadLine();
                resposta = resposta.ToLower(); //Convertendo a resposta em minúsculo, caso o usuário digite a resposta em maiúsculo.

                //Limpando a tela.
                Console.Clear();
            }


            // Fechando o console, se a resposta for n (não).
            if (resposta == "n")
            {
                Environment.Exit(0);
            }

            //=========================================================================================================
        }
    }
}

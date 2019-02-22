using Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.Um
{
    public class Program
    {
        static public short exemploShort = -32768; // -32.768 a 32.767
        static readonly long exemploLong = 9223372036854775807; // -9.223.372.036.854.775.808 a 9.223.372.036.854.775.807
        static readonly float exemploFloat = 3.5F; // -3,4 × 1038 a +3,4 × 1038
        static readonly byte exemploByte = 255; // 0 a 255
        static readonly sbyte exemploSByte = 127; // -128 a 127

        static void Main()
        {
            Helper.Printar("***************** CASTS IMPLÍCITOS *****************");
            Casts_Implicitos();
            Helper.Printar("****************************************************");

            Helper.Printar("***************** CASTS EXPLÍCITOS *****************");
            Casts_Explicitos();
            Helper.Printar("****************************************************");

            Console.ReadLine();
        }

        #region Casts Implícitos        
        /// <summary>
        /// Os casts implícitos podem acontecer quando uma variável de um determinado tipo
        /// pode ser atribuído à outra variável de um tipo diferente, sem risco de perda de informação
        /// por exemplo: uma variável int pode receber um byte pois o range de valores do tipo byte está contido no tipo int
        /// para casts implícitos não é necessário nenhuma sintaxe diferente, simplesmente atribuir uma variável na outra
        /// </summary>
        private static void Casts_Implicitos()
        {
            De_SByte_Para_Short_Int_Long_Float_Double_E_Decimal();

            De_Byte_Para_Short_UShort_Int_UInt_Long_ULong_Float_Double_E_Decimal();

            De_Carreta_Para_Veiculo();
        }

        /// <summary>
        /// A conversão de tipos implícitos valem também para classes, por exemplo,
        /// caso eu queira converter uma classe derivada em uma classe base,
        /// eu posso simplesmente fazer um objeto receber o outro
        /// </summary>
        private static void De_Carreta_Para_Veiculo()
        {
            Console.WriteLine("De Carrega para Veiculo:");

            var c = new Carreta
            {
                Placa = "AAA-0000",
                QuantidadeDeEixos = 2
            };

            Veiculo v = c;

            Console.WriteLine($"- O veículo de placa {v.Placa} foi convertido implicitamente, antes era um objeto da classe {nameof(Carreta)}");

            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Neste método é mostrado a conversão de uma variável SByte para vários tipos que contém a sua faixa de valores
        /// Como short, int, long, float, double e decimal
        /// </summary>
        private static void De_SByte_Para_Short_Int_Long_Float_Double_E_Decimal()
        {
            Console.WriteLine("De sbyte para short, int, long, float, double e decimal:");

            short exemploDeSByteParaShort = exemploSByte;
            Console.WriteLine($"- O valor {exemploSByte} foi convertido implicitamente de sbyte para short");
            int exemploDeSByteParaInt = exemploSByte;
            Console.WriteLine($"- O valor {exemploSByte} foi convertido implicitamente de sbyte para int");
            long exemploDeSByteParaLong = exemploSByte;
            Console.WriteLine($"- O valor {exemploSByte} foi convertido implicitamente de sbyte para long");
            float exemploDeSByteParaFloat = exemploSByte;
            Console.WriteLine($"- O valor {exemploSByte} foi convertido implicitamente de sbyte para float");
            double exemploDeSByteParaDouble = exemploSByte;
            Console.WriteLine($"- O valor {exemploSByte} foi convertido implicitamente de sbyte para double");
            decimal exemploDeSByteParaDecimal = exemploSByte;
            Console.WriteLine($"- O valor {exemploSByte} foi convertido implicitamente de sbyte para decimal");

            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Neste método é mostrado a conversão de uma variável byte para vários tipos que contém a sua faixa de valores
        /// Como short, ushort, int, unit, long, ulong, float, double e decimal
        /// </summary>
        private static void De_Byte_Para_Short_UShort_Int_UInt_Long_ULong_Float_Double_E_Decimal()
        {
            Console.WriteLine("De sbyte para short, ushort, int, uint, long, ulong, float, double e decimal:");

            short exemploDeByteParaShort = exemploByte;
            Console.WriteLine($"- O valor {exemploByte} foi convertido implicitamente de byte para short");
            ushort exemploDeByteParaUShort = exemploByte;
            Console.WriteLine($"- O valor {exemploDeByteParaUShort} foi convertido implicitamente de byte para ushort");
            int exemploDeByteParaInt = exemploByte;
            Console.WriteLine($"- O valor {exemploByte} foi convertido implicitamente de byte para int");
            uint exemploDeByteParaUInt = exemploByte;
            Console.WriteLine($"- O valor {exemploByte} foi convertido implicitamente de byte para uint");
            long exemploDeByteParaLong = exemploByte;
            Console.WriteLine($"- O valor {exemploByte} foi convertido implicitamente de byte para long");
            ulong exemploDeByteParaULong = exemploByte;
            Console.WriteLine($"- O valor {exemploByte} foi convertido implicitamente de byte para ulong");
            float exemploDeByteParaFloat = exemploByte;
            Console.WriteLine($"- O valor {exemploByte} foi convertido implicitamente de byte para float");
            double exemploDeByteParaDouble = exemploByte;
            Console.WriteLine($"- O valor {exemploByte} foi convertido implicitamente de byte para double");
            decimal exemploDeByteParaDecimal = exemploByte;
            Console.WriteLine($"- O valor {exemploByte} foi convertido implicitamente de byte para decimal");

            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }
        #endregion

        #region Casts Explícitos
        /// <summary>
        /// Os casts explícitos são necessárias quando pode ocorrer a perca de informação 
        /// na conversão ou que ela não possa acontecer por algum outro motivo
        /// Um exemplo de cast explícito seria atribuir um valor com algumas casas de precisão
        /// à um tipo inteiro, por exemplo: converter um float 1.5 em um inteiro, o que resultaria no valor 1
        /// </summary>
        private static void Casts_Explicitos()
        {
            De_Float_E_Long_Para_Int();

            De_Veiculo_Para_Carreta();
        }

        /// <summary>
        /// Para converter um objeto do tipo base para o tipo derivado é necessário um cast explícito
        /// Pois o compilador precisa ser notificado de que o objeto a ser atribuido é de fato, neste caso, uma Carreta
        /// </summary>
        private static void De_Veiculo_Para_Carreta()
        {
            Console.WriteLine("De Veículo para Carreta:");

            var c = new Carreta
            {
                Placa = "BBB-1111",
                QuantidadeDeEixos = 4
            };

            Veiculo v = c;

            Carreta c2 = (Carreta)v;

            Console.WriteLine($"- A carreta de placa {c2.Placa} foi convertida explicitamente, antes era um objeto da classe {nameof(Carreta)} " +
               $"que foi convertida para {nameof(Veiculo)} e depois novamente para {nameof(Carreta)}. Caso o objeto 'c' não fosse uma carreta o programa" +
               $" compilaria porém daria uma exceção em tempo de execução devido ao objeto não ser de fato do tipo {nameof(Carreta)}");

            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Neste método é mostrado a conversão de um tipo com precisão (float) e um tipo que contém uma faixa de valores maior 
        /// do que a suportada pelo tipo int (long)
        /// Para efetuar um cast explícito é necessário demarcar o código com a palavra reservada referente ao tipo de destino 
        /// </summary>
        private static void De_Float_E_Long_Para_Int()
        {
            Console.WriteLine("De float e long para int:");

            int exemploDeFloatParaInt = (int)exemploFloat;
            Console.WriteLine($"- O valor {exemploFloat} foi convertido explicitamente de float para int e o valor passou a ser {exemploDeFloatParaInt}");
            int exemploDeLongParaInt = (int)exemploLong;
            Console.WriteLine($"- O valor {exemploLong} foi convertido explicitamente de long para int e o valor passou a ser {exemploDeLongParaInt}. Esta conversão não é correta pois o tipo int não contém o range de valores do tipo long.");
            long exemploDeLongDentroDoRangeDeInt = 1000;
            int exemploDeLongDentroDoRangeParaInt = (int)exemploDeLongDentroDoRangeDeInt;
            Console.WriteLine($"- O valor {exemploDeLongDentroDoRangeDeInt} foi convertido explicitamente de long para int e o valor passou a ser {exemploDeLongDentroDoRangeParaInt}. Esta conversão foi possível pois o valor atribuído ao long estava contido na faixa suportada pelo int");


            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }
        #endregion
    }
}

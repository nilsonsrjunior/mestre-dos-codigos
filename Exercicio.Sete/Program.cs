using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercicio.Sete
{
    class Program
    {
        /// <summary>
        /// O cenário deste programa é onde um ecommerce irá rodar 
        /// tarefas pertinentes ao cenário do negócio em um horário de baixo acesso (madrugada)
        /// Após a execução das tarefas o administrador será notificado.
        /// O Programa faz uso de Task.Delay para simular as operações fim de cada método.
        /// Esta funcionalidade, diferentemente do Thread.Sleep, apenas simula o tempo que um processamento
        /// Levou para executar, não bloqueando a main Thread de quem o chamou.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var clientes = new List<Cliente>() {
                new Cliente { Nome = "José", DataNascimento = DateTime.Now.AddYears(-18), Faturas = new List<Fatura> { new Fatura { Valor = 10, DataFatura = DateTime.Now.AddMonths(1).AddDays(5) } } },
                new Cliente { Nome = "Antonio", DataNascimento = DateTime.Now.AddYears(-22), Faturas = new List<Fatura> { new Fatura { Valor = 15, DataFatura = DateTime.Now.AddMonths(1).AddDays(5) } } },
                new Cliente { Nome = "Ana", DataNascimento = DateTime.Now.AddYears(-25), Faturas = new List<Fatura> { new Fatura { Valor = 102, DataFatura = DateTime.Now.AddMonths(1).AddDays(5) } } },
                new Cliente { Nome = "Maria", DataNascimento = DateTime.Now.AddYears(-23), Faturas = new List<Fatura> { new Fatura { Valor = 120, DataFatura = DateTime.Now.AddMonths(1).AddDays(5) } } }
            };

            // O WaitAll irá esperar que todas as tasks passadas como parametro sejam executadas para então seguir a execução do programa
            Task.WaitAll(GerarFaturasDoProximoMesAsync(clientes), EnviarEmailAniversarioAsync(clientes));

            Task.Delay(0).ConfigureAwait(false);

            EnviarEmailAdministrador();

            Console.ReadLine();
        }

        /// <summary>
        /// As rotinas a serem executadas durante a noite foram realizadas com sucesso.
        /// </summary>
        private static async void EnviarEmailAdministrador()
        {
            var enviou = await EnviarEmailAsync("adm@adm.com.br", "Tarefas realizadas");

            if (enviou)
            {
                Console.WriteLine("O email foi enviado para o administrador!");
            }
        }

        private static async Task EnviarEmailAniversarioAsync(List<Cliente> clientes)
        {
            var aniversariantes = clientes.Where(x => x.DataNascimento.Day == DateTime.Now.Day && x.DataNascimento.Month == DateTime.Now.Month);

            foreach (var aniversariante in aniversariantes)
            {
                var resultEmail = EnviarEmailAsync(aniversariante.Nome, "Feliz aniversário!");
                await resultEmail;
            }
        }

        private static async Task<bool> EnviarEmailAsync(string nome, string textoDoEmail)
        {
            await Task.Delay(5000);
            return await Task.FromResult(true);
        }

        private static async Task GerarFaturasDoProximoMesAsync(ICollection<Cliente> clientes)
        {
            var proximoMes = DateTime.Now.AddMonths(1);

            foreach (var cliente in clientes)
            {
                await GerarFaturaAsync(cliente, proximoMes);
                await NotificarClienteAsync(cliente, proximoMes);
            }
        }

        private static async Task NotificarClienteAsync(Cliente cliente, DateTime proximoMes) => await Task.Delay(1000);

        private static async Task GerarFaturaAsync(Cliente cliente, DateTime proximoMes) => await Task.Delay(1000);

        private struct Cliente
        {
            public string Nome { get; set; }
            public DateTime DataNascimento { get; set; }
            public ICollection<Fatura> Faturas { get; set; }
        }

        private struct Fatura
        {
            public DateTime DataFatura { get; set; }
            public decimal Valor { get; set; }
        }
    }
}

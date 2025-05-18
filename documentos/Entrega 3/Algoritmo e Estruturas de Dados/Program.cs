using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class EventoInstitucional
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public DateTime Data { get; set; }
    public string Local { get; set; }
    public int VagasDisponiveis { get; set; }
    public bool InscricoesAbertas { get; set; }
}

public class ServicoEventos
{
    // Simula dados vindos de um "servidor"
    private List<EventoInstitucional> eventosServidor = new List<EventoInstitucional>
    {
        new EventoInstitucional { Id = 1, Nome = "Feira de Ciências", Tipo = "Exposição", Data = new DateTime(2025, 4, 20), Local = "Auditório A", VagasDisponiveis = 50, InscricoesAbertas = true },
        new EventoInstitucional { Id = 2, Nome = "Palestra de TI",    Tipo = "Palestra",  Data = new DateTime(2025, 5, 10), Local = "Sala 101",     VagasDisponiveis = 0,  InscricoesAbertas = false },
        new EventoInstitucional { Id = 3, Nome = "Workshop .NET",     Tipo = "Workshop",  Data = new DateTime(2025, 5, 15), Local = "Lab 3",        VagasDisponiveis = 20, InscricoesAbertas = true },
        new EventoInstitucional { Id = 4, Nome = "Hackathon",          Tipo = "Competição",Data = new DateTime(2025, 6,  1), Local = "Lab 1",        VagasDisponiveis = 100,InscricoesAbertas = true },
    };

    public List<EventoInstitucional> ObterDadosDoServidor()
    {
        Console.WriteLine("📡 Conectando ao servidor para obter eventos...\n");
        return eventosServidor;
    }

    /// Busca eventos por intervalo de data e vagas, e opcionalmente filtra inscrições abertas.
    public List<EventoInstitucional> BuscarEventos(
        List<EventoInstitucional> lista,
        DateTime dataInicio,
        DateTime dataFim,
        int vagasMin,
        int vagasMax,
        bool? apenasAbertos = null
    )
    {
        if (dataFim < dataInicio)
            throw new ArgumentException("Data final não pode ser anterior à inicial.");
        if (vagasMin < 0 || vagasMax < 0 || vagasMin > vagasMax)
            throw new ArgumentException("Intervalo de vagas inválido.");

        var query = lista.Where(ev =>
            ev.Data >= dataInicio &&
            ev.Data <= dataFim &&
            ev.VagasDisponiveis >= vagasMin &&
            ev.VagasDisponiveis <= vagasMax
        );

        if (apenasAbertos.HasValue)
            query = query.Where(ev => ev.InscricoesAbertas == apenasAbertos.Value);

        return query
            .OrderBy(ev => ev.Data)
            .ToList();
    }
}

public class Program
{
    public static void Main()
    {
        var servico = new ServicoEventos();
        var todosEventos = servico.ObterDadosDoServidor();

        try
        {
            // Leitura de parâmetros
            Console.Write("Data início (dd/MM/yyyy): ");
            var dataInicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Data fim    (dd/MM/yyyy): ");
            var dataFim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Vagas mínimas: ");
            int vagasMin = int.Parse(Console.ReadLine());

            Console.Write("Vagas máximas: ");
            int vagasMax = int.Parse(Console.ReadLine());

            Console.Write("Apenas inscrições abertas? (s/n): ");
            string resp = Console.ReadLine().Trim().ToLower();
            bool? apenasAbertos = resp == "s" ? true
                                  : resp == "n" ? false
                                  : (bool?)null;

            // Busca
            var resultados = servico.BuscarEventos(todosEventos, dataInicio, dataFim, vagasMin, vagasMax, apenasAbertos);

            // Saída
            Console.WriteLine("\n Eventos encontrados:");
            if (resultados.Count == 0)
            {
                Console.WriteLine("  Nenhum evento corresponde aos critérios.");
            }
            else
            {
                foreach (var ev in resultados)
                {
                    Console.WriteLine($@"
  • {ev.Nome} ({ev.Tipo})
     {ev.Data:dd/MM/yyyy} em {ev.Local}
     Vagas: {ev.VagasDisponiveis}
    {(ev.InscricoesAbertas ? " Inscrições Abertas" : " Inscrições Fechadas")}
");
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada em formato inválido. Verifique datas e números.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}

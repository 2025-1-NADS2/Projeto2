
using System;
using System.Collections.Generic;

namespace OrdenacaoEventos
{
    // Classe que representa um evento
    internal class Evento
    {
        public int ID { get; set; }      // Identificação do evento
        public string Nome { get; set; } // Nome do evento
        public DateTime Data { get; set; } // Data em que o evento ocorre
        public string Local { get; set; } // Local onde o evento será realizado

        // Construtor da classe Evento
        public Evento(int id, string nome, DateTime data, string local)
        {
            ID = id;
            Nome = nome;
            Data = data;
            Local = local;
        }

        // Método para verificar se um evento tem um ID maior que outro
        public bool Maior(Evento other)
        {
            return other != null && this.ID > other.ID;
        }

        // Método para exibir os detalhes do evento de forma organizada
        public override string ToString()
        {
            return $"ID: {ID}, Nome: {Nome}, Data: {Data:dd/MM/yyyy}, Local: {Local}";
        }
    }

    class Program
    {
        static void Main()
        {
            // Criamos uma lista de eventos (desordenada de propósito)
            List<Evento> eventos = new List<Evento>
            {
                new Evento(3, "Workshop de Fotografia", new DateTime(2025, 5, 5), "Sala 2"),
                new Evento(1, "Palestra de Tecnologia", new DateTime(2025, 3, 25), "Auditório"),
                new Evento(2, "Oficina de Pintura", new DateTime(2025, 4, 10), "Sala 1"),
                new Evento(4, "Concerto de Música", new DateTime(2025, 3, 30), "Teatro")
            };

            // Exibe a lista de eventos antes da ordenação
            Console.WriteLine("Lista de eventos antes da ordenação:");
            MostrarEventos(eventos);

            // Aplicamos a ordenação usando Bubble Sort
            BubbleSort(eventos);

            // Exibe a lista de eventos após a ordenação
            Console.WriteLine("\nLista de eventos após a ordenação:");
            MostrarEventos(eventos);
        }

        // Método para exibir os eventos na tela
        static void MostrarEventos(List<Evento> eventos)
        {
            // Itera sobre a lista de eventos e imprime no console
            foreach (var evento in eventos)
            {
                Console.WriteLine(evento);
            }
        }

        // Método de ordenação Bubble Sort (organiza os eventos pelo ID)
        static void BubbleSort(List<Evento> eventos)
        {
            int n = eventos.Count; // Número total de eventos na lista

            // Percorremos a lista várias vezes até que todos os elementos estejam ordenados
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Se o evento atual tiver um ID maior que o próximo, fazemos a troca
                    if (eventos[j].Maior(eventos[j + 1]))
                    {
                        // Troca os eventos de posição na lista
                        Evento temp = eventos[j];
                        eventos[j] = eventos[j + 1];
                        eventos[j + 1] = temp;
                    }
                }
            }
        }
    }
}

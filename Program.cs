using System;
using System.Collections.Generic;
using System.Linq;

// Interfaz para los jugadores
interface IJugador
{
    string Nombre { get; }
    string Posicion { get; }
    int Rendimiento { get; }
}

// Clase Jugador que implementa la interfaz IJugador
class Jugador : IJugador
{
    private string nombre;
    private string posicion;
    private int rendimiento;

    public Jugador(string nombre, string posicion, int rendimiento)
    {
        this.nombre = nombre;
        this.posicion = posicion;
        this.rendimiento = rendimiento;
    }

    public string Nombre => nombre;
    public string Posicion => posicion;
    public int Rendimiento => rendimiento;
}

// Clase Equipo
class Equipo
{
    private List<IJugador> jugadores = new List<IJugador>();

    public void AgregarJugador(IJugador jugador)
    {
        jugadores.Add(jugador);
    }

    public int ObtenerPuntajeTotal()
    {
        return jugadores.Sum(j => j.Rendimiento);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IJugador> jugadoresRegistrados = new List<IJugador>
        {
            new Jugador("Juan", "Base", 8),
            new Jugador("Pedro", "Escolta", 7),
            new Jugador("Luis", "Alero", 9),
            new Jugador("Ana", "Ala-pívot", 8),
            new Jugador("María", "Pívot", 7),
            new Jugador("Carlos", "Base", 6)
        };

        Equipo equipo1 = new Equipo();
        Equipo equipo2 = new Equipo();

        Random rnd = new Random();

        // Selección aleatoria de jugadores
        for (int i = 0; i < 3; i++)
        {
            int index = rnd.Next(jugadoresRegistrados.Count);
            equipo1.AgregarJugador(jugadoresRegistrados[index]);
            jugadoresRegistrados.RemoveAt(index);

            index = rnd.Next(jugadoresRegistrados.Count);
            equipo2.AgregarJugador(jugadoresRegistrados[index]);
            jugadoresRegistrados.RemoveAt(index);
        }

        // Determinar el ganador
        int puntajeEquipo1 = equipo1.ObtenerPuntajeTotal();
        int puntajeEquipo2 = equipo2.ObtenerPuntajeTotal();

        Console.WriteLine($"Puntaje Equipo 1: {puntajeEquipo1}");
        Console.WriteLine($"Puntaje Equipo 2: {puntajeEquipo2}");

        if (puntajeEquipo1 > puntajeEquipo2)
        {
            Console.WriteLine("¡El Equipo 1 es el ganador!");
        }
        else if (puntajeEquipo2 > puntajeEquipo1)
        {
            Console.WriteLine("¡El Equipo 2 es el ganador!");
        }
        else
        {
            Console.WriteLine("¡Es un empate!");
        }
    }
}

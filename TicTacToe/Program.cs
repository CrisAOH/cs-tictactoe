namespace TicTacToe
{
    internal class Program
    {
        //Arreglo para el tablero del juego
        static int[,] tablero = new int[3, 3];

        //Arreglo para los símbolos del tablero
        static char[] simbolo = { ' ', 'O', 'X' }; 

        static void Main(string[] args)
        {
            bool terminado = false;
            //DIBUJAR EL TABLERO INICIAL
            DibujarTablero();
            Console.WriteLine("Jugador 1 = O\nJugador 2 = X");

            do
            {
                PreguntarPosicion(1);

                DibujarTablero();

                terminado = ComprobarGanador();

                if (terminado == true)
                {
                    Console.WriteLine("El jugador 1 ha ganado.");
                }
                else
                {
                    terminado = ComprobarEmpate();
                    if (terminado == true)
                    {
                        Console.WriteLine("Esto es un empate.");
                    }
                    else
                    {
                        PreguntarPosicion(2);

                        DibujarTablero();

                        terminado = ComprobarGanador();

                        if (terminado == true)
                        {
                            Console.WriteLine("El jugador 2 ha ganado.");
                        }
                    }
                }
            }
            while (terminado == false);
        } //CIERRE DE MAIN

        static void DibujarTablero()
        {
            int fila = 0;
            int columna = 0;

            Console.WriteLine();
            Console.WriteLine("-------------");

            for (fila = 0; fila < 3; fila++)
            {
                Console.Write("|");
                for (columna = 0; columna < 3; columna++)
                {
                    Console.Write(" {0} |", simbolo[tablero[fila, columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }

        static void PreguntarPosicion(int jugador)
        {
            int fila, columna;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador_ {0}", jugador);

                do
                {
                    Console.Write("Selecciona la fila (1 a 3)");
                    fila = Convert.ToInt32(Console.ReadLine());
                }
                while (fila < 1 || fila > 3 );

                do
                {
                    Console.Write("Selecciona la columna (1 a 3)");
                    columna = Convert.ToInt32(Console.ReadLine());
                }
                while (columna < 1 || columna > 3);

                if (tablero[fila - 1, columna - 1] != 0)
                {
                    Console.WriteLine("Casilla ocupada.");
                }
            }
            while (tablero[fila - 1, columna - 1] != 0);

            tablero[fila - 1, columna - 1] = jugador;
        }

        static bool ComprobarGanador()
        {
            int fila = 0;
            int columna = 0;
            bool ticTacToe = false;

            for (fila = 0; fila < 3; fila++)
            {
                if (tablero[fila, 0] == tablero[fila, 1] && tablero[fila, 0] == tablero[fila, 2] && tablero[fila, 0] != 0)
                {
                    ticTacToe = true;
                }
            }

            for (columna = 0; columna < 3; columna++)
            {
                if (tablero[0, columna] == tablero[1, columna] && tablero[0, columna] == tablero[2, columna] && tablero[0, columna] != 0)
                {
                    ticTacToe = true;
                }
            }

            if (tablero[0, 0] == tablero[1, 1] && tablero[0, 0] == tablero[2, 2] && tablero[0, 0] != 0)
            {
                ticTacToe = true;
            }

            if (tablero[0, 2] == tablero[1, 1] && tablero[0, 2] == tablero[2, 0] && tablero[0, 2] != 0)
            {
                ticTacToe = true;
            }

            return ticTacToe;
        }

        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for (fila = 0; fila < 3; fila++)
            {
                for (columna = 0; columna < 3; columna++)
                {
                    if (tablero[fila, columna] == 0)
                    {
                        hayEspacio = true;
                    }
                }
            }

            return !hayEspacio;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Timers;

namespace CA3Tarea3
{
    class Juego
    {
        static string _menu = "\t--Juego de Agilidad numérica\nSeleccione una clasificación\n" +
            "1. Binario - Octal o Octal - Binario\n2. Binario - Hex o Hex - Binario\n3. Ver Notas\n4. No Jugar";
        static string _separator = "========================";
        //private static Timer aTimer2 = new System.Timers.Timer(5000);
        static List<String> binarios = new List<String>(new string[] 
        { "1010", "100", "101", "110", "110", "111", "1001", "1111", "111", "1101" });
        //static List<int> binariosints = new List<int>(new int[] { 
        //    1010, 100, 101, 110, 110, 111, 1001, 1111, 111, 1101 });
        static List<String> octales = new List<String>(new string[] 
        { "12", "2", "4", "10", "5", "7", "13", "21", "16", "30" });
        static List<String> hexadecimales = new List<String>(new string[] 
        { "9", "1A", "B", "C", "A", "7", "3", "5", "10", "0" });
        // default 10 sec
        static int tiempoparacontestar = 5000;
        static bool gano = false;
        static bool perdio1 ;
        static bool perdio2 ;

        static int opcion = 0;
        //Vars pro juego 
        static int juego1 = 9;
        static int juego2 = 0;
        static int currentLevel = 0;

        //public static void Main()
        //{
        //    while (opcion != 4)
        //    {
        //        Console.Clear();
        //        int tot = juego2 + juego1;
        //        if (juego1 + 1 >= 8 && juego1 + 1 >= 8)
        //        {
        //            Console.WriteLine("GANO EL JUEGO!!!");
        //            Console.WriteLine("Obtuvo suficientes puntos");
        //            //show_current_score();
        //            //Environment.Exit(0);
        //            Console.Clear();
        //        }
        //        Console.WriteLine(_menu);
        //        opcion = int.Parse(Console.ReadLine());
        //        switch (opcion)
        //        {
        //            case 1:
        //                {
        //                    if (juego1 < 10)                            
        //                        jugarBinOct_OctBin();                                                            
        //                    else
        //                    {
        //                        Console.WriteLine("No se puede jugar mas la opcion 1\nYa se llegó al maximo posible");
        //                        Console.ReadLine();
        //                    }
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    if (juego2 < 10)                            
        //                        jugarBinHex_HexBin();                            
        //                    else
        //                    {
        //                        Console.WriteLine("No se puede jugar mas la opcion 2\nYa se llegó al maximo posible");
        //                        Console.ReadLine();
        //                    }
        //                    break;
        //                }
        //            case 3:
        //                {
        //                    show_current_score();     
        //                    break;
        //                }
        //            #region
        //            case 4:
        //                {
        //                    Console.WriteLine("Desea salir S(any key) / N");
        //                    string decision = Console.ReadLine();
        //                    if (decision.Equals("N") || decision.Equals("n"))
        //                    {
        //                        opcion = 0;
        //                    }
        //                    break;
        //                }
        //            default:
        //                {
        //                    Console.WriteLine("Seleccione inválida..");
        //                    Console.ReadKey();
        //                    Console.Clear();
        //                    break;
        //                }
        //            #endregion
        //        }
        //    }
        //}


        static void jugarBinOct_OctBin()
        {
            currentLevel = 1;
            gano = false;

            Timer aTimer = new System.Timers.Timer(tiempoparacontestar);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
            perdio1 = false;
            string binary = "";
            int integer = 0;          
            Console.WriteLine("Tiene 10 segundos para contestar");
            Console.WriteLine("Cuanto es -{0}- Binario en Octal ", binarios[juego1]);
            integer = Convert.ToInt32(binarios[juego1], 2);
            do
            {
                Console.WriteLine("Escriba la respuesta.");
                binary = Console.ReadLine();
                //int a =  Convert.ToString(binary, 8);
                if (binary.Equals(Convert.ToString(integer, 8)))
                {
                    gano = true;
                    aTimer.Enabled = false;
                    aTimer.Dispose();
                }
                else if (perdio1)
                {
                    Console.WriteLine("Se agotó el tiempo!");
                    aTimer.Enabled = false;
                    aTimer.Dispose();
                    goto sal1;
                }

            } 
            while (!gano&&!perdio1);
            sal1:
            if (!perdio1 && gano)
            {
                aTimer.Enabled = false;
                aTimer.Dispose();
                Console.WriteLine("Ganó el nivel {0}\nVolviendo al Menú principal", juego1 + 1);
                juego1++;
                gano = false;
                Console.ReadLine();
            }
            else {
                aTimer.Enabled = false;
                aTimer.Dispose();
                Console.WriteLine("Perdió el nivel {0}\nVolviendo al Menú principal", juego1 + 1);
                gano = false;
                Console.ReadLine();
            }
        }

        static void jugarBinHex_HexBin()
        {
            //para saber en que metodo esta metido desde el timer
            currentLevel = 2;
            gano = false;

            Timer aTimer = new System.Timers.Timer(tiempoparacontestar);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
            perdio2 = false;
            string binary = "";
            int binaryint = 0;
            string integer = "";
            Console.WriteLine("Tiene 10 segundos para contestar");
            Console.WriteLine("Cuanto es -{0}- Binario en Hex ", binarios[juego2]);
            //Console.WriteLine("Cuanto es -{0}- Binario en Hex ", binarios[juego2]);
            binaryint = Convert.ToInt32(binarios[juego2], 2);
            do
            {
                Console.WriteLine("Escriba la respuesta.");
                binary = Console.ReadLine();
                string check = Convert.ToString(binaryint,16);
                //int a =  Convert.ToInt32(binary, 16);
                int errorCounter = Regex.Matches(binary, @"[a-zA-Z]").Count;
                //Check as strings
                //if (errorCounter!= 0)
                //{
                    if (check.ToLower().Equals(check.ToLower()))
                    {
                        gano = true;
                        aTimer.Enabled = false;
                        aTimer.Dispose();
                    }
                    else if (perdio2)
                    {
                        Console.WriteLine("Se agotó el tiempo!");
                        aTimer.Enabled = false;
                        aTimer.Dispose();
                        goto sal2;
                    }                    
                //}
                //Check as numbers
                //else
                //{
                //    if (check.ToLower().Equals(check.ToLower()))
                //    {
                //        gano = true;
                //        aTimer.Enabled = false;
                //        aTimer.Dispose();
                //    }
                //    else if (perdio2)
                //    {
                //        Console.WriteLine("Se agotó el tiempo!");
                //        aTimer.Enabled = false;
                //        aTimer.Dispose();
                //        goto sal2;
                //    } 
                //}

            }
            while (!gano && !perdio2);
        sal2:
            if (!perdio2 && gano)
            {
                aTimer.Enabled = false;
                aTimer.Dispose();
                Console.WriteLine("Ganó el nivel {0}\nVolviendo al Menú principal", juego2 + 1);
                juego2++;
                gano = false;
                Console.ReadLine();
            }
            else
            {
                aTimer.Enabled = false;
                aTimer.Dispose();
                Console.WriteLine("Perdió el nivel {0}\nVolviendo al Menú principal", juego2 + 1);
                gano = false;
                Console.ReadLine();
            }
        }

        static void show_current_score() {
            string printout = "";
            printout += "\nMostrando notas del Juego\n------------------------\n";
            printout += "En el nivel 1: " + (juego1 )+"\n";
            printout += "En el nivel 2: " + (juego2 )+"\n";
            printout += _separator + "\n";
            int tot = juego2 + juego1;
            printout += "TOTAL puntos : " + tot + "\n";
            printout += _separator + "\n";
            Console.WriteLine(printout);
            Console.ReadLine();
        }

        static void metodViejo()
        {
        Timer aTimer = new System.Timers.Timer(tiempoparacontestar);
            currentLevel = 2;

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
            string decide = "";
            do
            {
                if (!gano)
                {
                    Console.WriteLine("Respuesta incorrecta.");
                }
                Console.WriteLine("escriba una letra del abecedario.");
                decide = Console.ReadLine();
                if (decide.Equals("a") || decide.Equals("A"))
                {
                    gano = true;
                    aTimer.Enabled = false;
                    //aTimer2.Enabled = false;
                }
                if (decide.Equals("e") || decide.Equals("E"))
                {
                    gano = true;
                    aTimer.Enabled = true;
                    //aTimer2.Enabled = true;
                }

            } while (!decide.Equals("a") || !decide.Equals("A"));
            Console.WriteLine("Gano");
            Console.ReadLine();
        }

        // Specify what you want to happen when the Elapsed event is 
        // raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Console.Clear();
            if (gano)
            {   
                Console.WriteLine("***Ganó!!!***");                
            }
            else {
                if (currentLevel == 1)
                {
                    Console.WriteLine("Perdio!!! 1");
                    perdio1 = true;
                }
                else if (currentLevel == 2)
                {
                    Console.WriteLine("Perdio!!! 2");
                    perdio2 = true;
                }
                else
                    Console.WriteLine("Error algo salio mal");
                //default method
                //Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            }
        }

        static void metodobase()
        {
            Timer aTimer = new System.Timers.Timer(tiempoparacontestar);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
            string decide = "";

            do
            {
                if (!gano)
                {
                    Console.WriteLine("Aun no ha ganado .");
                }
                Console.WriteLine("escriba una letra del abecedario.");
                decide = Console.ReadLine();
                if (decide.Equals("a") || decide.Equals("A"))
                {
                    gano = true;
                    aTimer.Enabled = false;
                    //aTimer2.Enabled = false;
                }
                if (decide.Equals("e") || decide.Equals("E"))
                {
                    gano = true;
                    aTimer.Enabled = true;
                    //aTimer2.Enabled = true;
                }

            } while (!decide.Equals("a") || !decide.Equals("A"));
            Console.WriteLine("Gano");
            Console.ReadLine();
        }


    
}
}

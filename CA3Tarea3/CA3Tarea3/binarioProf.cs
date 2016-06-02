using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Text.RegularExpressions;

namespace CA3Tarea3
{
    class binarioProf
    {
        static int option = 0;
        //static void Main()
        //{
        //    bool salir = false;
        //    while (!salir)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Sistemas numéricos");
        //        Console.WriteLine("1. Binario");
        //        Console.WriteLine("2. Octal");
        //        Console.WriteLine("3. Decimal");
        //        Console.WriteLine("4. Hexadecimal");
        //        Console.WriteLine("5. Salir");
        //        Console.WriteLine("Seleccione una opción.");
        //        option = int.Parse(Console.ReadLine());
        //        switch (option)
        //        {
        //            case 1:
        //                {
        //                    BinaryConversion();
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    OctalConversion();
        //                    break;
        //                }
        //            case 3:
        //                {
        //                    DecimalConversion();
        //                    break;
        //                }
        //            case 4:
        //                {
        //                    HexConversion();
        //                    break;
        //                }
        //            case 5:
        //                {
        //                    Console.WriteLine("Salir seleccionado");
        //                    Console.ReadKey();
        //                    salir = true;
        //                    break;
        //                }
        //            default:
        //                {
        //                    break;
        //                }
        //        }
        //    }
        //}

        private static void DecimalConversion()
        {
            int o = 0;
            int integer = 0;
            string dec = "";
            Console.Clear();
            Console.WriteLine("Sistemas numéricos");
            Console.WriteLine("Conversiones Decimal");
            Console.WriteLine("Seleccione la opción a convertir");
            Console.WriteLine("1. Binario");
            Console.WriteLine("2. Octal");
            Console.WriteLine("3. Hexadecimal");
            o = int.Parse(Console.ReadLine());
        retry:
            Console.WriteLine("Ingrese el número Decimal");
            dec = Console.ReadLine();

            int errorCounter = Regex.Matches(dec, @"[a-zA-Z]").Count;
            if (errorCounter !=0)
            {
                Console.WriteLine("Decimal no puede llevar letras!");
                goto retry;
            }

            if (o == 1)
            {
                integer = Convert.ToInt32(dec, 10);
                Console.WriteLine("Binario: " + Convert.ToString(integer, 2));
            }
            else if (o == 2)
            {
                integer = Convert.ToInt32(dec, 10);
                Console.WriteLine("Octal: " + Convert.ToString(integer, 8));
            }
            else if (o == 3)
            {
                integer = Convert.ToInt32(dec, 10);
                Console.WriteLine("Hexadecimal: " + Convert.ToString(integer, 10));
            }
            Console.ReadLine();
        }

        private static void HexConversion()
        {
            int o = 0;
            int integer = 0;
            string hex = "";
            Console.Clear();
            Console.WriteLine("Sistemas numéricos");
            Console.WriteLine("Conversiones Hexadecimal");
            Console.WriteLine("Seleccione la opción a convertir");
            Console.WriteLine("1. Binario");
            Console.WriteLine("2. Octal");
            Console.WriteLine("3. Decimal");
            o = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el número Hexadecimal");
            hex = Console.ReadLine();

            if (o == 1)
            {
                integer = Convert.ToInt32(hex, 16);
                Console.WriteLine("Binario: " + Convert.ToString(integer, 2));
            }
            else if (o == 2)
            {
                integer = Convert.ToInt32(hex, 16);
                Console.WriteLine("Octal: " + Convert.ToString(integer, 8));
            }
            else if (o == 3)
            {
                integer = Convert.ToInt32(hex, 16);
                Console.WriteLine("Decimal: " + Convert.ToString(integer, 10));
            }
            Console.ReadLine();
        }

        private static void OctalConversion()
        {
            int o = 0;
            int integer = 0;
            string octal = "";            
            Console.Clear();
            Console.WriteLine("Sistemas numéricos");
            Console.WriteLine("Conversiones Octal");
            Console.WriteLine("Seleccione la opción a convertir");
            Console.WriteLine("1. Binario");
            Console.WriteLine("2. Decimal");
            Console.WriteLine("3. Hexadecimal");
            o = int.Parse(Console.ReadLine());
        reenter:
            Console.WriteLine("Ingrese el número octal");
            octal = Console.ReadLine();

            int errorCounter = Regex.Matches(octal, @"[a-zA-Z]").Count;
            if (errorCounter != 0)
            {
                Console.WriteLine("Octal no puede llevar letras!");
                goto reenter;
            }

            if (o == 1)
            {
                integer = Convert.ToInt32(octal, 8);
                Console.WriteLine("Binario: " + Convert.ToString(integer, 2));
            }
            else if (o == 2)
            {
                integer = Convert.ToInt32(octal, 8);
                Console.WriteLine("Decimal: " + Convert.ToString(integer, 10));
            }
            else if (o == 3)
            {
                integer = Convert.ToInt32(octal, 8);
                Console.WriteLine("Hexadecimal: " + Convert.ToString(integer, 16));
            }
            Console.ReadLine();
        }

        static void BinaryConversion()
        {
            int o = 0;
            int integer = 0;
            string binary = "";
            bool nobinary = false;
            Console.Clear();
            Console.WriteLine("Sistemas numéricos");
            Console.WriteLine("Conversiones Binarias");
            Console.WriteLine("Seleccione la opción a convertir");
            Console.WriteLine("1. Octal");
            Console.WriteLine("2. Decimal");
            Console.WriteLine("3. Hexadecimal");
            o = int.Parse(Console.ReadLine());
        back:
            Console.WriteLine("Ingrese el número binario");
            binary = Console.ReadLine();
            foreach (char pos in binary)
            {
                integer = (int)Char.GetNumericValue(pos);
                if (integer > 1)
                {
                    nobinary = true;
                }
            }
            if (nobinary)
            {
                Console.WriteLine("Número binario inválido");
                nobinary = false;
                goto back;
            }

            if (o == 1)
            {
                integer = Convert.ToInt32(binary, 2);
                Console.WriteLine("Octal: " + Convert.ToString(integer, 8));
            }
            else if (o == 2)
            {
                integer = Convert.ToInt32(binary, 2);
                Console.WriteLine("Decimal: " + Convert.ToString(integer, 10));
            }
            else if (o == 3)
            {
                integer = Convert.ToInt32(binary, 2);
                string check = Convert.ToString(integer, 16);
                Console.WriteLine("Hexadecimal: " + Convert.ToString(integer, 16));
            }
            Console.ReadLine();
        }
        //END BINARY CONVERSION

    }
}
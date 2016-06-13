using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3Tarea3
{
    class Program
    {
        static string _menu = "\n1. Ingreso de estudiantes\n2. Modificación de estudiantes\n3. Borrado de estudiantes\n4. Búsqueda de estudiantes por id\n5. Listado de estudiantes\n6. Informe clasificación de estudiantes\n7. Salir";
        static string _separator = "============================================";
        static int max_studiantes = 0;
        static int opcion = 0;
        static List<Person> Personas = new List<Person>();
        static List<String> names = new List<String>(new string[] 
        { "Mark", "Jollene", "Sara", "Carl", "Jan","Ana","Ivan","Joe", "Carlos" });
        static List<String> sex = new List<String>(new string[]
        { "M",      "F",    "F",    "M",     "M", "F",  "M",      "M", "M"});
        static List<int> ages = new List<int>(new int[] {18,90,42,15,26,64,23,45,53});


        struct Person
        {
            public int id;
            public string name;
            public string sex;
            public int age;
        };

        /// <summary>
        /// //MAIN
        /// </summary>

        //static void Main()
        //{
        //reiniciar:
        //    Console.WriteLine("Ingrese el límite máximo de estudiantes");
        //    max_studiantes = int.Parse(Console.ReadLine());
        //    //max_studiantes = 9;
        //    if (max_studiantes < 6)
        //    {
        //        Console.WriteLine("Error");
        //        Console.ReadLine();
        //        goto reiniciar;
        //    }
        //    Console.WriteLine("Limite de Estudiantes es: {0}", max_studiantes);
        //    Console.ReadKey();
        //    while (opcion != 7)
        //    {
        //        Console.Clear();
        //        Console.WriteLine(_menu);
        //        opcion = int.Parse(Console.ReadLine());
        //        switch (opcion)
        //        {
        //            case 1:
        //                {
        //                    AgregarEstudiante();
        //                    Console.ReadKey();
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    Console.WriteLine("Ingrese el ID del estudiante a modificar: ");
        //                    int idsend = int.Parse(Console.ReadLine());
        //                    ModifEstudiante(idsend);
        //                    //printArray();
        //                    break;
        //                }
        //            case 3:
        //                {
        //                    Console.WriteLine("Ingrese el ID a eliminar: ");
        //                    int idsend = int.Parse(Console.ReadLine());
        //                    EliminarEstudiante(idsend);
        //                    break;
        //                }
        //            case 4:
        //                {
        //                    Console.WriteLine("Ingrese el ID a buscar: ");
        //                    int idsend = int.Parse(Console.ReadLine());
        //                    BuscarEstudiante(idsend);
        //                    break;
        //                }
        //            case 5:
        //                {
        //                    ListarEstudiantes();
        //                    break;
        //                }
        //            case 6:
        //                {
        //                    ListarClasificativo();
        //                    break;
        //                }
        //            case 7:
        //                {
        //                    Console.WriteLine("Desea salir S / N");
        //                    string decision = Console.ReadLine();
        //                    if (decision.Equals("N") || decision.Equals("n"))
        //                    {
        //                        opcion = 0;
        //                    }
        //                    break;
        //                }
        //            case 8:
        //                {
        //                    fillWithDummyData();
        //                    //opcion = 0;
        //                    Console.ReadKey();
        //                    break;
        //                }
        //            default:
        //                {
        //                    Console.WriteLine("Seleccione inválida..");
        //                    Console.ReadKey();
        //                    Console.Clear();
        //                    break;
        //                }
        //        }
        //    }
        //}

        private static void fillWithDummyData()
        {
            Console.WriteLine("Modo demo lista de estudiantes borrada y cargada con info default");
            Personas.Clear();
            for (int i = 0; i < 6; i++)
            {
                Person x = new Person();
                x.id = i + 1;
                x.name =    names[i];
                x.sex =     sex[i];
                x.age =     ages[i];
                Personas.Add(x);
            } 
        }
        //END MAIN

        //Method for debugging
        static void printArray() {
            if (Personas.Count==0)
            {
                Console.WriteLine("Lista Vacia no hay personas agregadas " + Personas.Count);
            }
            else { 
                foreach (var item in Personas)
                {
                    Console.Write(item.id + "  " + item.name + "  " + item.sex + "  " + item.age + "\n");
                }
                Console.WriteLine("Total personas agregadas " + Personas.Count);                
            }                
        }

        //ADD
        static void AgregarEstudiante(){
            Person pAdd = new Person();
            if (Personas.Count < max_studiantes)
            {
                Console.WriteLine("Ingrese 0 para salir: ");
                Console.WriteLine("Ingrese el id: ");
                int idsalir = int.Parse(Console.ReadLine());
                if (idsalir !=0)
                {
                    pAdd.id = idsalir;
                    Console.WriteLine("Ingrese el nombre: ");
                    pAdd.name = Console.ReadLine();
                    Console.WriteLine("Ingrese el sexo M o F : ");
                    pAdd.sex = Console.ReadLine();
                    Console.WriteLine("Ingrese la edad: ");
                    pAdd.age = int.Parse(Console.ReadLine());
                    Personas.Add(pAdd);
                    Console.WriteLine("Persona Agregada");
                }
            }
            else
            {
                Console.WriteLine("No se puede agregar, limite de estudiantes es "+ max_studiantes);
            }
            //printArray();
        }

        //SEARCH
        static void BuscarEstudiante(int idtoSearch)
        {
            bool encontrado = false;
            string datos = "";
            if (Personas.Count == 0)
            {
                Console.WriteLine("Lista Vacia no hay estudiantes agregadas para buscar ");
            }
            else
            {
                foreach (var item in Personas)
                {
                    if (item.id == idtoSearch)
                    {
                        datos = "ID: \t" + item.id + "\n"+
                                "Nombre: " + item.name + "\n"+
                                "Sexo: \t" + item.sex + "\n" +
                                "Edad: \t" + item.age + "\n";
                        encontrado = true;
                    }

                }
                if (encontrado)
                {
                    Console.WriteLine("\nPersona encontrada id: # " + idtoSearch + "\n");
                    Console.WriteLine(datos);
                }
                else
                {
                    Console.WriteLine(_separator+"\nPersona NO encontrada con el id: # " + idtoSearch + "\n");
                }
                Console.WriteLine(_separator+"\n\tFin de Informe");
                Console.ReadKey();                
            }

            //printArray();
        }


        //DELETE
        static void EliminarEstudiante(int idtoDelete)
        {
            bool encontrado = false;

            int cont = 0;
            if (Personas.Count == 0)
            {
                Console.WriteLine("Lista Vacia no hay estudiantes agregadas para eliminar ");
            }
            else
            {
                foreach (var item in Personas)
                {
                    if (item.id == idtoDelete)
                    {
                        encontrado = true;                        
                    }
                    if (encontrado == false)
                    {
                        cont++;                        
                    }

                }
                if (encontrado)
                {
                    Console.WriteLine("\nPersona encontrada id: # " + idtoDelete + "\n");
                    Personas.RemoveAt(cont);
                }
                else
                {
                    Console.WriteLine(_separator + "\nPersona NO encontrada con el id: # " + idtoDelete + "\n");
                }
                Console.WriteLine(_separator + "\n\tFin de Informe");
                Console.ReadKey();
            }

            //printArray();
        }

        //MODIFY
        static void ModifEstudiante(int idtoDelete)
        {
            bool encontrado = false;
            Person pAdd = new Person();
            Person pNew = new Person();
            int cont = 0;
            if (Personas.Count == 0)
            {
                Console.WriteLine("Lista Vacia no hay estudiantes agregadas para modificar ");
            }
            else
            {
                foreach (var item in Personas)
                {
                    if (item.id == idtoDelete)
                    {
                        pAdd.id = item.id;
                        pAdd.name = item.name;
                        pAdd.sex = item.sex;
                        pAdd.age = item.age;
                        encontrado = true;
                    }
                    if (encontrado == false)
                    {
                        cont++;
                    }

                }
                if (encontrado)
                {
                    Console.WriteLine("\nPersona encontrada id: # " + idtoDelete + "\n");
                    //Borra la persona encontrada
                    Personas.RemoveAt(cont);
                    //rellena una nueva persona con nueva info y la agrega
                    Console.WriteLine("Ingrese el nuevo id: ");
                    int idsalir = int.Parse(Console.ReadLine());
                    pNew.id = idsalir;
                    Console.WriteLine("Ingrese el nuevo nombre: ");
                    pNew.name = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo sexo M o F : ");
                    pNew.sex = Console.ReadLine();
                    Console.WriteLine("Ingrese la nueva edad: ");
                    pNew.age = int.Parse(Console.ReadLine());
                    Personas.Add(pNew);
                    Console.WriteLine("Persona Modificada");
                    
                }
                else
                {
                    Console.WriteLine(_separator + "\nPersona NO encontrada con el id: # " + idtoDelete + "\n");
                }
                Console.WriteLine(_separator + "\n\tFin de Informe");
                Console.ReadKey();
            }

            //printArray();
        }
       
        //MODIFY deprecated
        static void ModificarEstudiante(int idtoSearch)
        {
            bool encontrado = false;
            string datos = "";
            if (Personas.Count == 0)
            {
                Console.WriteLine("Lista Vacia no hay estudiantes agregadas para modificar ");
            }
            else
            {
                foreach (var item in Personas)
                {
                    if (item.id == idtoSearch)
                    {
                        datos = "ID: \t" + item.id + "\n" +
                                "Nombre: " + item.name + "\n" +
                                "Sexo: \t" + item.sex + "\n" +
                                "Edad: \t" + item.age + "\n";
                        encontrado = true;
                    }

                }
                if (encontrado)
                {
                    Console.WriteLine("\nPersona encontrada id: # " + idtoSearch + "\n");
                    Console.WriteLine(datos);
                }
                else
                {
                    Console.WriteLine(_separator + "\nPersona NO encontrada con el id: # " + idtoSearch + "\n");
                }
                Console.WriteLine(_separator + "\n\tFin de Informe");
                Console.ReadKey();
            }

            //printArray();
        }

        static void ListarEstudiantes()
        {
            int cont = 1;
            if (Personas.Count == 0)
            {
                Console.WriteLine("Lista Vacia no hay estudiantes agregadas " + Personas.Count);
            }
            else
            {
                Console.WriteLine(_separator + "\n\tListado Estudiantil\n" + _separator + "\nUniversidad UH\n");
                Console.WriteLine("Reg\tCod\tNombre\tSexo\tEdad");
                foreach (var item in Personas)
                {
                    if (item.name.Length<8)
                    {
                        Console.Write(cont + "\t" + item.id + "\t" + item.name + "\t" + item.sex + "\t" + item.age + "\n");
                    }
                    else
                        Console.Write(cont + "\t" + item.id + "\t" + item.name.Substring(0,6) + ".\t" + item.sex + "\t" + item.age + "\n");                        
                    cont++;
                }
                Console.WriteLine("\nTotal personas listadas " + Personas.Count);
                Console.WriteLine(_separator+"\n\tFin de Informe");
                Console.ReadKey();                
            }
        }

        static void ListarClasificativo()
        {
            int cont = 1;
            int cHombres = 0, cMujeres = 0;
            int cMenores = 0, cJovenes = 0, cAdultos = 0;
            if (Personas.Count == 0)
            {
                Console.WriteLine("Lista Vacia no hay estudiantes agregadas " + Personas.Count);
            }
            else
            {
                //­18 = menores de edad, 19­-29 = jovenes +30 adultos                
                Console.WriteLine(_separator + "\n\tInforme Clasificación Estudiantil UH\n" + _separator);
                Console.WriteLine("Clasificación por edad\t||   Clasificación por Género\n-----------------------------------------------------");
                foreach (var item in Personas)
                {
                    //Contador Sexo
                    if (item.sex.Equals("m") || item.sex.Equals("M"))                    
                        cHombres++;                    
                    else if (item.sex.Equals("f") || item.sex.Equals("F"))
                        cMujeres++;
                    //Contador Edad
                    if (item.age < 18)
                        cMenores++;
                    else if (item.age >= 18 && item.age <= 29)
                        cJovenes++;
                    else if (item.age >= 30)
                        cAdultos++;
                    cont++;
                }
                Console.WriteLine("Menores de edad {0}\t|| Hombres {1}\n"+
                                  "\tJovenes {2}\t|| Mujeres {3}\n"+
                                  "\tAdultos {4}"
                    ,cMenores,cHombres,cJovenes,cMujeres,cAdultos);
                Console.WriteLine(_separator + "\n\tFin de Informe");
                Console.WriteLine("\nTotal personas listadas " + Personas.Count);
                Console.ReadKey();
            }
        }

    }
}

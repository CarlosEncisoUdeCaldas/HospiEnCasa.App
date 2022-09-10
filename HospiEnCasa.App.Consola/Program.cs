using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        //creamos un atributo o campo en la clase Program llamado _repoPaciente
        private static IRepositorioPaciente
            _repoPaciente =
                new RepositorioPaciente(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            bool control = true;
            while (control)
            {
                System.Console.WriteLine();
                System
                    .Console
                    .WriteLine("#### Bienvenido al programa Hospital en Casa Grupo 07 ###");
                System
                    .Console
                    .WriteLine("              #### CRUD Pacientes ####                   ");
                System.Console.WriteLine();
                System.Console.WriteLine("1. Adicionar Paciente");
                System.Console.WriteLine("2. Borrar Paciente");
                System.Console.WriteLine("3. Asignar Medico a Paciente");
                System.Console.WriteLine("4. Salir");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AddPaciente();
                        break;
                    case 2:
                        System
                            .Console
                            .WriteLine("metodo para borrar un paciente");

                             BorrarPaciente(3);
                        break;
                    case 3:
                        System
                            .Console
                            .WriteLine("Metodo para asignar un medico a un paciente");

                        //AsignarMedico();
                        break;
                    case 4:
                        control = false;
                        System
                            .Console
                            .WriteLine("Gracias por usar la aplicacion Hospital en casa Grupo 07");
                        System.Console.WriteLine();
                        break;
                    default:
                        System
                            .Console
                            .WriteLine("Opcion Correcta, digite nuevamente");
                        break;
                }

                // AddPaciente();
                // BuscarPaciente();
                // AsignarMedico();
            }
        }

        //vamos a declarar los metodos de la clase Program para

        // adicionar y buscar paciente y asignar un medico a un paciente
        private static void AddPaciente()
        {
            var paciente =
                new Paciente {
                    Nombre = "Liz",
                    Apellidos = "Enciso",
                    NumeroTelefono = "987654321",
                    Genero = Genero.Femenino,
                    Direccion = "Las Palmeras",
                    Longitud = 5.0006F,
                    Latitud = 75.000123F,
                    Ciudad = "Monteria",
                    FechaNacimiento = new DateTime(2017, 10, 02)
                };

            _repoPaciente.AddPaciente (paciente);
            System
                .Console
                .WriteLine($"El paciente {paciente.Nombre} {paciente.Apellidos} ha sido ingresado con éxito a la BD");
        }

        //borrar paciente
        private static void BorrarPaciente(int idPaciente)
        {
            _repoPaciente.DeletePaciente(idPaciente);
            System.Console.WriteLine("Paciente eliminado con exito");
        }
    }
}

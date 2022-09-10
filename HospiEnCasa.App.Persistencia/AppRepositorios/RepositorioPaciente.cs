
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;


namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly AppContext _appContext;

        //declaracion del constructor
        public RepositorioPaciente(AppContext appContext)
        {
            _appContext = appContext;
        }

        //metodos heredados de la interfaz IRepositorioPaciente
        //que se deben implementar

        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;
        }

        //Metodo para eliminar pacientes
        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if(pacienteEncontrado != null)
            {
                _appContext.Pacientes.Remove(pacienteEncontrado);
                _appContext.SaveChanges();   
            }else{
                return;
            }
        }

        //este metodo devuelve todos los pacientes
        // es lo mismo que decir
        //public IEnumerable<Paciente> GetAllPaciente() {  return _appContext.Pacientes }
        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return _appContext.Pacientes;
        }

        //metodo para obtener un solo paciente de la BD
        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
        {
            return _appContext.Pacientes.FirstOrDefault( p => p.Id == idPaciente);
        }

        //Metodo para actualizar los datos de un paciente
        //esto es lo mismo que declarar
        // public Paciente UpdatePaciente(Paciente paciente) { //codigo aqui... }

        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault( p => p.Id == paciente.Id);
            if (pacienteEncontrado != null)
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.Familiar = paciente.Familiar;
                pacienteEncontrado.Enfermera = paciente.Enfermera;
                pacienteEncontrado.Medico = paciente.Medico;
                pacienteEncontrado.Historia = paciente.Historia;
                _appContext.SaveChanges();
            }
            return pacienteEncontrado;
        }


        //metodo para asignar un medico a un paciente
        //esto es lo mismo que definir
        //public Medico AsignarMedico() { //code aqui... }
        Medico IRepositorioPaciente.AsignarMedico(int idPaciente, int idMedico)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault( p => p.Id == idPaciente);
            
            //el metodo entrará a este condicional solo si encuentra una coincidencia en Id
            //es decir, el paciente existe en la base de datos
            if (pacienteEncontrado != null)
            {
                var medicoEncontrado = _appContext.Medicos.FirstOrDefault( m => m.Id == idMedico);
                if (medicoEncontrado != null)
                {
                    pacienteEncontrado.Medico = medicoEncontrado;
                    _appContext.SaveChanges();
                }
                return medicoEncontrado;
            }
            
            //sino encuentra una coincidencia con un id de paciente, regresa null
            return null;
        }
    }
}
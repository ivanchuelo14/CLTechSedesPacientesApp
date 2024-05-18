using CLTechSedesPacientesApp.Data;
using CLTechSedesPacientesApp.Data.Repository;
using CLTechSedesPacientesApp.Domain;
using CLTechSedesPacientesApp.Infraestructure.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTechSedesPacientesApp.Applicattion.Services
{
    public class SedeService : ISedeService
    {
        private readonly IRespository<Lab63Sedes> _lab61SedesRepository;
        private readonly AplicationDbContext _DbContext;

        public SedeService(IRespository<Lab63Sedes> lab61SedesRepository, AplicationDbContext dbContext)
        {
            _lab61SedesRepository = lab61SedesRepository;
            _DbContext = dbContext;
        }


        public List<string> GetAllSedesEnterprise(int keySede)
        {
            try
            {
                if (keySede > 0)
                {
                    var result = _DbContext.SpLab63Model.FromSqlRaw("EXEC Lab63_GetByLab62C1Sedes @Lab62C1", new SqlParameter("@Lab62C1", keySede)).ToList();
                    if (result != null && result.Count > 0)
                    {
                        //var resultadosReal = result.Select(x => new ReporteAuna2023
                        //{
                        //    DNI_Paciente = x.DNI_Paciente,
                        //    Estado_Laboratorio = x.Estado_Laboratorio,
                        //    Nombre_Examen = x.Nombre_Examen,
                        //    Fecha_Orden = x.Fecha_Orden,
                        //    Nombre_Apellido = x.Nombre_Apellido,
                        //    Orden = x.Orden,
                        //    Peticion = x.Peticion,
                        //    Procedencia = x.Procedencia,
                        //    Resultado = x.Resultado
                        //}).ToList();

                        //return resultadosReal;
                    }
                }
                else
                {
                    //Error de llave 
                }
            }
            catch (Exception ex)
            {
                //Loggear esta parte
            }

            return null;
        }
    }
}

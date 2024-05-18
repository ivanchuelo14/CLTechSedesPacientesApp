using CLTechSedesPacientesApp.Data;
using CLTechSedesPacientesApp.Data.Repository;
using CLTechSedesPacientesApp.Domain;
using CLTechSedesPacientesApp.Infraestructure.Configuration;
using CLTechSedesPacientesApp.Infraestructure.Util;
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
        private readonly IValidationDictionary _validationDictionary;
        private readonly AplicationDbContext _DbContext;

        public SedeService(IRespository<Lab63Sedes> lab61SedesRepository, AplicationDbContext dbContext, IValidationDictionary validationDictionary)
        {
            _lab61SedesRepository = lab61SedesRepository;
            _DbContext = dbContext;
            _validationDictionary = validationDictionary;
        }


        public List<Lab63Sedes> GetSedesActivasEnterprise(int keySede)
        {
            var sedesNew = new List<Lab63Sedes>();
            try
            {
                if (keySede > 0)
                {
                    var result = _DbContext.SpLab63Model.FromSqlRaw("EXEC Lab63_GetByLab62C1Sedes @Lab62C1", new SqlParameter("@Lab62C1", keySede)).ToList();
                    if (result != null && result.Count > 0)
                    {
                        sedesNew = result.Select(x => new Lab63Sedes
                        {
                            IdEnterprise = x.Id.ToString(),
                            Codigo = x.Codigo,
                            FechaCreacion = x.FechaRegistro,
                            Nombre = x.NombreSede
                        }).ToList();
                        //_lab61SedesRepository.Create(sedesNew);
                    }
                }
                else
                    _validationDictionary.AddError("Servicio", "Error al consultar las sedes en enterprise");
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ExceptionHelper.GetCurrentMethod());
                _validationDictionary.AddError("Servicio", "Error al consultar las sedes en enterprise");
            }
            return sedesNew;
        }

        public bool GuardarSedes(List<Lab63Sedes> lab63Sedes)
        {
            try
            {
                foreach (var item in lab63Sedes)
                {
                    var getParticipacion = _lab61SedesRepository.GetByIdM(item.Id);
                    if (getParticipacion != null && getParticipacion.Id.Equals(item.Id))
                        _lab61SedesRepository.Update(item);
                    else
                        _lab61SedesRepository.Create(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                _validationDictionary.AddError("Servicio", "Error al guardar las sedes de enterprise");
                //_logger.LogError(ex, ExceptionHelper.GetCurrentMethod());
                return false;
            }
        }

        public List<Lab63Sedes> ValidateSedesEnterpriseNewTbl(List<Lab63Sedes> lab63Sedes)
        {
            var sedesNow = _lab61SedesRepository.GetAll().ToList();
            if (sedesNow != null && sedesNow.Count > 0)
            {
                var sedesNotInSecondList = lab63Sedes.Where(l => !sedesNow.Any(s => s.IdEnterprise == l.IdEnterprise)).ToList();
                if (sedesNotInSecondList != null && sedesNotInSecondList.Count > 0)
                {
                    var result = GuardarSedes(sedesNotInSecondList);
                    if (result)
                        sedesNow = _lab61SedesRepository.GetAll().ToList();
                }
            }
            else
            {
                var result = GuardarSedes(lab63Sedes);
                if (result)
                    sedesNow = _lab61SedesRepository.GetAll().ToList();
            }
            return sedesNow;
        }

        public Lab63Sedes GetSedeById(int Id)
        {
            return _lab61SedesRepository.GetByIdM(Id);
        }
    }
}

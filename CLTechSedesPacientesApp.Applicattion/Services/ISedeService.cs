using CLTechSedesPacientesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTechSedesPacientesApp.Applicattion.Services
{
    public interface ISedeService
    {
        Lab63Sedes GetSedeById(int Id);
        public List<Lab63Sedes> GetSedesActivasEnterprise(int keySede);
        public List<Lab63Sedes> ValidateSedesEnterpriseNewTbl(List<Lab63Sedes> lab63Sedes);
        bool GuardarSedes(List<Lab63Sedes> lab63Sedes);

    }
}

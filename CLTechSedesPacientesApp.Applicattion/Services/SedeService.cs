using CLTechSedesPacientesApp.Data.Repository;
using CLTechSedesPacientesApp.Domain;
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

        public SedeService(IRespository<Lab63Sedes> lab61SedesRepository)
        {
            _lab61SedesRepository = lab61SedesRepository;
        }

        public List<string> GetAllSedesEnterprise()
        {
            return null;
        }
    }
}

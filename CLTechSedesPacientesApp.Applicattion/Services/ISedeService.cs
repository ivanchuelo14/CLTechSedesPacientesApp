using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTechSedesPacientesApp.Applicattion.Services
{
    public interface ISedeService
    {
        public List<string> GetAllSedesEnterprise(int keySede);

    }
}

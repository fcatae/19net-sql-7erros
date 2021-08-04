using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho
{
    public interface ILogRepository
    {

        int TotalRegistros();
        void InserirLog(string campo);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE.Core.Domain;

namespace TE.Core.Services
{
    internal interface ISinistreService:IService<Sinistre>
    {
        double pourcentage(TypeAssurance ta);
        double salaireexpert(DateTime date);
        int nombreex(Assurance assurance);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE.Core.Domain;
using TE.Core.Interfaces;

namespace TE.Core.Services
{
    internal class SinistreSerice : Service<Sinistre>, ISinistreService
    {
        public SinistreSerice(IUnitOfWork uow) : base(uow)
        {
        }

        public int nombreex(Assurance assurance)
        {
            return GetAll()
                .Where(h=>h.MyAssurance==assurance)
                .Select(j=>j.Expertises)
                .Count();
        }

        public double pourcentage(TypeAssurance ta)
        {
            int a= GetAll()
                .Where(h => h.MyAssurance.Type == ta)
                .Select(k=>k.MyAssurance)
                .Count();
            return (GetAll()
                .Select(k => k.MyAssurance)
                .Count())/a;
        }

        public double salaireexpert(DateTime date)
        {
            return GetAll()
                .Where(jk=>jk.Expertises
                .Any(k=>k.DateExpertise==date))
                .Select(k=>k.Expertises)
                .Count();
        }
    }
}

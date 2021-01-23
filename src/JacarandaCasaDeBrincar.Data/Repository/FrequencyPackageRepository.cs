using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class FrequencyPackageRepository : Repository<FrequencyPackage>, IFrequencyPackageRepository
    {
        public FrequencyPackageRepository(JacarandaDbContext context) : base(context) { }
}
}

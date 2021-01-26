using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class FoodRestrictionRepository : Repository<FoodRestriction>, IFoodRestrictionRepository
    {
        public FoodRestrictionRepository(JacarandaDbContext context) : base(context) { }
    }
}

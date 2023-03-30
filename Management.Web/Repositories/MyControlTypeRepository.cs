using Management.Web.Contracts;
using Management.Web.Data;

namespace Management.Web.Repositories
{
    public class MyControlTypeRepository : GenericRepository<MyControlType>, IControlTypeRepository
    {
        public MyControlTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

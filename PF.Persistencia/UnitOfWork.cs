using PF.Persistencia.Repository;

namespace PF.Persistencia
{
    public class UnitOfWork
    {
        private FamilyRepository _familyRepository;
        private IFinalProjectContext _context;

        public UnitOfWork(IFinalProjectContext context)
        {
            _context = context;
        }

        public FamilyRepository FamilyRepository
        {
            get{ return _familyRepository == null ? new FamilyRepository(_context): _familyRepository; }
        }
    }
}
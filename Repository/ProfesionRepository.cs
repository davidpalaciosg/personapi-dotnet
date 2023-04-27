using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interface;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public class ProfesionRepository : IProfesionRepository
    {
        //Variable to hold de PersonaBDContext instance
        private readonly PersonaDbContext _context;

        //Constructors
        public ProfesionRepository()
        {
            _context = new PersonaDbContext();
        }
        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Profesion profesion = _context.Profesions.Find(id);
            if(profesion!=null)
            {
                _context.Profesions.Remove(profesion);
            }
        }

        public IEnumerable<Profesion> GetAll()
        {
            return _context.Profesions.ToList();
        }

        public Profesion GetByID(int id)
        {
            return _context.Profesions.Find(id);
        }

        public void Insert(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Profesion profesion)
        {
            _context.Entry(profesion).State=EntityState.Modified;
        }
    }
}

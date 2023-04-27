using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interface;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public class EstudioRepository : IEstudioRepository
    {
        //Variable to hold de PersonaBDContext instance
        private readonly PersonaDbContext _context;

        //Constructors
        public EstudioRepository()
        {
            _context = new PersonaDbContext();
        }
        public EstudioRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public void Delete(int idProf, int ccPer)
        {
           Estudio estudio = _context.Estudios.Find(idProf, ccPer);
            if(estudio!=null)
            {
                _context.Estudios.Remove(estudio);
            }
        }

        public IEnumerable<Estudio> GetAll()
        {
            return _context.Estudios.ToList();
        }

        public Estudio GetByKeys(int idProf, int ccPer)
        {
            return _context.Estudios.Find(idProf, ccPer);
        }

        public void Insert(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Estudio estudio)
        {
            _context.Entry(estudio).State=EntityState.Modified;
        }
    }
}

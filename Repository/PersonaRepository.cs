using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interface;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        //Variable to hold de PersonaBDContext instance
        private readonly PersonaDbContext _context;

        //Constructors
        public PersonaRepository()
        {
            _context = new PersonaDbContext();
        }

        public PersonaRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public void Delete(int cc)
        {
            Persona persona = _context.Personas.Find(cc);
            if(persona!=null)
            {
                _context.Personas.Remove(persona);
            }
        }

        public IEnumerable<Persona> GetAll()
        {
            return _context.Personas.ToList();            
        }

        public Persona GetByCC(int cc)
        {
            return _context.Personas.Find(cc);
        }

        public void Insert(Persona persona)
        {
            _context.Personas.Add(persona);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Persona persona)
        {
            _context.Entry(persona).State=EntityState.Modified;
        }
    }
}

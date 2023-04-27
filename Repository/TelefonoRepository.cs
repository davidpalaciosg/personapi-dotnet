using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interface;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repository
{
    public class TelefonoRepository : ITelefonoRepository
    {
        //Variable to hold de PersonaBDContext instance
        private readonly PersonaDbContext _context;

        //Constructors
        public TelefonoRepository()
        {
            _context = new PersonaDbContext();
        }
        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public void Delete(string num)
        {
            Telefono telefono = _context.Telefonos.Find(num);
            if(telefono!=null)
            {
                _context.Telefonos.Remove(telefono);
            }
        }

        public IEnumerable<Telefono> GetAll()
        {
            return _context.Telefonos.Include(t=>t.DuenioNavigation).ToList();
        }

        public Telefono GetByNum(string num)
        {
            return _context.Telefonos.Include(t => t.DuenioNavigation).FirstOrDefault(m => m.Num == num);
        }

        public void Insert(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Telefono telefono)
        {
            _context.Entry(telefono).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}

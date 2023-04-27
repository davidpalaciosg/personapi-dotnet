using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interface
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetAll();
        Persona GetByCC(int cc);
        void Insert(Persona persona);
        void Update(Persona persona);
        void Delete(int cc);
        void Save();
    }
}

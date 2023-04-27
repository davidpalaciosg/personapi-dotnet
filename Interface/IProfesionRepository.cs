using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interface
{
    public interface IProfesionRepository
    {
        IEnumerable<Profesion> GetAll();
        Profesion GetByID(int id);
        void Insert(Profesion profesion);
        void Update(Profesion profesion);
        void Delete(int id);
        void Save();
    }
}

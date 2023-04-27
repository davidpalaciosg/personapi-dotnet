using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interface
{
    public interface ITelefonoRepository
    {
        IEnumerable<Telefono> GetAll();
        Telefono GetByNum(String num);
        void Insert(Telefono telefono);
        void Update(Telefono telefono);
        void Delete(String num);
        void Save();
    }
}

using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interface
{
    public interface IEstudioRepository
    {
        IEnumerable<Estudio> GetAll();
        Estudio GetByKeys(int idProf, int ccPer);
        void Insert(Estudio estudio);
        void Update(Estudio estudio);
        void Delete(int idProf,  int ccPer);
        void Save();
    }
}

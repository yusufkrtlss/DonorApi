using BloodBank.Models;

namespace BloodBank.DataAccess.Services
{
    public interface IBloodService
    {
        void AddRequest(RequestBlood request);
    }
}

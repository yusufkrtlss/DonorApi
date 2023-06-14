using BloodBank.DataAccess.Context;
using BloodBank.Models;

namespace BloodBank.DataAccess.Services
{
    public class BloodManager : IBloodService
    {
        
        public void AddRequest(RequestBlood request)
        {
            var c = new BloodApiDb();
            c.BloodRequests.Add(request);
            c.SaveChanges();

        }
    }
}

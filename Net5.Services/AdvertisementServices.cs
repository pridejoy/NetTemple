using Net5.IServices;
using Net5.Model.Models;
using Net5.Repository.Base;

namespace Net5.Services
{
    public class AdvertisementServices : BaseServices<Advertisement>, IAdvertisementServices
    {
        IBaseRepository<Advertisement> _dal;
        public AdvertisementServices(IBaseRepository<Advertisement> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

        public void ReturnExp()
        {

            int a = 1;
            int b = 0;

            int c = a / b;
        }

        

    }
}

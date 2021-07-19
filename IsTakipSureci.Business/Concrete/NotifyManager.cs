using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.Concrete
{
    public class NotifyManager : INotifyService
    {
        private readonly INotifyDal _notifyDal;

        public NotifyManager(INotifyDal notifyDal)
        {
            _notifyDal = notifyDal;
        }

        public void Delete(Notify entity)
        {
            _notifyDal.Delete(entity);
        }

        public List<Notify> GetAll()
        {
            return _notifyDal.GetAll();
        }

        public Notify GetById(int id)
        {
            return _notifyDal.GetById(id);
        }

        public List<Notify> GetByStatus(int appUserId)
        {
            return _notifyDal.GetByStatus(appUserId);
        }

        public int GetUnReadNotifyByUserId(int id)
        {
            return _notifyDal.GetUnReadNotifyByUserId(id);
        }

        public void Save(Notify entity)
        {
            _notifyDal.Save(entity);
        }

        public void Update(Notify entity)
        {
            _notifyDal.Update(entity);
        }
    }
}

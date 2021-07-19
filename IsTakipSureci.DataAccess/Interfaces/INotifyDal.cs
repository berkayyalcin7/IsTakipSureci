using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DataAccess.Interfaces
{
    public interface INotifyDal:IRepositoryDal<Notify>
    {
        List<Notify> GetByStatus(int appUserId);
        int GetUnReadNotifyByUserId(int id);
       
    }
}

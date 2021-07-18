using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.Interfaces
{
    public interface INotifyService:IService<Notify>
    {
        List<Notify> GetByStatus(int appUserId);
    }
}

using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DataAccess.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> GetAllMemberUser();

        List<AppUser> GetAllMemberUser(out int toplamSayfa,string aranacakKelime,int aktifSayfa=1);

        List<DualHelper> GetMostFinishedWorkUser();

        List<DualHelper> GetMostTaskedUser();
    }
}

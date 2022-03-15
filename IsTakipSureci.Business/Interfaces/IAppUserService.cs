using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetAllMemberUser();
        List<AppUser> GetAllMemberUser(out int toplamSayfa,string aranacakKelime, int aktifSayfa = 1);

        List<DualHelper> GetMostTaskedUser();

        List<DualHelper> GetMostFinishedWorkUser();
    }
}

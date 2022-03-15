using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public List<AppUser> GetAllMemberUser()
        {
            return _appUserDal.GetAllMemberUser();
        }

        public List<AppUser> GetAllMemberUser(out int toplamSayfa,string aranacakKelime, int aktifSayfa = 1)
        {
            return _appUserDal.GetAllMemberUser(out toplamSayfa,aranacakKelime, aktifSayfa);
        }

        public List<DualHelper> GetMostFinishedWorkUser()
        {
            return _appUserDal.GetMostFinishedWorkUser();
        }

        public List<DualHelper> GetMostTaskedUser()
        {
            return _appUserDal.GetMostTaskedUser();
        }
    }
}

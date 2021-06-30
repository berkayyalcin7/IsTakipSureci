using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfLevelRepository:EfRepositoryBase<Level>,ILevelDal
    {

    }
}

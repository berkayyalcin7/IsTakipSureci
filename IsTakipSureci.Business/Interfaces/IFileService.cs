using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Geriye Upload etmiş olduğu pdf 'in Sanal dosya yolunu string olarak döner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string PdfConvert<T>(List<T> list) where T:class,new();

        /// <summary>
        /// Geriye Excel verisini byte dizisi olarak döner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] ExcelConvert<T>(List<T> list) where T:class , new ();
    }
}

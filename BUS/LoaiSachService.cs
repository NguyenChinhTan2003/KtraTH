using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BUS
{
    public class LoaiSachService
    {
        public List<LoaiSach> GetAll()
        {
            QuanlysachDBContext context = new QuanlysachDBContext();
            return context.LoaiSaches.ToList();
        }
    }
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BUS
{
    public class SachService
    {
        public List<Sach> GetAll()
        {
            QuanlysachDBContext context = new QuanlysachDBContext();
            return context.Saches.ToList();

        }
        public void Add(Sach s)
        {
            QuanlysachDBContext contetx = new QuanlysachDBContext();
            contetx.Saches.Add(s);
            contetx.SaveChanges();
        }
        public void Delete(string mas)
        {
            QuanlysachDBContext context = new QuanlysachDBContext();
            Sach s = context.Saches.FirstOrDefault(p => p.MaSach == mas);
            if(s != null)
            {
                context.Saches.Remove(s);
                context.SaveChanges();
            }

        }
        public void Update(Sach s)
        {
            QuanlysachDBContext context = new QuanlysachDBContext();
            if (context.Saches.Any(p => p.MaSach == s.MaSach))
            {
                context.Entry(s).State = System.Data.Entity.EntityState.Modified;
                
            }
        }
    }
}

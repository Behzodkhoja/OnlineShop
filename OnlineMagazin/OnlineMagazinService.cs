using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMagazin
{
    public class OnlineMagazinDervice
    {
        List<Magazin> magazinlar = new List<Magazin>();
        List<DokonSer> dokonSers = new List<DokonSer>();
        decimal total = 0;
        public bool Create(Magazin magazin)
        {
            var create=magazinlar.Find(x=>x.Id==magazin.Id);
            if (create is  null)
            {
                magazinlar.Add(magazin);
                return true;
            }
            return false;
        }
        public List<Magazin> GetAll()
        {
            return magazinlar;
        }
        public Magazin Delete(int id)
        {
            var uchir=magazinlar.FirstOrDefault(x=>x.Id==id);
            {
                if (uchir is not null)
                {
                    magazinlar.Remove(uchir);
                    return uchir;
                }
                return null;
            }
        }
        public Magazin GetById(int id)
        {
            var idTop=magazinlar.FirstOrDefault(x=>x.Id==id);
            if (idTop is not null)
            {
                return idTop;
            }
            return null;
        }
        public Magazin UpDate(Magazin magazin,int id)
        {
            var tekshir=magazinlar.FirstOrDefault(x=> x.Id==id);
            if (tekshir is not null)
            {
                tekshir.ismi = magazin.ismi;
                tekshir.Soni = magazin.Soni;
                tekshir.Narxi = magazin.Narxi;
                tekshir.Id = magazin.Id;
                return tekshir;
            }
            return null;
        }
        public bool ZakazBerish(string ismi, int count )
        {
            var qidir = magazinlar.FirstOrDefault(x => x.ismi == ismi);
            if (qidir is not null)
            {
                var mahsulot = dokonSers.FirstOrDefault(x => x.Ismi == ismi);
                if(mahsulot is not null)
                {
                    mahsulot.Soni = mahsulot.Soni + count;
                    total = total + (mahsulot.Narxi * count);
                }
                else
                {
                    DokonSer use = new DokonSer();
                    use.Ismi = ismi;
                    use.Soni = count;
                    use.Narxi = qidir.Narxi;
                    total = total + (qidir.Narxi * count);
                    dokonSers.Add(use);
                }
                
                return true;

            }
            return false;
        }
        public decimal Jami()
        {
            return total;
        }
        public List<DokonSer> HammaSotilganMahsulotlarMalumoti()
        {
            return dokonSers;
        }
    }
}


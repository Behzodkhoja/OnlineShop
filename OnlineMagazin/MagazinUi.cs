using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMagazin
{
    public class MagazinUi
    {
        public void Chiqar()
        {
            
            OnlineMagazinDervice magazin = new OnlineMagazinDervice();

            while(true)
            {
                Magazin dokon = new Magazin();
                DokonSer dokonSer= new DokonSer();
                Console.WriteLine("************************************************");
                Console.WriteLine("*  Maxsulotlarni kiriting -----------------> 1 *");
                Console.WriteLine("*  Malumotlarni o'zgartirish --------------> 2 *");
                Console.WriteLine("*  Barcha malumotlarni ko'rish ------------> 3 *");
                Console.WriteLine("*  Berilgan Id dagi maxsulotni ko'rish ----> 4 *");
                Console.WriteLine("*  Maxshulotni Id bo'yicha o'chirish-------> 5 *");
                Console.WriteLine("*  Zakaz berish ---------------------------> 6 *");
                Console.WriteLine("*  Berilgan zakazni ko'rish----------------> 7 *");
                Console.WriteLine("*  EXIT -----------------------------------> 0 *");
                Console.WriteLine("************************************************");
                Console.Write("Malumot kiriting:");
            
                int num = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Maxsulot Id sini kiriting:");
                        dokon.Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Maxsulot nomini kiriting:");
                        dokon.ismi = Console.ReadLine();
                        Console.WriteLine("Maxsulot sonini  kiriting:");
                        dokon.Soni=int.Parse(Console.ReadLine());
                        Console.WriteLine("Maxsulot narxini kiriting:");
                        dokon.Narxi = int.Parse(Console.ReadLine());
                        magazin.Create(dokon);
                        Console.WriteLine("******Malumotlar kiritildi*******");
                        break;
                    case 2:
                        Magazin magazin1=new Magazin();
                        Console.WriteLine("Qaysi ID dagi maxshulotni o'zgartirasiz:");
                        magazin1.Id=int.Parse(Console.ReadLine());
                        Console.WriteLine("Maxsulot nomini nima deb o'zgartirasiz:");
                        magazin1.ismi = Console.ReadLine();
                        Console.WriteLine("Maxsulot sonini :");
                        magazin1.Soni=int.Parse(Console.ReadLine());
                        Console.WriteLine("Maxsulot narxini kiriting:");
                        magazin1.Narxi=int.Parse(Console.ReadLine());
                        magazin.UpDate(magazin1,magazin1.Id);
                        Console.WriteLine("***Malumotlar qo'shildi***");
                        break;
                    case 3:
                        Console.WriteLine("********Barcha malumotlar*********");
                        var maggazin = magazin.GetAll();
                        foreach( var maxsulott in maggazin)
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("ID       : " + maxsulott.Id);
                            Console.WriteLine("Nomi     : " + maxsulott.ismi);
                            Console.WriteLine("Soni     : " + maxsulott.Soni);
                            Console.WriteLine("Narxi    : " + maxsulott.Narxi);
                        }
                        Console.ReadKey();
                        Console.WriteLine("***Chiqish uchun hohlagan harifni bosing***");
                        break;
                    case 4:
                        Console.WriteLine("Qaysi ID dagi malumotni ko'rasiz:");
                        int son=int.Parse(Console.ReadLine());
                        var productId=magazin.GetById(son);
                        Console.WriteLine("*****ID bo'yicha qidirgan malumotingiz*****");
                        Console.WriteLine("ID       : " + productId.Id);
                        Console.WriteLine("Nomi     : " + productId.ismi);
                        Console.WriteLine("Soni     : " + productId.Soni);
                        Console.WriteLine("Narxi    : " + productId.Narxi);
                        break;
                    case 5:
                        Console.WriteLine("Qaysi ID dagi malumotni o'chirish kerak:");
                        int uchir=int.Parse(Console.ReadLine());
                        magazin.Delete(uchir);
                        Console.WriteLine("******Malumot O'chirildi*******");
                        break;
                    case 6:
                        DokonSer dokonSer1 = new DokonSer();
                        Console.Write("Qanday maxsulot olmoqchisiz:");
                        dokonSer1.Ismi = Console.ReadLine();
                        Console.WriteLine("Neshta olmoqchisiz: ");
                        dokonSer1.Soni=int.Parse(Console.ReadLine());
                        magazin.ZakazBerish(dokonSer1.Ismi, dokonSer1.Soni);
                        Console.WriteLine("********Zakaz qabul qilindi*********");
                        break;
                    case 7:
                        Console.WriteLine("****Siz zakaz qilgan narsalar****");
                        var malumott = magazin.HammaSotilganMahsulotlarMalumoti();
                        var jami = magazin.Jami();
                        foreach (var hammasi in malumott)
                        {
                            Console.WriteLine("Ismi          : " + hammasi.Ismi);
                            Console.WriteLine("Soni          : " + hammasi.Soni);
                            Console.WriteLine("Narxi         : " + hammasi.Narxi);
                           
                        }
                        Console.WriteLine("Jami summa        : " + jami);
                     
                        break;
                    case 0:
                        System.Environment.Exit(0);
                        Console.WriteLine("******Dastur to'xtatildi********");
                        break;
                }
            }
        }
        
    }
}











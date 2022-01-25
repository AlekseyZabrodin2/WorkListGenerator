using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;
using WorkListGenerator.Model;
using WorkListGenerator.Model.Data;

namespace WorkListGenerator
{
    class MainViewModel
    {
        void Main(string[] args)
        {
            using (ApplicationContest dateBase = new ApplicationContest())
            {
                {
                    WorkList workList = new WorkList {Id = 1, LastName = "Petrov", Name = "Vasia"};

                    dateBase.WorkLists.AddRange(workList);
                    dateBase.SaveChanges();
                }
                // получение данных
                using (ApplicationContest dataBase = new ApplicationContest())
                {
                    var workList = dataBase.WorkLists.ToList();
                    Console.WriteLine("Список объектов:");
                    foreach (WorkList u in workList)
                    {
                        Console.WriteLine($"{u.Id}.{u.Name} - {u.LastName}");
                    }
                }
            }
        }

    }
}

using Namely.Core.Model;
using Namely.Core.Repository;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namely.Core.Service
{
    public class BabyNameDataService
    {
        //private static NameRepository nameRepository = new NameRepository();
        private static NameRepository nameRepository = new NameRepository();

        public List<BabyName> GetAllBabyNames()
        {

            return nameRepository.GetAllBabyNames();
            //return new DbHelper
        }

        public BabyName GetBabyNameByName(string babyName)
        {

            return nameRepository.GetBabyNameByName(babyName);
        }
    }
}

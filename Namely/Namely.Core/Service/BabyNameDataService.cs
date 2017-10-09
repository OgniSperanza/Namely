using Namely.Core.Model;
using Namely.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namely.Core.Service
{
    class BabyNameDataService
    {
        private static NameRepository nameRepository = new NameRepository();

        public List<BabyName> GetAllBabyNames()
        {

            return nameRepository.GetAllBabyNames();
        }

        public BabyName GetBabyNameByName(string babyName)
        {

            return nameRepository.GetBabyNameByName(babyName);
        }
    }
}

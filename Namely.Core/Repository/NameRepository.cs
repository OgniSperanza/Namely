using Namely.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namely.Core.Repository
{
    //using hard coded data for the time being.
    public class NameRepository
    {
        private static List<BabyName> sampleBabyNames = new List<BabyName>()
        {
            new BabyName()
            {                
                Name="Jacob",
                NickNames= new List<string>() {"Jake", "TestNickName" },
                Pronunciation = "pronunciation"
            },
            new BabyName()
            {
                Name="Christianne",
                NickNames= new List<string>() {"Chris", "Christi" },
                Pronunciation = "pronunciation"
            },
            new BabyName()
            {
                Name="Ezekiel",
                NickNames= new List<string>() {"Zeke"},
                Pronunciation = "pronunciation"
            }
        };

        public List<BabyName> GetAllBabyNames()
        {
            IEnumerable<BabyName> babyNames =
                from name in sampleBabyNames
                select name;

            return babyNames.ToList<BabyName>();
        }

        public BabyName GetBabyNameByName(string babyName)
        {
            IEnumerable<BabyName> babyNames =
                from name in sampleBabyNames
                where name.Name == babyName
                select name;

            return babyNames.FirstOrDefault();
        }
    }
}

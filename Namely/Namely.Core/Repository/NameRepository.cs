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
                NickNames= new List<string>() {"Jake", "TestNickName" }
            },
            new BabyName()
            {
                Name="Christianne",
                NickNames= new List<string>() {"Chris", "Christi" }
            },
            new BabyName()
            {
                Name="Ezekiel",
                NickNames= new List<string>() {"Zeke"}
            }
        };


    }
}

using AdessoCodeChallenge.DataAccessCore;
using AdessoCodeChallenge.DomainCore;
using AdessoCodeChallenge.ServiceCore.CommonRepository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.ServiceCore.Repository.CountryRepository
{
	public class CountryRepository : GenericRepository<Country>, ICountryRepository	
	{
        public CountryRepository(AdessoCodeChallengeDBContext dBContext):base(dBContext)
        {
                
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.DataAccessCore
{
	public class SeedDB
	{
		public SeedDB()
		{

		}
		public static void Initialize(AdessoCodeChallengeDBContext context)
		{
			context.Database.EnsureCreated();
			context.Database.Migrate();


			context.SaveChanges();

		}
	}
}

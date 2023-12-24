using AdessoCodeChallenge.DomainCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Data;

namespace AdessoCodeChallenge.DataAccessCore
{
	public interface IAdessoCodeChallengeDBContext
	{
		public DbSet<Country> Countries { get; set; }

		public DbSet<Group> Groups { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<WLDrawInfo> WLDrawInfos { get; set; }
		public DbSet<WLDrawResult> WLDrawResults { get; set; }

		int SaveChanges();
		EntityEntry Entry(object entity);
	}
}

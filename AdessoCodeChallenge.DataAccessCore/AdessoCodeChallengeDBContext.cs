using AdessoCodeChallenge.DomainCore;
using AdessoCodeChallenge.DomainCore.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.DataAccessCore
{
	public class AdessoCodeChallengeDBContext : DbContext
	{
		public DbSet<Country> Countries { get; set; }

		public DbSet<Group> Groups { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<WLDrawInfo> WLDrawInfos { get; set; }
		public DbSet<WLDrawResult> WLDrawResults { get; set; }
		public AdessoCodeChallengeDBContext(DbContextOptions<AdessoCodeChallengeDBContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public async Task<int> SaveChangesAsAsync()
		{
			AddTimestamps();
			return await base.SaveChangesAsync();
		}

		public override int SaveChanges()
		{
			AddTimestamps();
			return base.SaveChanges();
		}
		private void AddTimestamps()
		{
			var entities = ChangeTracker.Entries().Where(x => x.Entity is Base && (x.State == EntityState.Added || x.State == EntityState.Modified));
			foreach (var entity in entities)
			{
				Guid userid = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"); //Default Admin

				//TODO

				if (entity.State == EntityState.Added)
				{
					((Base)entity.Entity).Id = Guid.NewGuid();
					((Base)entity.Entity).DateCreated = DateTime.Now;
					((Base)entity.Entity).UserCreated = userid;
					((Base)entity.Entity).IsActive = true;
					((Base)entity.Entity).IsDeleted = false;
				}

				((Base)entity.Entity).DateModified = DateTime.Now;
				((Base)entity.Entity).UserModified = userid;
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

			modelBuilder.Entity<Country>().HasData(
			new Country
			{
				Id = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907080"),
				Name = "Türkiye",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Country
			{
				Id = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907081"),
				Name = "Almanya",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Country
			{
				Id = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907082"),
				Name = "Fransa",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Country
			{
				Id = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907083"),
				Name = "Hollanda",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Country
			{
				Id = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907084"),
				Name = "Portekiz",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Country
			{
				Id = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907085"),
				Name = "İtalya",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Country
			{
				Id = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907086"),
				Name = "İspanya",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Country
			{
				Id = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907087"),
				Name = "Belçika",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			}
			);

			modelBuilder.Entity<Group>().HasData(
			new Group
			{
				Id = Guid.Parse("1FCC262D-7EA7-4BA6-890B-681AC0886960"),
				Name = "A",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false,
			},
			new Group
			{
				Id = Guid.Parse("1FCC262D-7EA7-4BA6-890B-681AC0886961"),
				Name = "B",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false,
			},
			new Group
			{
				Id = Guid.Parse("1FCC262D-7EA7-4BA6-890B-681AC0886962"),
				Name = "C",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false,
			},
			new Group
			{
				Id = Guid.Parse("1FCC262D-7EA7-4BA6-890B-681AC0886963"),
				Name = "D",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false,
			},
			new Group
			{
				Id = Guid.Parse("1FCC262D-7EA7-4BA6-890B-681AC0886964"),
				Name = "E",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false,
			},
			new Group
			{
				Id = Guid.Parse("1FCC262D-7EA7-4BA6-890B-681AC0886965"),
				Name = "F",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false,
			},
			new Group
			{
				Id = Guid.Parse("1FCC262D-7EA7-4BA6-890B-681AC0886966"),
				Name = "G",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false,
			},
			new Group
			{
				Id = Guid.Parse("1FCC262D-7EA7-4BA6-890B-681AC0886967"),
				Name = "H",
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false,
			}
			);

			modelBuilder.Entity<Team>().HasData(
		   new Team
		   {
			   Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886950"),
			   Name = "Adesso İstanbul",
			   CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907080"),
			   DateCreated = DateTime.Now,
			   DateModified = DateTime.Now,
			   UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
			   UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
			   IsActive = true,
			   IsDeleted = false
		   },
		   new Team
		   {
			   Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886951"),
			   Name = "Adesso Ankara",
			   CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907080"),
			   DateCreated = DateTime.Now,
			   DateModified = DateTime.Now,
			   UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
			   UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
			   IsActive = true,
			   IsDeleted = false
		   },
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886952"),
				Name = "Adesso İzmir",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907080"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886953"),
				Name = "Adesso Antalya",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907080"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886954"),
				Name = "Adesso Berlin",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907081"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			}, 
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886955"),
				Name = "Adesso Frankfurt",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907081"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886956"),
				Name = "Adesso Münih",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907081"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886957"),
				Name = "Adesso Dortmund",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907081"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886958"),
				Name = "Adesso Paris",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907082"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886959"),
				Name = "Adesso Marsilya",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907082"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886960"),
				Name = "Adesso Nice",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907082"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886961"),
				Name = "Adesso Lyon",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907082"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886962"),
				Name = "Adesso Amsterdam",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907083"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886963"),
				Name = "Adesso Rotterdam",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907083"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886964"),
				Name = "Adesso Lahey",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907083"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886965"),
				Name = "Adesso Eindhoven",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907083"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886966"),
				Name = "Adesso Lisbon",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907084"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886967"),
				Name = "Adesso Porto",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907084"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886968"),
				Name = "Adesso Braga",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907084"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886969"),
				Name = "Adesso Coimbra",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907084"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886970"),
				Name = "Adesso Roma",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907085"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886971"),
				Name = "Adesso Milano",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907085"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886972"),
				Name = "Adesso Venedik",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907085"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886973"),
				Name = "Adesso Napoli",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907085"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886974"),
				Name = "Adesso Sevilla",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907086"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886975"),
				Name = "Adesso Madrid",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907086"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886976"),
				Name = "Adesso Barselona",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907086"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886977"),
				Name = "Adesso Granada",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907086"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	
			new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886978"),
				Name = "Adesso Brüksel",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907087"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886979"),
				Name = "Adesso Brugge",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907087"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886980"),
				Name = "Adesso Gent",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907087"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			},	new Team
			{
				Id = Guid.Parse("1FCC262D-8EA7-4BA6-890B-681AC0886981"),
				Name = "Adesso Anvers",
				CountryId = Guid.Parse("1FCC262D-6EA7-4BA6-890B-681AC0907087"),
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserCreated = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				UserModified = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"),
				IsActive = true,
				IsDeleted = false
			}
		   );
		}

	}
}

using AdessoCodeChallenge.DomainCore.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.DomainCore.Concrete
{
	public class Base:IBase
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; } = Guid.NewGuid();

		[Column("DateCreated")]
		public DateTime DateCreated { get; set; } = DateTime.Now;

		[Column("DateModified")]
		public DateTime DateModified { get; set; } = DateTime.Now;

		[Column("UserCreated")]
		public Guid? UserCreated { get; set; } = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"); //Admin


		[Column("UserModified")]
		public Guid? UserModified { get; set; } = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971"); //Admin

		[Column("IsActive")]
		public bool IsActive { get; set; }

		[Column("IsDeleted")]
		public bool IsDeleted { get; set; }
	}
}

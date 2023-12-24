using AdessoCodeChallenge.DomainCommonCore.ResponseResult;
using AdessoCodeChallenge.DomainCore.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.ServiceCore.CommonRepository.Abstract
{
	public interface IGenericRepository<T> where T : Base
	{
		Task<T> GetByIdAsync(Guid id);
		Task<List<T>> GetAllAsync();
		Task<Result> AddAsync(T entity);
		Task<Result> UpdateAsync(T entity);
		Task<Result> DeleteAsync(Guid Id);
	}
}

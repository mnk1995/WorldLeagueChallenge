using AdessoCodeChallenge.DataAccessCore;
using AdessoCodeChallenge.DomainCommonCore.ResponseResult;
using AdessoCodeChallenge.DomainCore.Concrete;
using AdessoCodeChallenge.ServiceCore.CommonRepository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.ServiceCore.CommonRepository.Concrete
{
	public class GenericRepository<T> : IGenericRepository<T> where T : Base
	{
		private readonly AdessoCodeChallengeDBContext context;
		public GenericRepository(AdessoCodeChallengeDBContext context)
		{
			this.context = context;
		}

		public virtual async Task<Result> AddAsync(T entity)
		{
			Result<T> result = new Result<T>();
			try
			{
				await context.Set<T>().AddAsync(entity);
				context.SaveChanges();
				result.Success = true;
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = ex.Message;
			}
			return result;
		}

		public virtual async Task<Result> DeleteAsync(Guid Id)
		{
			Result<T> result = new Result<T>();
			try
			{
				var modelInfo = context.Set<T>().FirstOrDefault(x => x.Id == Id);
				modelInfo.IsActive = false;
				modelInfo.IsDeleted = true;
				context.Set<T>().Attach(modelInfo);
				context.Entry(modelInfo).State = EntityState.Modified;
				await context.SaveChangesAsAsync();
				result.Success = true;
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = ex.Message;
			}
			return result;
		}

		public virtual async Task<List<T>> GetAllAsync()
		{
			try
			{
				var modelInfo = await context.Set<T>().Where(x => x.IsActive == true).ToListAsync();
				return modelInfo;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public virtual async Task<T> GetByIdAsync(Guid Id)
		{
			Result<T> result = new Result<T>();
			try
			{
				var modelInfo = await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
				return modelInfo;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public virtual async Task<Result> UpdateAsync(T entity)
		{
			Result<T> result = new Result<T>();
			try
			{
				context.Set<T>().Attach(entity);
				context.Entry(entity).State = EntityState.Modified;
				await context.SaveChangesAsAsync();
				result.Success = true;
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = ex.Message;
			}
			return result;
		}

	}
}

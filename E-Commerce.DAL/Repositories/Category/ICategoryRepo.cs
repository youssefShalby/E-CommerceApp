﻿
namespace E_Commerce.DAL.Repositories;

public interface ICategoryRepo : IGenericRepo<Category>
{
	Task<Category> GetByIdWithIncludesAsync(Guid id);
}
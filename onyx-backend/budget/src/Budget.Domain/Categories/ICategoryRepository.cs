﻿using Models.Responses;
using System.Linq.Expressions;

namespace Budget.Domain.Categories;

public interface ICategoryRepository
{
    Result<Category> GetByName(CategoryName name, CancellationToken cancellationToken);

    Task<Result<Category>> AddAsync(Category category, CancellationToken cancellationToken);

    Task<Result<IEnumerable<Category>>> GetAllAsync(CancellationToken cancellationToken);
    Result<Category> GetFirst(
        Expression<Func<Category, bool>> filterPredicate,
        CancellationToken cancellationToken);

    Task<Result<Category>> GetByIdAsync(CategoryId categoryId, CancellationToken cancellationToken);

    Task<Result> RemoveAsync(CategoryId categoryId, CancellationToken cancellationToken = default);

    Task<Result<Category>> UpdateAsync(Category category, CancellationToken cancellationToken);
}
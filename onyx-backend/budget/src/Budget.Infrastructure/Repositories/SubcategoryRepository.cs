﻿using Budget.Application.Abstractions.Identity;
using Budget.Domain.Subcategories;
using SharedDAL;

namespace Budget.Infrastructure.Repositories;

internal sealed class SubcategoryRepository : BaseBudgetRepository<Subcategory, SubcategoryId>, ISubcategoryRepository
{
    public SubcategoryRepository(CosmosDbContext context, IBudgetContext budgetContext) : base(context, budgetContext)
    {
    }
}
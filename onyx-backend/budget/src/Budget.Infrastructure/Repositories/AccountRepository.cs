﻿using Budget.Domain.Accounts;
using Budget.Domain.Categories;
using Budget.Infrastructure.Data;
using Models.Responses;

namespace Budget.Infrastructure.Repositories;

internal sealed class AccountRepository : Repository<Account, AccountId>, IAccountRepository
{
    public AccountRepository(CosmosDbContext context) : base(context)
    {
    }

    public async Task<Result<Account>> GetByNameAsync(AccountName accountName, CancellationToken cancellationToken)
    {
        var entities = await Task.Run(
            () => Container.GetItemLinqQueryable<Account>(true)
                .Where(a => a.Name == accountName)
                .AsEnumerable(),
            cancellationToken);

        var entity = entities.SingleOrDefault();

        return entity is null ?
            Result.Failure<Account>(DataAccessErrors<Category>.NotFound) :
            Result.Success(entity);
    }
}
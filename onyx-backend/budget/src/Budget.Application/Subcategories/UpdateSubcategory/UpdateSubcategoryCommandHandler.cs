﻿using Abstractions.Messaging;
using Budget.Application.Subcategories.Models;
using Budget.Domain.Subcategories;
using Models.Responses;

namespace Budget.Application.Subcategories.UpdateSubcategory;

internal sealed class UpdateSubcategoryCommandHandler : ICommandHandler<UpdateSubcategoryCommand, SubcategoryModel>
{
    private readonly ISubcategoryRepository _subcategoryRepository;

    public UpdateSubcategoryCommandHandler(ISubcategoryRepository subcategoryRepository)
    {
        _subcategoryRepository = subcategoryRepository;
    }

    public async Task<Result<SubcategoryModel>> Handle(UpdateSubcategoryCommand request, CancellationToken cancellationToken)
    {
        var subcategoryId = new SubcategoryId(request.Id);
        var subcategoryGetResult = await _subcategoryRepository.GetByIdAsync(subcategoryId, cancellationToken);

        if (subcategoryGetResult.IsFailure)
        {
            return Result.Failure<SubcategoryModel>(subcategoryGetResult.Error);
        }

        var subcategory = subcategoryGetResult.Value;

        var updateSubcategoryServiceResult = SubcategoryService.UpdateSubcategory(
            subcategory,
            request.NewName,
            request.NewDescription);

        if (updateSubcategoryServiceResult.IsFailure)
        {
            return Result.Failure<SubcategoryModel>(updateSubcategoryServiceResult.Error);
        }

        var subcategoryUpdateResult = await _subcategoryRepository.UpdateAsync(subcategory, cancellationToken);

        if (subcategoryUpdateResult.IsFailure)
        {
            return Result.Failure<SubcategoryModel>(subcategoryUpdateResult.Error);
        }

        subcategory = subcategoryUpdateResult.Value;

        return SubcategoryModel.FromDomainModel(subcategory);
    }
}
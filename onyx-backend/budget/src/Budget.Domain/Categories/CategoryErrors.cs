﻿using Models.Responses;

namespace Budget.Domain.Categories;

internal static class CategoryErrors
{
    internal static readonly Error MaxSubcategoriesCountReached = new(
        "Category.MaxSubcategoriesCountReached",
        "Max subcategories count reached");

    internal static readonly Error InvalidNameError = new(
        "Category.Message.InvalidValue",
        "Invalid category name input");

    internal static readonly Error SubcategoryNotFound = new(
        "Category.SubcategoryNotFound",
        "Subcategory not found");
    internal static readonly Error SubcategoryAlreadyExists = new (
        "Category.SubcategoryAlreadyExists",
        "Subcategory already exists");
}
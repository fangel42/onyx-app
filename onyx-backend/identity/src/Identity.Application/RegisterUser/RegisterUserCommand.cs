﻿using Abstractions.Messaging;
using Identity.Application.Models;

namespace Identity.Application.RegisterUser;

public sealed record RegisterUserCommand(string Email, string Username, string Password, string Currency) 
    : ICommand<UserModel>
{
}
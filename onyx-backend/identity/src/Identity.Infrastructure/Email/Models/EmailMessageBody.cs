﻿using Models.Responses;

namespace Identity.Infrastructure.Email.Models;

internal sealed record EmailMessageBody
{
    public string Value { get; init; }

    private EmailMessageBody(string value)
    {
        Value = value;
    }

    public static Result<EmailMessageBody> CreateHtml(string body)
    {
        return new EmailMessageBody(body);
    }

    public static Result<EmailMessageBody> CreatePlainText(string body)
    {
        return new EmailMessageBody(body);
    }
}
using Microsoft.AspNetCore.Identity;

namespace Identity.Persistence.Common.Configuration.Models;

public class IdentityConfiguration
{
    public required IdentityOptions Options { get; set; }
}
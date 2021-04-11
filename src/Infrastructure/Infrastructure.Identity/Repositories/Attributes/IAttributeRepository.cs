using Infrastructure.Identity.DTOs.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Repositories.Attributes
{
    public interface IAttributeRepository
    {
        Task AddAttributes(Models.Attribute attribute);
        Task<bool> AttributeExist(string key, Guid userId);
        Task<Dictionary<string, string>> GetAttributesOfUser(Guid userId);
        Task RemoveAttribute(Models.Attribute attributeRequest);
        Task UpdateAttribute(Models.Attribute attribute);
    }
}

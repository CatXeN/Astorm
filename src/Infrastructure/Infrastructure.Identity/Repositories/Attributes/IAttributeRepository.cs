using Infrastructure.Identity.DTOs.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Repositories.Attributes
{
    public interface IAttributeRepository
    {
        Task AddAttributes(List<AstormDomain.Entities.Attribute> attribute);
        Task AddAttribute(AstormDomain.Entities.Attribute attribute);
        Task<bool> AttributeExist(string key, Guid userId);
        Task<Dictionary<string, string>> GetAttributesOfUser(Guid userId);
        Task RemoveAttribute(AstormDomain.Entities.Attribute attributeRequest);
        Task UpdateAttribute(AstormDomain.Entities.Attribute attribute);
    }
}

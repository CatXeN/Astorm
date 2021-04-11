using Infrastructure.Identity.DTOs;
using Infrastructure.Identity.DTOs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Services.Attributes
{
    public interface IAttributeService
    {
        Task<bool> AddAttribute(AddAttributeRequest addAttributeRequest);
        Task<Dictionary<string, string>> GetAttributes(Guid userId);
        Task<bool> RemoveAttribute(RemoveAttributeRequest removeAttributeRequest);
        Task<bool> UpdateAttribute(UpdateAttributeRequest updateAttributeRequest);
    }
}

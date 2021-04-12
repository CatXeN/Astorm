using Infrastructure.Identity.DTOs;
using Infrastructure.Identity.DTOs.Attributes;
using Infrastructure.Identity.Repositories.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Services.Attributes
{
    public class AttributeService : IAttributeService
    {
        private readonly IAttributeRepository _attributeRepository;

        public AttributeService(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public async Task<bool> AddAttribute(AddAttributeRequest addAttributeRequest)
        {
            if (string.IsNullOrEmpty(addAttributeRequest.Key) || string.IsNullOrEmpty(addAttributeRequest.Value) || addAttributeRequest.UserId == Guid.Empty)
                throw new InvalidOperationException("Missing parameter to add new attribute");

            if (await _attributeRepository.AttributeExist(addAttributeRequest.Key, addAttributeRequest.UserId))
                throw new InvalidOperationException("This attribute already exist");

            var attribute = new Models.Attribute
            {
                Key = addAttributeRequest.Key,
                Value = addAttributeRequest.Value,
                UserId = addAttributeRequest.UserId
            };

            await _attributeRepository.AddAttribute(attribute);
            return true;
        }

        public async Task<Dictionary<string, string>> GetAttributes(Guid userId) =>
            await _attributeRepository.GetAttributesOfUser(userId);

        public async Task<bool> RemoveAttribute(RemoveAttributeRequest removeAttributeRequest)
        {
            if (removeAttributeRequest.UserId == Guid.Empty || string.IsNullOrEmpty(removeAttributeRequest.Key))
                throw new InvalidOperationException("Empty values");

            if (!await _attributeRepository.AttributeExist(removeAttributeRequest.Key, removeAttributeRequest.UserId))
                throw new InvalidOperationException("Attribute not exist");

            Models.Attribute attribute = new Models.Attribute
            {
                UserId = removeAttributeRequest.UserId,
                Key = removeAttributeRequest.Key
            };

            await _attributeRepository.RemoveAttribute(attribute);
            return true;
        }

        public async Task<bool> UpdateAttribute(UpdateAttributeRequest updateAttributeRequest)
        {
            if (!await _attributeRepository.AttributeExist(updateAttributeRequest.Key, updateAttributeRequest.UserId))
                throw new InvalidOperationException("Attribute not exist");

            if (string.IsNullOrEmpty(updateAttributeRequest.Value))
                throw new InvalidOperationException("Empty value");

            Models.Attribute attribute = new Models.Attribute
            {
                Key = updateAttributeRequest.Key,
                Value = updateAttributeRequest.Value,
                UserId = updateAttributeRequest.UserId
            };

            await _attributeRepository.UpdateAttribute(attribute);
            return true;
        }
    }
}

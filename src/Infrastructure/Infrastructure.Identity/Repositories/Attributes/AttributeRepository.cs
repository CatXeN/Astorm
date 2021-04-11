using Infrastructure.Identity.Contexts;
using Infrastructure.Identity.DTOs.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Repositories.Attributes
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly AuthContext _context;

        public AttributeRepository(AuthContext context)
        {
            _context = context;
        }

        public async Task AddAttributes(Models.Attribute attribute)
        {
            await _context.AddAsync(attribute);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AttributeExist(string key, Guid userId) => 
            await _context.Attributes.AnyAsync(x => x.Key == key && x.UserId == userId);

        public async Task<Dictionary<string, string>> GetAttributesOfUser(Guid userId) =>
            await _context.Attributes.Where(x => x.UserId == userId).ToDictionaryAsync(d => d.Key, d => d.Value);

        public async Task RemoveAttribute(Models.Attribute attribute)
        {
            var attrToDelete = await _context.Attributes.
                FirstOrDefaultAsync(x => x.Key == attribute.Key && x.UserId == attribute.UserId);
            _context.Remove(attrToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAttribute(Models.Attribute attribute)
        {
            var attributeToUpdate = await _context.Attributes.
                FirstOrDefaultAsync(x => x.Key == attribute.Key && x.UserId == attribute.UserId);
            attributeToUpdate.Value = attribute.Value;

            _context.Update(attributeToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}

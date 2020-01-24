using System;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class AccountForCreationDto
    {
        public Guid Id { get; set; }
 
        public DateTime DateCreated { get; set; }
 
        public string AccountType { get; set; }
 
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
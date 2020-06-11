using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.Entities
{
    public class UserInformationEntity
    {
        [Key]
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Addres { get; set; }
        public string About { get; set; }

        
        public Guid DepartmentId { get; set; }
        public DepartmentEntity Department { get; set; }
    }
}
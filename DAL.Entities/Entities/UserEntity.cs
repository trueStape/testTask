using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public bool IsDeleted { get; set; }


        public UserInformationEntity UserInformation { get; set; }
    }
}
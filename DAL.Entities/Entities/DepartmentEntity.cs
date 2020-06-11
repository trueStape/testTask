using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.Entities
{
    public class DepartmentEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<UserInformationEntity> Users { get; set; }
    }
}
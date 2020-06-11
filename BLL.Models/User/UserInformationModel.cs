using System;

namespace BLL.Models.User
{
    public class UserInformationModel
    {
        public DateTime DateOfBirth { get; set; }
        public string Addres { get; set; }
        public string About { get; set; }

        public DepartmentModel Department { get; set; }
    }
}
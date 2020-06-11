namespace BLL.Models.User
{
    public class UserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        
        public UserInformationModel UserInformation { get; set; }
    }
}
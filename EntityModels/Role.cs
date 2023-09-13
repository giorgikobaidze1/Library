namespace Library1.EntityModels
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

       public List<UserRole> RoleUsers { get; set;}
    }
}

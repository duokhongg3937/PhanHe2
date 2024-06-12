namespace PhanHe2.Models
{
    public class RoleTablePrivilege
    {
        public string Role { get; set; }
        public string Owner { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Privilege { get; set; }
    }
}

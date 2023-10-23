using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeInfo.Model.db
{
    public class DatabaseObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}

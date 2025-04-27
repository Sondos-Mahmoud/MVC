namespace Demo.PL.Models
{
    public class DepartmentEditViewModel
    {
        public string Name { get; set; } = null;
        public string Code { get; set; } = null;
        public DateOnly DateOfCreation { get; set; }
        public string? Description { get; set; }
    }
}

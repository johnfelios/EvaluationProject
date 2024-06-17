namespace BlazorApp1.Entities
{
    public class BoardingMember : Employee
    {
        public BoardMemberPosition Position { get; set; }
        public int YearsOfService { get; set; }
    }

    public enum BoardMemberPosition
    {
        Chairperson,
        Director,
        Secretary
    }
}

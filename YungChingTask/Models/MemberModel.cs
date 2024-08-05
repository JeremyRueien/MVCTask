namespace YungChingTask.Models;

public class MemberModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Account { get; set; } = null!;
    public int Age { get; set; }
    public string Remark { get; set; } = string.Empty;
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}

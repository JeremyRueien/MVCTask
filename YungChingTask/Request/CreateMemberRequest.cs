namespace YungChingTask.Request;

public record CreateMemberRequest
{
    public string Name { get; set; } = null!;
    public string Account { get; set; } = null!;
    public int Age { get; set; }
    public string Remark { get; set; } = string.Empty;
}

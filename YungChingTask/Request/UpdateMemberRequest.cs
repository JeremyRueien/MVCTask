namespace YungChingTask.Request;

public class UpdateMemberRequest
{
    public int MemberId { get; set; }
    public string Name { get; set; } = null!;
    public string Account { get; set; } = null!;
    public int Age { get; set; }
    public string Remark { get; set; } = string.Empty;
}

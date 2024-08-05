namespace YungChingTask.Request;

public class ListMemberRequest
{
    public string Name { get; set; } = string.Empty;
    public string Account {  get; set; } = string.Empty;
    public int Age { get; set; }
}

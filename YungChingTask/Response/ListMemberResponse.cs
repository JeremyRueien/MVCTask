using YungChingTask.Models;

namespace YungChingTask.Response;

public class ListMemberResponse(MemberModel model)
{
    public int MemberId { get; set; } = model.Id;
    public string MemberName { get; set; } = model.Name;
    public string MemberAccount { get; set; } = model.Account;
    public int Age { get; set; } = model.Age;
    public string Remark { get; set; } = model.Remark;
}

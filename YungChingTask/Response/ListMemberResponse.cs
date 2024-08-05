using YungChingTask.Models;

namespace YungChingTask.Response;

public class ListMemberResponse(MemberModel model)
{
    public int MemberId = model.Id;
    public string MemberName = model.Name;
    public string MemberAccount = model.Account;
    public int Age = model.Age;
    public string Remark = model.Remark;
}

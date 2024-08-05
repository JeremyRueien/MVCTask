using YungChingTask.Models;
using YungChingTask.Request;

namespace YungChingTask.Repository.Interface;

public interface IMemberRepository
{
    Task<bool> Create(MemberModel model);

    Task<bool> Update(MemberModel model);
    Task<IEnumerable<MemberModel>> List(ListMemberRequest request);
    Task<bool> Delete(int memberId);
}

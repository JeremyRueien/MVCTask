using YungChingTask.Models;

namespace YungChingTask.Repository.Interface;

public interface IMemberRepository
{
    Task<bool> Create(MemberModel model);

    Task<bool> Update(MemberModel model);
}

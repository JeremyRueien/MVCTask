using Microsoft.AspNetCore.Mvc;
using YungChingTask.Request;
using YungChingTask.Response;

namespace YungChingTask.Services.Interface;

public interface IMemberService
{
    Task<IActionResult> Create(CreateMemberRequest request);
    Task<IActionResult> Update(UpdateMemberRequest request);
    Task<IEnumerable<ListMemberResponse>> List(ListMemberRequest request);
}

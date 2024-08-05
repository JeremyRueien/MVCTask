using Microsoft.AspNetCore.Mvc;
using YungChingTask.Request;

namespace YungChingTask.Services.Interface;

public interface IMemberService
{
    Task<IActionResult> Create(CreateMemberRequest request);
}

using Microsoft.AspNetCore.Mvc;
using YungChingTask.Request;
using YungChingTask.Services.Interface;

namespace YungChingTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController(IMemberService memberService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateMemberRequest request)
    {
        return await memberService.Create(request);
    }
}

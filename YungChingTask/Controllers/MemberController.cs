using Microsoft.AspNetCore.Mvc;
using YungChingTask.Request;
using YungChingTask.Response;
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

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateMemberRequest request)
    {
        return await memberService.Update(request);
    }

    [HttpPost("list")]
    public async Task<IEnumerable<ListMemberResponse>> List([FromBody] ListMemberRequest request)
    {
        return await memberService.List(request);
    }
}

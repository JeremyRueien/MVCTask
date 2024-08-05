using Microsoft.AspNetCore.Mvc;
using YungChingTask.Models;
using YungChingTask.Repository.Interface;
using YungChingTask.Request;
using YungChingTask.Services.Interface;
using HttpResponse = YungChingTask.Common.HttpResponse;

namespace YungChingTask.Services;

public class MemberService(IMemberRepository memberRepository) : IMemberService
{
    public async Task<IActionResult> Create(CreateMemberRequest request)
    {
        var insertModel = new MemberModel
        {
            Account = request.Account,
            Age = request.Age,
            Name = request.Name,
            Remark = request.Remark,
            CreateTime = DateTime.Now,
        };
        var result = await memberRepository.Create(insertModel);
        return result 
            ? HttpResponse.Create().ToJson() 
            : HttpResponse.Create("Failure").ToJson();
    }
    public async Task<IActionResult> Update(UpdateMemberRequest request)
    {
        var updateModel = new MemberModel
        {
            Id = request.MemberId,
            Account = request.Account,
            Age = request.Age,
            Name = request.Name,
            Remark = request.Remark,
            UpdateTime = DateTime.Now,
        };
        var result = await memberRepository.Update(updateModel);
        return result
            ? HttpResponse.Create().ToJson()
            : HttpResponse.Create("Failure").ToJson();
    }
}

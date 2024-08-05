using Dapper;
using MySqlConnector;
using YungChingTask.Models;
using YungChingTask.Repository.Interface;

namespace YungChingTask.Repository;

public class MemberRepository(IServiceProvider provider) : IMemberRepository
{
    public async Task<bool> Create(MemberModel model)
    {
        return await Sql(conn => conn.ExecuteAsync(
            """
            INSERT INTO 
            member (Name, Account, Age, Remark, CreateTime) 
            VALUES (@Name, @Account, @Age, @Remark, @CreateTime);
            """,
            model)) > 0;
    }
    public async Task<bool> Update(MemberModel model)
    {
        return await Sql(conn => conn.ExecuteAsync(
            """
            UPDATE member 
            SET Name = @Name, Account = @Account, Age = @Age, Remark = @Remark, UpdateTime = @UpdateTime
            WHERE Id = @Id;
            """,
            model)) > 0;
    }

    private TResult Sql<TResult>(Func<MySqlConnection, TResult> func)
    {
        MySqlConnection service = ServiceProviderServiceExtensions.GetService<MySqlConnection>(provider);
        return func(service);
    }
}

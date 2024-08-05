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
            member (Name, Account, Age, Remark) 
            VALUES (@Name, @Account, @Age, @Remark);
            """,
            model)) > 0;
    }

    private TResult Sql<TResult>(Func<MySqlConnection, TResult> func)
    {
        MySqlConnection service = ServiceProviderServiceExtensions.GetService<MySqlConnection>(provider);
        return func(service);
    }
}

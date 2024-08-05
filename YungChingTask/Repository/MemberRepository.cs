using Dapper;
using MySqlConnector;
using YungChingTask.Models;
using YungChingTask.Repository.Interface;
using YungChingTask.Request;

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

    public Task<IEnumerable<MemberModel>> List(ListMemberRequest request)
    {
        var sql =
            """
            SELECT * FROM member /**where**/ ;

            """;
        var whereConditions = new List<string> { };
        if (request.Age > 0) whereConditions.Add("Age = @Age");
        if (!string.IsNullOrEmpty(request.Name)) whereConditions.Add("Name = @Name");
        if (!string.IsNullOrEmpty(request.Account)) whereConditions.Add("Account = @Account");
        if(whereConditions.Count > 0)
            sql = sql.Replace("/**where**/", "WHERE" + string.Join(" AND ", whereConditions));
        return Sql(conn => conn.QueryAsync<MemberModel>(
            sql, new
            {
                request.Age,
                request.Name,
                request.Account
            }));
    }

    private TResult Sql<TResult>(Func<MySqlConnection, TResult> func)
    {
        MySqlConnection service = ServiceProviderServiceExtensions.GetService<MySqlConnection>(provider);
        return func(service);
    }
}

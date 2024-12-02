using System.Data;
using Dapper;

namespace WebApp.Models;

public class MemberRepository : BaseRepository
{
    public MemberRepository(IDbConnection connection) : base(connection)
    {
    }

    public int Delete(string id){
        string sql="DELETE FROM Member WHERE MemberId = @Id";
        return connection.Execute(sql, new{id});

    }
    public int UpdateRole(string id, string role){
        string sql = "UPDATE Member SET Role = @Role WHERE MemberId = @Id";
        return connection.Execute(sql, new{role, id});
    }

    public Member? GetMember(string id ){
        string sql = "SELECT * FROM Member WHERE MemberId = @Id";
        return connection.QuerySingleOrDefault<Member>(sql, new {id});
    }
    public int Add(Member obj){
        if(string.IsNullOrEmpty(obj.Role)){
            obj.Role = Role.Customer.ToString();
        }
        return connection.Execute("AddMember", obj , commandType: CommandType.StoredProcedure);

    }
    public Member? Login(LoginModel obj){
        string sql = "SELECT * FROM Member WHERE Email = @Eml AND Password = @Pwd";
        return connection.QuerySingleOrDefault<Member>(sql, new {obj.Eml, obj.Pwd});
    }

    public IEnumerable<Member> GetMembers(){
        return connection.Query<Member>("SELECT * FROM Member");
    }
    public string? GenerateToken(string email){
        string token = Guid.NewGuid().ToString().Replace("-", string.Empty);
        string sql = "UPDATE Member SET Token = @Token WHERE Email =@Email";
        int ret = connection.Execute(sql, new{token, email});
        if(ret > 0){
            return token;
        }
        return null;
    }
    public int ChangePassword(string password, string token){
        string sql = "UPDATE Member SET Password = @Password WHERE Token = @Token ";
        return connection.Execute(sql, new{password, token});
    }
}
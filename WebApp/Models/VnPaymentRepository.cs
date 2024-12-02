using System.Data;
using Dapper;

namespace WebApp.Models;

public class VnPaymentRepository: BaseRepository
{
    public VnPaymentRepository(IDbConnection connection): base(connection)
    {
    }

    public int Add(VnPaymentReponse obj){
        return connection.Execute("AddVnPayment", obj,  commandType: CommandType.StoredProcedure);
    }
}
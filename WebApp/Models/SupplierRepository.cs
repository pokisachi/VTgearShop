using System.Data;
using Dapper;

namespace WebApp.Models;

public class SupplierRepository: BaseRepository
{
     public SupplierRepository(IDbConnection connection): base(connection)
    {
    }

     public IEnumerable<Supplier> GetSuppliers(){
        return connection.Query<Supplier>("SELECT * FROM Supplier");
    }
        public Supplier? GetSupplier(string id){
        string sql = "SELECT * FROM Supplier WHERE Email = @Id";
        return connection.QuerySingleOrDefault<Supplier>(sql, new{id});
    }
   

}
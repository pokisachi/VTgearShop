using System.Data;
using Dapper;

namespace WebApp.Models;

public class InvoiceRepository:BaseRepository
{
     public InvoiceRepository(IDbConnection connection): base(connection)
    {
    }
    
    public IEnumerable<SalesByAge> GetSalesByAges(){
        return connection.Query<SalesByAge>("GetSalesByAge", commandType: CommandType.StoredProcedure);
    }
    public int Add(Invoice obj){
        return connection.Execute("AddInvoice", new{
            obj.CartCode,
            obj.InvoiceId,
            obj.InvoiceDate,
            obj.Fullname,
            obj.Email,
            obj.Phone,
            obj.Address},
        commandType: CommandType.StoredProcedure);
    }
    public decimal GetAmountInvoice(long id){
        return connection.ExecuteScalar<decimal>("GetAmountInvoice", new{InvoiceId = id},
          commandType: CommandType.StoredProcedure);
    }

    
     public IEnumerable<Invoice> GetInvoices(){
        return connection.Query<Invoice>("SELECT * FROM Invoice");

    }
     public Invoice? GetInvoice(long id){
        string sql ="SELECT * FROM Invoice Where InvoiceId = @Id";
        return connection.QuerySingleOrDefault<Invoice>(sql, new{id});
        
    }
    

   
    

        public int Delete(long id){
        string sql="DELETE FROM Invoice WHERE InvoiceId = @Id";
        return connection.Execute(sql, new{id});

    }


        public int Edit(Invoice obj)
    {

        {
            string sql = @"
                UPDATE Invoice
                SET 
                    InvoiceDate = @InvoiceDate,
                    Fullname = @Fullname,
                    Email = @Email,
                    Phone = @Phone,
                    Address = @Address
                WHERE 
                    InvoiceId = @InvoiceId";

            int rowsAffected = connection.Execute(sql, obj);
            return rowsAffected;
        }
    }

    internal int Delete(string id)
    {
        throw new NotImplementedException();
    }
}
using System.Data;
using Dapper;

namespace WebApp.Models;

public class ProductRepository:BaseRepository
{
    public ProductRepository(IDbConnection connection): base(connection)
    {
    }

    public IEnumerable<Product> GetProducts(){
        return connection.Query<Product>("SELECT * FROM Product");
    }
  
   public IEnumerable<Product> GetProductsByCategory(short id){
        string sql = "SELECT * FROM Product WHERE Categoryid = @Id";
        return connection.Query<Product>(sql, new{id});
    }
    public Product? GetProduct(int id){
        string sql = "SELECT * FROM Product WHERE ProductId = @Id";
        return connection.QuerySingleOrDefault<Product>(sql, new {id});
    }

     public IEnumerable<Product> GetProductsRelation(short categoryid, int id){
        string sql = "SELECT * FROM Product WHERE CategoryId = @CategoryId AND ProductId<>@id";
        return connection.Query<Product>(sql, new{categoryid, id});
    }

    public IEnumerable<Product> SearchProducts(string keyword)
    {
        string sql = "SELECT * FROM Product WHERE ProductName LIKE @Keyword OR Description LIKE @Keyword";
        return connection.Query<Product>(sql, new { Keyword = $"%{keyword}%" });
    }

    public void AddProduct(Product product){
        string sql = @"
            INSERT INTO Product (ProductName, ProductAlias, CategoryId, Unit, Price, Image, ProductDate, SaleOff, Viewed, Description, SupplierId)
            VALUES (@ProductName, @ProductAlias, @CategoryId, @Unit, @Price, @Image, @ProductDate, @SaleOff, @Viewed, @Description, @SupplierId)";
        
        connection.Execute(sql, product);
    }

    public bool DeleteProduct(int id){
        string sql = "DELETE FROM Product WHERE ProductId = @Id";
        int rowsAffected = connection.Execute(sql, new { Id = id });
        return rowsAffected > 0;
    }

    public bool UpdateProduct(Product product){
        string sql = @"
            UPDATE Product 
            SET 
                ProductName = @ProductName,
                ProductAlias = @ProductAlias,
                CategoryId = @CategoryId,
                Price = @Price,
                Image = @Image,
                ProductDate = @ProductDate,
                SaleOff = @SaleOff,
                Viewed = @Viewed,
                Description = @Description,
                SupplierId = @SupplierId
            WHERE ProductId = @ProductId";
        int rowsAffected = connection.Execute(sql, product);
        return rowsAffected > 0; // Trả về true nếu cập nhật thành công
    }
    public int Add(Product obj)
    {
        string sql = @"INSERT INTO Product 
            (ProductName, ProductAlias, CategoryId, Unit, Price, Image, ProductDate, SaleOff, Viewed, Description, SupplierId) 
            VALUES 
            (@ProductName, @ProductAlias, @CategoryId, @Unit, @Price, @Image, @ProductDate, @SaleOff, @Viewed, @Description, @SupplierId)";
        return connection.Execute(sql, obj);
    }



}
using System.Data;
using Dapper;

namespace WebApp.Models;

public class CategoryRepository:BaseRepository
{
       public CategoryRepository(IDbConnection connection): base(connection)
    {
    }
    public IEnumerable<Category>GetCategories(){
        return connection.Query<Category>("SELECT * FROM Category");
    }
    public Category? GetCategory(short id){
        string sql = "SELECT * FROM Category WHERE CategoryId = @id";
        return connection.QuerySingleOrDefault<Category>(sql, new{id});
    }
    public IEnumerable<CategoryProduct> GetCategoryAndProducts(){
        return connection.Query<CategoryProduct>("GetCategoryAndProducts",
            commandType: CommandType.StoredProcedure);
    }

    public void AddCategory(Category category){
    string sql = "INSERT INTO Category (CategoryName, CategoryAlias, Description, ImageUrl) VALUES (@CategoryName, @CategoryAlias, @Description, @ImageUrl)";
    connection.Execute(sql, category);
    }

    public int UpdateCategory(Category obj){
        {
            string sql = "UPDATE Category SET CategoryName = @CategoryName, CategoryAlias = @CategoryAlias, Description = @Description, ImageUrl = @ImageUrl WHERE CategoryId = @CategoryId";
            int rowsAffected = connection.Execute(sql, obj);
            return rowsAffected;
        }
    }

public void DeleteCategory(short id){
    string sql = "DELETE FROM Category WHERE CategoryId = @id";
    connection.Execute(sql, new { id });
    }
}
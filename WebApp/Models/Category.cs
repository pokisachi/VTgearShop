namespace WebApp.Models;

public class Category
{
    public short CategoryId{get; set;}
    public string? CategoryName{get; set;}
    public string? CategoryAlias{get; set;}
    public string? Description{get; set;}
    public string? ImageUrl{get; set;}
}

// [CategoryId] SMALLINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
// 	[CategoryName] [nvarchar](64) NOT NULL,
// 	[CategoryAlias] [nvarchar](64) NULL,
// 	[Description] [nvarchar](max) NULL,
// 	[ImageUrl] [nvarchar](32) NULL
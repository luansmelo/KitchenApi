namespace Kitchen.Infra.Queries;

public static class CategoryQueries
{
    public static string AddCategoryQuery => @"INSERT INTO category VALUES(@Name) RETURNING id, name;";
    public static string DeleteByIdQuery => @"DELETE FROM category WHERE id = @Id;";
    public static string GetByIdQuery => @"SELECT id FROM category WHERE id = @Id;";
    public static string GetByNameQuery => @"SELECT name FROM category WHERE name = @Name;";
    public static string UpdateByIdQuery => @"UPDATE category SET name = @Name WHERE id = @Id;";
    public static string GetAllQuery => @"SELECT * FROM category ORDER BY name LIMIT @PageSize OFFSET @OffSet;";
    public static string GetCountQuery => @"SELECT COUNT(*) FROM category;";
}
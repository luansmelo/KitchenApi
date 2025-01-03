namespace Kitchen.Infra.Queries;

public static class CategoryQueries
{
    public static string AddCategoryQuery => $"INSERT INTO category (name) VALUES (@Name) RETURNING id, name;";
    public static string DeleteByIdQuery => $"DELETE FROM category WHERE id = @Id;";
    public static string GetByIdQuery => $"SELECT * FROM category WHERE id = @Id;";
    public static string GetByNameQuery => $"SELECT * FROM category WHERE name = @Name;";
    public static string UpdateByIdQuery => $"UPDATE category SET name = @Name WHERE id = @Id;";

    public static string GetAllQuery(string order)
    {
        order = order.ToUpper();
        if (order != "ASC" && order != "DESC")
        {
            order = "ASC";
        }
        
        return $"SELECT * FROM category ORDER BY name {order} LIMIT @PageSize OFFSET @OffSet;";
    }
    public static string GetCountQuery => $"SELECT COUNT(*) FROM category;";
}
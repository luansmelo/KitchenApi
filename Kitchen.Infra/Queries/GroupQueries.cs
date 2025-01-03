namespace Kitchen.Infra.Queries;

public static class GroupQueries
{
    public static string AddGroupQuery => $"INSERT INTO \"group\" (name) VALUES (@Name) RETURNING id, name;";
    public static string DeleteByIdQuery => $"DELETE FROM \"group\" WHERE id = @Id;";
    public static string GetByIdQuery => $"SELECT * FROM \"group\" WHERE id = @Id;";
    public static string GetByNameQuery => $"SELECT * FROM \"group\" WHERE name = @Name;";
    public static string UpdateByIdQuery => $"UPDATE \"group\" SET name = @Name WHERE id = @Id;";

    public static string GetAllQuery(string order)
    {
        order = order.ToUpper();
        if (order != "ASC" && order != "DESC")
        {
            order = "ASC";
        }
        
        return $"SELECT * FROM \"group\" ORDER BY name {order} LIMIT @PageSize OFFSET @OffSet;";
    }
    public static string GetCountQuery => $"SELECT COUNT(*) FROM \"group\";";
}
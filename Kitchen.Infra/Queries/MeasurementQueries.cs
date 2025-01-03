namespace Kitchen.Infra.Queries;

public static class MeasurementQueries
{
    public static string AddMeasurementQuery => $"INSERT INTO measurement (name) VALUES (@Name) RETURNING id, name;";
    public static string DeleteByIdQuery => $"DELETE FROM measurement WHERE id = @Id;";
    public static string GetByIdQuery => $"SELECT * FROM measurement WHERE id = @Id;";
    public static string GetByNameQuery => $"SELECT * FROM measurement WHERE name = @Name;";
    public static string UpdateByIdQuery => $"UPDATE measurement SET name = @Name WHERE id = @Id;";

    public static string GetAllQuery(string order)
    {
        order = order.ToUpper();
        if (order != "ASC" && order != "DESC")
        {
            order = "ASC";
        }
        
        return $"SELECT * FROM measurement ORDER BY name {order} LIMIT @PageSize OFFSET @OffSet;";
    }
    public static string GetCountQuery => $"SELECT COUNT(*) FROM measurement;";
}
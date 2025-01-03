using System.Data;

namespace Kitchen.Infra.Context;

public interface IDbContext
{
    IDbConnection Connection();
}
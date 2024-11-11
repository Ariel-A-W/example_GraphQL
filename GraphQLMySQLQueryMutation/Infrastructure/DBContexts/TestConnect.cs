using Microsoft.EntityFrameworkCore;

namespace GraphQLMySQLQueryMutation.Infrastructure.DBContexts;

public class TestConnect
{
    private readonly DbContext _context;

    public TestConnect(AppDbContext context)
    {
        _context = context;
    }

    public bool IsConnected()
    {
        bool isConnected = _context.Database.CanConnect();
        if (isConnected)
        {
            //Console.WriteLine("MySQL connection successful");
            System.Diagnostics.Debug.WriteLine("Successfully Connected!");
            return true;
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Not Connected!");
            return false;
        }
    }
}

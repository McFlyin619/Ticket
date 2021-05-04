using Microsoft.EntityFrameworkCore;

/*
    this class will handle the connection to DB
    help to create/register/update/delete CRUD entries
    for the models that you specify

    if something changes in your models, run migration to sync models <--> db
    - dotnet ef migrations add <somename>
    - dotnet ef database update
*/
public class DataContext : DbContext
{
    // class constructor recieves connection information (where the server is, user, pass)
    // and pass it to the parent DbContext
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    // specify which of your models will represent a table in the DB
    public DbSet<ServiceTicket> ServiceTickets { get; set; }

}
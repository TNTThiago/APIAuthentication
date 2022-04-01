using Infra.Repositories.Interfaces;
using Infra.Context;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class UserRepository : IUserRepository
{

    private readonly DatabaseContext _databaseContext;
    private DbSet<User> entity;

    public UserRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        entity = _databaseContext.Set<User>();
    }
//Sempre que o metodo Create for invocado
//Ele cria e salva um usuario no banco de dados
    public void Create(User user)
    {
        entity.Add(user);//duvida
        _databaseContext.SaveChanges();
    }

    public User? FindByUsername(string username)
    {
        var user = entity.SingleOrDefault(u => u.username == username);
        return user;
    }
    public void SaveChanges()
    {
        _databaseContext.SaveChanges();
    }
}
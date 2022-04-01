using Model;
using Service.Validations;

namespace Service.Interfaces;

public interface IUserServiceCollection
{
    // Registro de Usuário
    User SignUp(ValidateUserProps props);
    // Login do Usuário
    string SignIn(ValidateUserSignIn props);

    //Encontrar usuario pelo Username

    User? FindUserByUsername(string username);
}
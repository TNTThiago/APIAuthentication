using Flunt.Notifications;
using Flunt.Validations;
using API.Errors;

namespace Service.Validations;

public class ValidateUserSignIn : Notifiable<Notification>
{
   public string username { get; init; } = default!;
   public string password { get; init; } = default!;

   public void Mapto()
    {
        var contract = new Contract<Notification>()
        .Requires()
        .IsNotNullOrEmpty(username, "Informe um login válido.")
        .IsGreaterThan(username, 4, "Login dever ter no mínimo 5 dígitos." )
        .IsNotNullOrEmpty(password, "Informe um password válido.")
        .IsGreaterThan(password, 7, "Login dever ter no mínimo 8 dígitos." );

        AddNotifications(contract);

    }
    public void Validate()
    {
        Mapto();

        if (!IsValid)
        {
            var message = Notifications.First().Key;
            throw new AppError("Mensagem", 400);
        }
    }
}
using Service.Interfaces;
using Service.Validations;
using API.Errors;

namespace API.Routes;

public static class AppRoutes
{
    public static void ConfigureRoutes(this WebApplication app)
    {
        app.MapPost("/sign-up", SignUp);
        app.MapPost("/sign-in", SignIn);
    }
    private static IResult SignUp(IUserServiceCollection userService, ValidateUserProps userProps)
    {
       try
        {
            var user = userService.SignUp(userProps);
            return Results.Ok(user);
        }
        catch (AppError ex)
        {
            return Results.Problem(statusCode: ex.statusCode, detail: ex.message);
        }
        catch
        {
            return Results.Problem(statusCode:500, detail: "Internal Server Error");
        } 
    }
    private static IResult SignIn(IUserServiceCollection userService, ValidateUserSignIn userProps)
    {
        try
        {
            var token = userService.SignIn(userProps);
            return Results.Ok(token);
        }
        catch (AppError ex)
        {
            return Results.Problem(statusCode: ex.statusCode, detail: ex.message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Results.Problem(statusCode: 500, detail: "Internal Server Error");
        }
    }
}
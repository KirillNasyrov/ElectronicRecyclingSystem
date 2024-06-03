using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicRecyclingSystem.Controllers.Users;

[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("login")]
    public async Task Login(
        HttpContext context,
        CancellationToken cancellationToken)
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        // html-форма для ввода логина/пароля
        string loginForm = @"<!DOCTYPE html>
        <html>
            <head>
            <meta charset='utf-8' />
            <title>METANIT.COM</title>
        </head>
        <body>
            <h2>Login Form</h2>
            <form method='post'>
                <p>
                    <label>Email</label><br />
                    <input name='email' />
                </p>
                <p>
                    <label>Password</label><br />
                    <input type='password' name='password' />
                </p>
                <input type='submit' value='Login' />
            </form>
            </body>
        </html>";
        await context.Response.WriteAsync(loginForm);
    }
    
    [HttpPost("login")]
    public async Task<IResult> LoginPost(
        HttpContext context,
        CancellationToken cancellationToken)
    {
        // получаем из формы email и пароль
        var form = context.Request.Form;
        // если email и/или пароль не установлены, посылаем статусный код ошибки 400
        if (!form.ContainsKey("email") || !form.ContainsKey("password"))
            return Results.BadRequest("Email и/или пароль не установлены");
 
        string email = form["email"]!;
        string password = form["password"]!;
     
        // находим пользователя 
        User? person = people.FirstOrDefault(p => p.Email == email && p.Password == password);
        // если пользователь не найден, отправляем статусный код 401
        if (person is null) return Results.Unauthorized();
 
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
        // создаем объект ClaimsIdentity
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        // установка аутентификационных куки
        await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        return Results.Redirect(returnUrl??"/");
    }
}
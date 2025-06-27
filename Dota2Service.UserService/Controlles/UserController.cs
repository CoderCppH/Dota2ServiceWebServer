using Dota2Service.Context;
using Dota2Service.Model;
using Dota2Service.UserService.Dto;
using Dota2Service.UserService.Hash;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dota2Service.UserService.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(AppDbContextDota2Service dbContext) : ControllerBase
    {

        [HttpGet]
        public Task<List<Model.UserModel>> GetListUser() => dbContext.Users.ToListAsync();
        [HttpGet("{id:int}")]
        public async Task<ActionResult> InfoUser(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                return NotFound("User not found");
            return Ok(user);
        }
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(UserModel? user)
        {
            if (user is null)
                return BadRequest("user nullable");

            string PaaswordHash = PasswordHash.EncryptorPassword(user.Password, PasswordHash.GeneratorSlat());
            user.Password = PaaswordHash;
            if (await dbContext.Users.AnyAsync(u => u.Email != user.Email || u.Phone != user.Phone))
            {
                user.Token = Token.TokenGenerator.GenerateToken();
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
                return Ok(new { result = "успешно создан новый пользователь", Token = user.Token ?? "not found" });

            }
            else
                return BadRequest("такой пользователь уже найден");
        }
        [HttpPost("login")]
        public async Task<ActionResult> LoginUser(UserModelDto? user)
        {
            if (user is null)
                return BadRequest("User data is required");

            // Ищем пользователя только по email или телефону
            UserModel? fuser = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == user.Email || u.Phone == user.Phone);

            if (fuser == null)
                return NotFound("User not found");

            // Проверяем пароль уже в памяти
            if (!PasswordHash.VerifyPassword(user.Password, fuser.Password))
                return Unauthorized("Invalid password");

            // Генерация токена и возврат результата
            return Ok(new
            {
                result = "Authentication successful",
                user = fuser,
                Token = fuser.Token
            });
        }
    }
}

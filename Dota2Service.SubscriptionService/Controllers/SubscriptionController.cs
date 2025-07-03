using Dota2Service.Context;
using Dota2Service.Model;
using Dota2Service.SubscriptionService.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dota2Service.SubscriptionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController(AppDbContextDota2Service dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetListSubscription() => Ok(await dbContext.Subscriptions.ToListAsync());
        [HttpPost]
        public async Task<ActionResult> CreateSubscription(SubscriptionModelDto? subscription) 
        {
            bool isAdminRoot = await dbContext.Users.AnyAsync(a => a.Token == subscription.AdminToken);
            if (!isAdminRoot)
                return Unauthorized("admin not fount or not access");
            DateTime start = DateTime.UtcNow;
            DateTime end = start.AddDays(subscription.DaysSubscription);
            SubscriptionModel subs = new SubscriptionModel
            {
                Token = UserService.Token.TokenGenerator.GenerateToken(),
                UserId = subscription.IdUser,
                DateStartSubscription = start,
                DateFinishSubscription = end,
            };

            await dbContext.Subscriptions.AddAsync(subs);
            await dbContext.SaveChangesAsync();
            return Ok(new { status = "success creates subscription" , subscription = subs });

        }
        [HttpPost("check")]
        public async Task<ActionResult> CheckSubscription(string? Token) 
        {
            SubscriptionModel? subs = await dbContext.Subscriptions.FirstOrDefaultAsync(s => s.Token == Token);
            if (subs is null)
                return NotFound("Subscription token not found");
            DateTime start = subs.DateStartSubscription;
            DateTime end = subs.DateFinishSubscription;
            bool checkSubscriptionLastDayes = start > end;
            if (checkSubscriptionLastDayes)
                return StatusCode(403, new { Message = "Your subscription has expired. Please renew." });
                
            return Ok(new { status = "success", dayesLast = subs.DateFinishSubscription.ToString()});
        }
    }
}

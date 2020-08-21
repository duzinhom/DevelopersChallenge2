using Microsoft.AspNetCore.Mvc;
using NiboChallenge.Data;
using NiboChallenge.Helpers;
using NiboChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NiboChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConciliationController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<List<Transaction>>> Post(
            [FromServices] TransactionContext context,
            [FromBody] string[] files
            )
        {
            ConciliationHelper helper = new ConciliationHelper();
            var changes = helper.Conciliation(files);

            context.Transactions.AddRange(changes);
            await context.SaveChangesAsync();

            return changes;
        }
    }
}


using FlipBuddy.Application.Abstraction;
using FlipBuddy.Application.Requests.EbayRequests.ListFixedPricedItem;
using Microsoft.AspNetCore.Mvc;

namespace FlipBuddyAPI.Controllers
{

    [ApiController]
    public class EbayController : BaseController
    {
        public EbayController(IOrchestrator orchestrator) : base(orchestrator)
        {
        }

        [HttpPost("EbayController/ListItemFromInventory")]
        public async Task ListItemToEbay(ListFixedPricedItemRequest request) => await _orchestrator.GetRequestResponseAsync(request);

    }
}


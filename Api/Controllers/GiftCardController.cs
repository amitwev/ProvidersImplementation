using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
public class GiftCardController(IGiftCardService giftCardService) : ControllerBase
{
    [HttpPost("validate")]
    public async Task<IActionResult> ValidateGiftCard(CoreApiRequest request)
    {
        var model = request.ToValidateGiftCardRequestModel();
        var response = await giftCardService.ValidateGiftCardAsync(model); 
        return Ok(response);
    }
}
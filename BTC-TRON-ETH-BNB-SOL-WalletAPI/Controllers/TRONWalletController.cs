using BTC_TRON_ETH_BNB_SOL_WalletAPI.Serivces.WalletServices;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BTC_TRON_ETH_BNB_SOL_WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRONWalletController : ControllerBase
    {
        private readonly TronWalletServices _tronWalletServices;

        public TRONWalletController(TronWalletServices tronWalletServices)
        {
            _tronWalletServices = tronWalletServices;
        }

        [HttpGet("TRON-WALLET")]
        public async Task<IActionResult> TronWallet()
        {
            try
            {
                var result = await _tronWalletServices.GetTronWalletAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("TRON-WALLET-DOWNLOAD")]
        public async Task<IActionResult> DownloadWallet()
        {
            var content = await _tronWalletServices.GetTronWalletAsync();

            var bytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(bytes);

            return File(stream, "text/plain", "tron_wallet.txt"); 
        }
    }
}

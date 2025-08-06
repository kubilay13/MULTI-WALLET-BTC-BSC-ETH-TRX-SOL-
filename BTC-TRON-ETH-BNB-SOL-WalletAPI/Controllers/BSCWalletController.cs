using BTC_TRON_ETH_BNB_SOL_WalletAPI.Serivces.WalletServices;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BTC_TRON_ETH_BNB_SOL_WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BSCWalletController : ControllerBase
    {
        private readonly BSCWalletServices _bscWalletService;

        public BSCWalletController(BSCWalletServices bSCWalletServices)
        {
            _bscWalletService = bSCWalletServices;
        }

        [HttpGet("BSC-WALLET")]
        public async Task<IActionResult> BscWallet()
        { 
          var result = await _bscWalletService.GetBnbWalletAsync();
            return Ok(result);

        }

        [HttpGet("BSC-WALLET-DOWNLOAD")]
        public async Task<IActionResult> DownloadBscWallet()
        {
            var content = await _bscWalletService.GetBnbWalletAsync();
            var bytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(bytes);

            return File(stream, "text/plain", "bnb_wallet.txt");
        }
    }
}

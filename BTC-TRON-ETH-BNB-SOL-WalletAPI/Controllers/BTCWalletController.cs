using BTC_TRON_ETH_BNB_SOL_WalletAPI.Serivces.WalletServices;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BTC_TRON_ETH_BNB_SOL_WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BTCWalletController : ControllerBase
    {
        private readonly BTCWalletServices _bitcoinWalletServices;

        public BTCWalletController(BTCWalletServices bitcoinWalletServices)
        {
            _bitcoinWalletServices = bitcoinWalletServices;
        }
        [HttpGet("BTC-WALLET")]
        public async Task<IActionResult> CreateWallet()
        { 
          var result = await _bitcoinWalletServices.GenerateBitcoinWalletAsync();
            return Ok(result);
        }

        [HttpGet("BTC-DOWNLOAD-WALLET")]
        public async Task<IActionResult> DownloadWallet()
        {
            var content = await _bitcoinWalletServices.GenerateBitcoinWalletAsync();
            var bytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(bytes);

            return File(stream, "text/plain", "bitcoin_wallet.txt");
        }
    }
}

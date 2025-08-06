using BTC_TRON_ETH_BNB_SOL_WalletAPI.Serivces.WalletServices;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BTC_TRON_ETH_BNB_SOL_WalletAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ETHWalletController : ControllerBase
    {
        private readonly ETHWalletServices _eTHWalletService;

        public ETHWalletController(ETHWalletServices eTHWalletServices)
        {
            _eTHWalletService= eTHWalletServices;
        }


        [HttpGet("ETH-WALLET")]
        public async Task<IActionResult> CreateEthWallet()
        {
            var result = await _eTHWalletService.GetEthWalletAsync();
            return Ok(result); // JSON formatında döner
        }


        [HttpGet("ETH-WALLET-DOWNLOAD")]
        public async Task<IActionResult> DownloadEthWallet()
        {
            var content = await _eTHWalletService.GetEthWalletAsync();
            var bytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(bytes);

            return File(stream, "text/plain", "eth_wallet.txt"); // .txt dosyası iner
        }
    }
}

using BTC_TRON_ETH_BNB_SOL_WalletAPI.Serivces.WalletServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BTC_TRON_ETH_BNB_SOL_WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SOLWalletController : ControllerBase
    {
        private readonly SOLWalletServices _solanaWalletServices;

        public SOLWalletController(SOLWalletServices sOLWalletServices)
        {
            _solanaWalletServices = sOLWalletServices;
        }
        [HttpGet("SOL-WALLET")]
        public async Task<IActionResult> CreateWallet()
        {
            var result = await _solanaWalletServices.GetSolanaWalletTextAsync();
            return Ok(result); // JSON formatında döner
        }

        [HttpGet("SOL-WALLET-DOWNLOAD")]
        public async Task<IActionResult> DownloadWallet()
        {
            var content = await _solanaWalletServices.GetSolanaWalletTextAsync();
            var bytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(bytes);

            return File(stream, "text/plain", "solana_wallet.txt");
        }
    }
}

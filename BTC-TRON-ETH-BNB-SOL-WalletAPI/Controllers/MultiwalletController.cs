using BTC_TRON_ETH_BNB_SOL_WalletAPI.Serivces.WalletServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BTC_TRON_ETH_BNB_SOL_WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiwalletController : ControllerBase
    {
        private readonly BTCWalletServices _bTCWalletServices;
        private readonly TronWalletServices _tronWalletServices;
        private readonly ETHWalletServices _eTHWalletServices;
        private readonly BSCWalletServices _bSCWalletServices;
        private readonly SOLWalletServices _sOLWalletServices;

        public MultiwalletController(BTCWalletServices bTCWalletServices,TronWalletServices tronWalletServices,ETHWalletServices eTHWalletServices,BSCWalletServices bSCWalletServices,SOLWalletServices sOLWalletServices)
        {
            _bTCWalletServices = bTCWalletServices;
            _tronWalletServices = tronWalletServices;
            _eTHWalletServices = eTHWalletServices;
            _bSCWalletServices = bSCWalletServices;
            _sOLWalletServices = sOLWalletServices;
        }


        [HttpPost("download-wallet")]
        public async Task<IActionResult> DownloadWallet()
        {
            // Her ağı oluştur
            var tron = await _tronWalletServices.GetTronWalletAsync();
            var sol = await _sOLWalletServices.GetSolanaWalletTextAsync();
            var btc = await _bTCWalletServices.GenerateBitcoinWalletAsync();
            var eth = await _eTHWalletServices.GetEthWalletAsync();
            var bnb = await _bSCWalletServices.GetBnbWalletAsync();
            // Hepsini birleştir
            var fullContent = new StringBuilder();
            fullContent.AppendLine("=== TRON ===\n" + tron);
            fullContent.AppendLine("\n=== SOLANA ===\n" + sol);
            fullContent.AppendLine("\n=== BITCOIN ===\n" + btc);
            fullContent.AppendLine("\n=== ETHEREUM ===\n" + eth);
            fullContent.AppendLine("\n=== BNB ===\n" + bnb);

            var bytes = Encoding.UTF8.GetBytes(fullContent.ToString());
            var fileName = $"multi_wallets_{DateTime.Now:yyyyMMddHHmmss}.txt";

            return File(bytes, "text/plain", fileName);
        }
    }
}

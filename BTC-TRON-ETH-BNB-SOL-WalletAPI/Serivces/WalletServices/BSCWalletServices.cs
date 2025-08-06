using Nethereum.Signer;

namespace BTC_TRON_ETH_BNB_SOL_WalletAPI.Serivces.WalletServices
{
    public class BSCWalletServices
    {
        public async Task<string> GetBnbWalletAsync()
        {
            var key = EthECKey.GenerateKey(); // Ethereum tarzı key üretir
            var privateKey = key.GetPrivateKey();
            var address = key.GetPublicAddress(); // 0x adres

            return $"Binance Smart Chain Wallet{Environment.NewLine}" +
                   $"Address: {address}{Environment.NewLine}" +
                   $"Private Key: {privateKey}";
        }
    }
}

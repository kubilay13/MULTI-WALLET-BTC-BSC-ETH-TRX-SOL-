using Nethereum.Signer;

namespace BTC_TRON_ETH_BNB_SOL_WalletAPI.Serivces.WalletServices
{
    public class ETHWalletServices
    {

        public async Task<string> GetEthWalletAsync()
        {
            var key = EthECKey.GenerateKey(); // Rastgele key
            var privateKey = key.GetPrivateKey(); // Hex format
            var address = key.GetPublicAddress(); // 0x.... formatında adres

            return $"Ethereum Wallet{Environment.NewLine}" +
                   $"Address: {address}{Environment.NewLine}" +
                   $"Private Key: {privateKey}";
        }
    }
}

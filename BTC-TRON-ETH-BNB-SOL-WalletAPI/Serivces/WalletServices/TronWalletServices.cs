using TronNet;

namespace BTC_TRON_ETH_BNB_SOL_WalletAPI.Serivces.WalletServices
{
    public class TronWalletServices
    {
        public async Task<string> GetTronWalletAsync()
        {
           var key =TronECKey.GenerateKey(TronNetwork.MainNet);
           var address = key.GetPublicAddress();
           var privatekey = key.GetPrivateKey();

            return $"Address: {address}{Environment.NewLine}Private Key: {privatekey}";

        }

    }
}

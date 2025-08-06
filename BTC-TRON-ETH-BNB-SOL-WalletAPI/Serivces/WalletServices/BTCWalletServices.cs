using NBitcoin;

namespace BTC_TRON_ETH_BNB_SOL_WalletAPI.Serivces.WalletServices
{
    public class BTCWalletServices
    {
        public async Task<string> GenerateBitcoinWalletAsync()
        {
            // Bitcoin ana ağı (MainNet) için key oluştur
            var key = new Key(); // rastgele private key
            var privateKey = key.GetWif(Network.Main); // WIF formatında private key
            var address = key.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main).ToString();

            return $"Bitcoin Wallet{System.Environment.NewLine}" +
                   $"Address: {address}{System.Environment.NewLine}" +
                   $"Private Key (WIF): {privateKey}";
        }
    }
}

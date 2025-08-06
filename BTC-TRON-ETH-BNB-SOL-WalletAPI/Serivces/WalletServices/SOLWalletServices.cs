using Solnet.Wallet;
using Solnet.Wallet.Utilities;

namespace BTC_TRON_ETH_BNB_SOL_WalletAPI.Serivces.WalletServices
{
    public class SOLWalletServices
    {
        public async Task<string> GetSolanaWalletTextAsync()
        {
            var account = new Account();

            var address = account.PublicKey;

            var privateKeyBytes = account.PrivateKey;

            // Base58 encoder örneği:
            var encoder = new Base58Encoder();
            var privateKeyBase58 = encoder.EncodeData(privateKeyBytes);

            return $"Solana Wallet{System.Environment.NewLine}" +
                   $"Address: {address}{System.Environment.NewLine}" +
                   $"Private Key (Base58): {privateKeyBase58}";
        }
    }
}

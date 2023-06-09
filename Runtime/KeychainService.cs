using System.Runtime.InteropServices;

namespace SecureSecretManager
{
    /// <summary>
    ///     <c>Assets/Plugins/iOS/KeychainService.mm</c>
    /// </summary>
    /// <remarks>
    ///     <a href="https://developer.apple.com/documentation/security/keychain_services">Keychain Services</a>
    /// </remarks>
    class KeychainService : ISecretManager
    {
#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern int addItem(string dataType, string value);

    [DllImport("__Internal")]
    private static extern string getItem(string dataType);

    [DllImport("__Internal")]
    private static extern int deleteItem(string dataType);
#endif

        // KeychainService.mm
        #region ISecretManager

        public bool Put(string key, string value)
        {
#if UNITY_IOS
        return addItem(key, value) == 0;
#else
            return false;
#endif
        }

        public string Get(string key)
        {
#if UNITY_IOS
        return getItem(key);
#else
            return null;
#endif
        }

        public bool Delete(string key)
        {
#if UNITY_IOS
        return deleteItem(key) == 0;
#else
            return false;
#endif
        }

        #endregion
    }
}
using System.Security.Cryptography;
using System.Text;

namespace ParcelDesk.WinForms.Configuration;

public static class MySqlSecretStore
{
    private static readonly string SettingsDirectory = Path.Combine(
                                                                    Environment.GetFolderPath(
                                                                            Environment.SpecialFolder.LocalApplicationData),
                                                                            "ParcelDesk");
    private static readonly string SecretPath = Path.Combine(SettingsDirectory,
                                                             "secure-db-config.dat");
    private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("ParcelDesk.MySql.Password.v1");

    public static void SavePassword(string password)
    {
        Directory.CreateDirectory(SettingsDirectory);
        var plainBytes = Encoding.UTF8.GetBytes(password);
        var encryptedBytes = ProtectedData.Protect(
                                                    plainBytes,
                                                    Entropy,
                                                    DataProtectionScope.CurrentUser);
        File.WriteAllBytes(SecretPath,
                           encryptedBytes);
    }

    public static string? LoadPassword()
    {
        if(!File.Exists(SecretPath))
        {
            return null;
        }
        try
        {
            var encryptedBytes = File.ReadAllBytes(SecretPath);
            var plainBytes = ProtectedData.Unprotect(
                                                    encryptedBytes,
                                                    Entropy,
                                                    DataProtectionScope.CurrentUser);

            return Encoding.UTF8.GetString(plainBytes);
        }
        catch(CryptographicException)
        {
            return null;
        }
        catch(IOException)
        {
            return null;
        }
    }
    public static void DeletePassword()
    {
        if(File.Exists(SecretPath))
        {
            File.Delete(SecretPath);
        }
    }
}
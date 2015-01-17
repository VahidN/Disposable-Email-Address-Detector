namespace DisposableEmailAddressDetector.Lib
{
    public interface IDisposableEmails
    {
        bool IsDisposableEmailAddress(string email, string nameApiKey);
    }
}
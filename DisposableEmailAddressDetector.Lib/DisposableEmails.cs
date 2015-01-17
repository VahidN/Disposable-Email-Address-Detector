using System;
using System.ServiceModel;
using DisposableEmailAddressDetector.Lib.DisposableEmailServiceReference;

namespace DisposableEmailAddressDetector.Lib
{
    public class DisposableEmails : IDisposableEmails
    {
        public bool IsDisposableEmailAddress(string email, string nameApiKey)
        {
            if (string.IsNullOrWhiteSpace(nameApiKey))
                throw new ArgumentNullException("nameApiKey");

            // http://www.nameapi.org/en/live-demos/disposable-email-address-detector/
            // http://www.nameapi.org/index.php?id=146
            // http://api.nameapi.org/soap/v4.0/email/disposableemailaddressdetector?wsdl

            var basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.None)
            {
                Name = "SoapDisposableEmailAddressDetectorPortBinding"
            };
            var endpointAddress =
                new EndpointAddress("http://api.nameapi.org:80/soap/v4.0/email/disposableemailaddressdetector");

            var client = new SoapDisposableEmailAddressDetectorClient(basicHttpBinding, endpointAddress);
            client.Endpoint.Behaviors.Add(new EndpointBehavior());

            var context = new soapContext
            {
                //Tip: get your API key here: http://www.nameapi.org/en/register/
                apiKey = nameApiKey
            };
            var result = client.isDisposable(context, email);

            return result.disposable.ToString().Equals("yes", StringComparison.OrdinalIgnoreCase);
        }
    }
}
using System.ServiceModel.Channels;
using System.Xml;

namespace DisposableEmailAddressDetector.Lib
{
    /// <summary>
    /// To customize WCF envelope and namespace prefix
    /// </summary>
    public class MyCustomMessage : Message
    {
        private readonly Message _message;

        public MyCustomMessage(Message message)
        {
            _message = message;
        }

        public override MessageHeaders Headers
        {
            get { return _message.Headers; }
        }

        public override MessageProperties Properties
        {
            get { return _message.Properties; }
        }

        public override MessageVersion Version
        {
            get { return _message.Version; }
        }

        protected override void OnWriteStartBody(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("Body", "http://schemas.xmlsoap.org/soap/envelope/");
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            _message.WriteBodyContents(writer);
        }

        protected override void OnWriteStartEnvelope(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("SOAP-ENV", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
            writer.WriteAttributeString("xmlns", "ns1", null, value: "http://disposableemailaddressdetector.email.services.v4_0.soap.server.nameapi.org/");
        }
    }
}
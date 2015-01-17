using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace DisposableEmailAddressDetector.Lib
{
    public class ClientMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        { }

        public object BeforeSendRequest(ref Message request, System.ServiceModel.IClientChannel channel)
        {
            request = new MyCustomMessage(request);
            return request;
        }
    }
}
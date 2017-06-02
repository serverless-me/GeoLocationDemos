using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.EventReceivers;

namespace GetGeolocationEventWeb.Services
{
    public class AppEventReceiver : IRemoteEventService
    {
        public SPRemoteEventResult ProcessEvent(SPRemoteEventProperties properties)
        {
            SPRemoteEventResult result = new SPRemoteEventResult();

            using (ClientContext clientContext = TokenHelper.CreateAppEventClientContext(properties, false))
            {
                if (clientContext != null)
                {
                    clientContext.Load(clientContext.Web);
                    clientContext.ExecuteQuery();
                    //List contactList = clientContext.Web.Lists.GetByTitle("GeoContacts");

                    //EventReceiverDefinitionCreationInformation eventReceiver = new EventReceiverDefinitionCreationInformation();
                    //eventReceiver.EventType = EventReceiverType.ItemAdding;
                    //eventReceiver.ReceiverAssembly = Assembly.GetExecutingAssembly().FullName;
                    //eventReceiver.ReceiverClass = "GetGeolocationEventReciever";
                    //eventReceiver.ReceiverName = "GetGeolocationEventReciever";
                    //eventReceiver.ReceiverUrl = "https://eichlereducation-fd47fd3b494c93.sharepoint.com/sites/geo/GetGeolocationEvent/";
                    //eventReceiver.SequenceNumber = 1000;

                    //contactList.EventReceivers.Add(eventReceiver);
                }
            }

            return result;
        }

        public void ProcessOneWayEvent(SPRemoteEventProperties properties)
        {
            // This method is not used by app events
        }
    }
}

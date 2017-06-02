using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.EventReceivers;
using System.Net;
using System.Xml;

namespace GetGeolocationEventWeb.Services
{
    public class GetGeolocationEventReciever : IRemoteEventService
    {
        public SPRemoteEventResult ProcessEvent(SPRemoteEventProperties properties)
        {
            SPRemoteEventResult result = new SPRemoteEventResult();

            using (ClientContext clientContext = TokenHelper.CreateRemoteEventReceiverClientContext(properties))
            {
                if (clientContext != null)
                {
                    clientContext.Load(clientContext.Web);
                    clientContext.ExecuteQuery();
                    
                    Guid listId = properties.ItemEventProperties.ListId;
                    string address = properties.ItemEventProperties.AfterProperties["WorkAddress"].ToString();
                    string zip = properties.ItemEventProperties.AfterProperties["WorkZip"].ToString();
                    string city = properties.ItemEventProperties.AfterProperties["WorkCity"].ToString();

                    string url = String.Format("http://dev.virtualearth.net/REST/v1/Locations/DE/{0}/{1}/{2}?output=xml&key=ApR-rWCt0ui9PDJGXDuBYOw1tGm4N36w6Sc3-u0qgOQA45zzrF8tm6QrtPNg6flJ", zip, city, address);

                    WebClient serviceRequest = new WebClient();
                    string response = serviceRequest.DownloadString(new Uri(url));
                    XmlDocument xmlresponse = new XmlDocument();
                    xmlresponse.LoadXml(response);
                    string latitude = xmlresponse.GetElementsByTagName("Point")[0].FirstChild.InnerText;
                    string longitude = xmlresponse.GetElementsByTagName("Point")[0].LastChild.InnerText;

                    string txtPoint = string.Format("Point ({0} {1})", longitude, latitude);
                    result.ChangedItemProperties.Add("Geolocation", txtPoint);


                }
            }

            return result;
        }

        public void ProcessOneWayEvent(SPRemoteEventProperties properties)
        {
        }
    }
}

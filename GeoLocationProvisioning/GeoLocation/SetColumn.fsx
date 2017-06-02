#r @"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\15\ISAPI\Microsoft.SharePoint.Client.dll"
#r @"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\15\ISAPI\Microsoft.SharePoint.Client.Runtime.dll"

open Microsoft.SharePoint.Client
open Microsoft.SharePoint.Client.Application    

let ctx = new ClientContext("https://serverless-me.sharepoint.com/sites/geo/")

let load(item:'a) = 
    ctx.Load(item)
    ctx.ExecuteQuery()

let listName = "Contacts"

let spList = ctx.Web.Lists.GetByTitle(listName)
load spList
spList.Fields.AddFieldAsXml("<Field Type='Geolocation' DisplayName='Geolocation'/>", true, AddFieldOptions.AddToAllContentTypes);
spList.Update()
ctx.ExecuteQuery()

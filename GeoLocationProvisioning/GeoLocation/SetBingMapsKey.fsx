#r @"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\15\ISAPI\Microsoft.SharePoint.Client.dll"
#r @"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\15\ISAPI\Microsoft.SharePoint.Client.Runtime.dll"

open Microsoft.SharePoint.Client
open Microsoft.SharePoint.Client.Application    

let ctx = new ClientContext("https://serverless-me.sharepoint.com/sites/geo/GetGeolocationEvent")

let load(item:'a) = 
    ctx.Load(item)
    ctx.ExecuteQuery()

let web = ctx.Web
web.AllProperties.["BING_MAPS_KEY"] <- "YOURKEY"
web.Update()
ctx.ExecuteQuery()

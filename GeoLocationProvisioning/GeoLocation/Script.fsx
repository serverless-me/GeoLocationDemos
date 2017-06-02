#r @"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\15\ISAPI\Microsoft.SharePoint.Client.dll"
#r @"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\15\ISAPI\Microsoft.SharePoint.Client.Runtime.dll"

open Microsoft.SharePoint.Client
open Microsoft.SharePoint.Client.Application
open System.Security;

let ctx = new ClientContext("https://serverless-me.sharepoint.com/sites/geo/GetGeolocationEvent/")

let load(item:'a) = 
    ctx.Load(item)
    ctx.ExecuteQuery()


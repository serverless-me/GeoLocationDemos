ExecuteOrDelayUntilBodyLoaded(GetMap);
ExecuteOrDelayUntilScriptLoaded(addContactsToMap, "SP.js");
var map = null;

function GetMap() {
    map = new Microsoft.Maps.Map(
        document.getElementById("myMap"),
        { credentials: "ApR-rWCt0ui9PDJGXDuBYOw1tGm4N36w6Sc3-u0qgOQA45zzrF8tm6QrtPNg6flJ" }
    );

    var geoLocationProvider = new Microsoft.Maps.GeoLocationProvider(map, null);
    geoLocationProvider.getCurrentPosition({ showAccuracyCircle: false }); 

    map.entities.clear();

}

function addContactsToMap() {
    var context = new SP.ClientContext.get_current();
    var camlQuery = new SP.CamlQuery.createAllItemsQuery();
    var EngList = context.get_web().get_lists().getByTitle("GeoContacts");
    this.listItemCol = EngList.getItems(camlQuery);

    context.load(listItemCol, 'Include(Id, Title, Geolocation)');

    context.executeQueryAsync(Function.createDelegate(this, this.onSuccess), Function.createDelegate(this, this.onFailure));

}

function onSuccess(sender, args) {

    var itemEnumerator = listItemCol.getEnumerator();
    while (itemEnumerator.moveNext()) {
        var listItem = itemEnumerator.get_current();
        this.itemLocation = listItem.get_fieldValues()["Geolocation"];

        var pushpin = new Microsoft.Maps.Pushpin(map.getCenter(), { draggable: false });
        map.entities.push(pushpin);
        pushpin.setLocation(new Microsoft.Maps.Location(this.itemLocation.get_latitude(), this.itemLocation.get_longitude()));

    }
    map.setView({ zoom: 10 });
}

function onFailure(sender, args) {
    alert("Request failed " + args.get_message());
}
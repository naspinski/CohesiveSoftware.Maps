# CohesiveSoftware.Maps
.NET Core implementation of Google Maps API for retireiving map information into a simple POCO.

## Usage

Simply make a new **IMap** object and call its *GetAddress* method to produce a simple to use **IAddress** object

```c#
IMap map = new GoogleMap(YOUR_GOOGLE_API_KEY);
IAddress address = map.GetAddress(SOME_ADDRESS);

// now you have a simple object:
Console.WriteLine($"the full address is: {address.FormattedAddress}");
Console.WriteLine($"it is located in the: {address.Neighborhood} neighborhood");'
Console.WriteLine($"latitude: {address.Location.Latitude}, longitude: {address.Location.Longitude}");'
```

### Currently implemented for:
- Google Maps

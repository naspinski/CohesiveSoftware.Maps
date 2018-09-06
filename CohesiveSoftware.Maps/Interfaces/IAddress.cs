using CohesiveSoftware.Maps.Models;
using System.Collections.Generic;

namespace CohesiveSoftware.Maps.Interfaces
{
    public interface IAddress
    {
        string Status { get; }

        string FormattedAddress { get; }

        string StreetNumber { get; }
        string Street { get; }
        string ApartmentNumber { get; }

        string City { get; }
        string Neighborhood { get; }
        string County { get; }
        string PostalCode { get; }
        string PostalCodeSuffix { get; }

        Territory State { get; }
        Territory Country { get; }

        string LocationType { get; }

        Coordinates Location { get; }
        List<Coordinates> Bounds { get; }
        List<Coordinates> ViewPort { get; }
    }
}

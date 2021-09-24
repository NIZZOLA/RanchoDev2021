using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpatialDataEntity.Model.Models
{
    public enum LocationTypeEnum :int
    {
        CONTINENT = 1,
        COUNTRY = 2,
        STATE = 3,
    	REGION = 4,
        CITY = 5,
        MULTICITY = 6,
        NEIGHBORHOOD = 7,
        STREET = 8,
        AIRPORT = 9,
        METROSTATION = 10,
        BUSSTATION = 11,
    	SEAPORT = 12,
    	TRAINSTATION = 13,
        HOTEL = 14,
        POI = 15,
        OTHER = 16
    }
}

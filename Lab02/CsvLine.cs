using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02
{
    public class CsvLine
    {
        public string CicId { get; set; }
        public string JrsId { get; set; }
        public string CustomerNumber { get; set; }
        public string HotelName { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"Hotel {HotelName}: CicId: {CicId}, JrsId: {JrsId}";
        }
    }
}

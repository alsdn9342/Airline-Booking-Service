using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_MinWooPark
{
    class Flights
    {
        private int _ID;
        private int _airlineID;
        private string _departureCity;
        private string _destinationCity;
        private string _departureDate;
        private double _flightTime;

        public Flights(int iD, int airlineID, string departureCity, string destinationCity, string departureDate, double flightTime)
        {
            _ID = iD;
            _airlineID = airlineID;
            _departureCity = departureCity;
            _destinationCity = destinationCity;
            _departureDate = departureDate;
            _flightTime = flightTime;
        }

        public int ID { get => _ID; set => _ID = value; }
        public int AirlineID { get => _airlineID; set => _airlineID = value; }
        public string DepartureCity { get => _departureCity; set => _departureCity = value; }
        public string DestinationCity { get => _destinationCity; set => _destinationCity = value; }
        public string DepartureDate { get => _departureDate; set => _departureDate = value; }
        public double FlightTime { get => _flightTime; set => _flightTime = value; }
    }
}

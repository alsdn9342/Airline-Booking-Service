using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_MinWooPark
{
    class Passenger
    {
        private int _ID;
        private int _customerID;
        private int _flightID;

        public Passenger(int iD, int customerID, int flightID)
        {
            _ID = iD;
            _customerID = customerID;
            _flightID = flightID;
        }

        public int ID { get => _ID; set => _ID = value; }
        public int CustomerID { get => _customerID; set => _customerID = value; }
        public int FlightID { get => _flightID; set => _flightID = value; }
    }
}

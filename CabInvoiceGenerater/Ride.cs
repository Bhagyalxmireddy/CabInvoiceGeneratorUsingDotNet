using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class Ride
    {
        public int time;
        public double distance;

        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}

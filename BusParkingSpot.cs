﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystemApp
{
    public class BusParkingSpot : ParkingSpot
    {
        public BusParkingSpot(int id, bool occupied, double price) : base(id, occupied, "bus", price)
        {
            //TODO: Implement me
        }
    }
}

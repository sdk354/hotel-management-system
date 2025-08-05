using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Room_Booking_System
{
    public static class SessionManager
    {
        public static string? Username { get; set; }

        public static void Clear()
        {
            Username = null;
        }
    }
}
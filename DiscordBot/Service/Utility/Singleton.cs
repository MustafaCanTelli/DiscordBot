using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Utility
{
    public class Singleton
    {
        private Singleton()
        {

        }

        private static IceCrownDbContext _context;
        public static IceCrownDbContext Context
        {
            get
            {
                if (_context == null)
                    _context = new IceCrownDbContext();
                return _context;
            }
        }
    }
}

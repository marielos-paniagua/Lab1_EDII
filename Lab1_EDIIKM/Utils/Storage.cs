using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibArbolB;
using Lab1_EDIIKM.Models;

namespace Lab1_EDIIKM.Utils
{
	public class Storage
	{
        private static Storage _instance = null;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }
        public ArbolB<Peliculas> ArbolP;
    }
}

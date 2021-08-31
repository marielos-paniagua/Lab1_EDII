using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_EDIIKM.Models
{
	public class Peliculas : IComparable
	{
		public string Director { get; set; }
		public float ImdbRating { get; set; }
		public string genre { get; set; }
		public DateTime releacseDate { get; set; }
		public int rottenTomatoes { get; set; }
		public string Title { get; set; }

		public int CompareTo(object obj)
		{
			
				return Title.CompareTo(((Peliculas)obj).Title);
			
		}
	}
}

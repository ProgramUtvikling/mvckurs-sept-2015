using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbWeb.Models.MovieModels
{
	public class VoteResultModel
	{
		public double AverageVote { get; internal set; }
		public string MovieId { get; internal set; }
		public int VoteCount { get; internal set; }
		public int YourVote { get; internal set; }
	}
}

﻿using Newtonsoft.Json;
namespace BioscoopCasusSOA3.Models
{
	public class Movie
	{
        [JsonProperty]
        private string _title { get; set; }
		private List<MovieScreening> movieScreenings { get; set; } 
		public Movie(string title)
        {
            _title = title;
        }

        public void addScreening(MovieScreening movieScreening)
        {
            if(movieScreening == null) { return; }
            if(movieScreenings == null) { movieScreenings = new List<MovieScreening>(); }
            movieScreenings.Add(movieScreening);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

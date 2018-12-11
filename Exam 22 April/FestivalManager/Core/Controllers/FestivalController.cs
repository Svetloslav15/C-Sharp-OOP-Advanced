namespace FestivalManager.Core.Controllers
{
	using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";

		private readonly IStage stage;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;
        private ISongFactory songFactory;
        
		public FestivalController(IStage stage)
		{
			this.stage = stage;
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();
		}

		public string RegisterSet(string[] args)
		{
            ISet set = this.setFactory.CreateSet(args[0], args[1]);
            this.stage.AddSet(set);
            return $"Registered {set.GetType().Name} set";
		}

		public string SignUpPerformer(string[] args)
		{
			string name = args[0];
			int age = int.Parse(args[1]);

			string[] instrumenti = args.Skip(2).ToArray();

            List<IInstrument> instrumenti2 = instrumenti
				.Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToList();

			IPerformer performer = this.performerFactory.CreatePerformer(name, age);

			foreach (IInstrument instrument in instrumenti2)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            string name = args[0];
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, CultureInfo.InvariantCulture);
            ISong song = this.songFactory.CreateSong(name, duration);
            this.stage.AddSong(song);
			return $"Registered song {song}";
		}

		public string AddPerformerToSet(string[] args)
		{
            string performerName = args[0];
            string setName = args[1];

            if (this.stage.Performers.Any(x => x.Name == performerName) == false)
            {
                throw new InvalidOperationException("Invalid performer provided");
            }
            if (this.stage.Sets.Any(x => x.Name == setName) == false)
            {
                throw new InvalidOperationException("Invalid set provided");
            }
            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);
            set.AddPerformer(performer);
            return $"Added {performerName} to {setName}";
        }

		public string RepairInstruments(string[] args)
		{
			List<IInstrument> instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToList();

			foreach (IInstrument instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Count} instruments";
		}

        public string ProduceReport()
        {
            StringBuilder result = new StringBuilder();

            TimeSpan totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result.AppendLine($"Festival length: {FormatTime(totalFestivalLength)}");

            foreach (var set in this.stage.Sets)
            {
                result.AppendLine($"--{set.Name} ({FormatTime(set.ActualDuration)}):");

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                    result.AppendLine("--No songs played");
                else
                {
                    result.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        result.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})");
                    }
                }
            }

            return result.ToString();
        }

        private string FormatTime(TimeSpan totalFestivalLength)
        {
            int minutes = totalFestivalLength.Hours * 60 + totalFestivalLength.Minutes;
            int seconds = totalFestivalLength.Seconds;
            return $"{minutes:D2}:{seconds:D2}";
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (this.stage.Sets.Any(x => x.Name == setName) == false)
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (this.stage.Songs.Any(x => x.Name == songName) == false)
            {
                throw new InvalidOperationException("Invalid song provided");
            }
            
            ISong song = this.stage.GetSong(songName);
            ISet set = this.stage.GetSet(setName);
            set.AddSong(song);
            return $"Added {songName} ({song.Duration.ToString(TimeFormat)}) to {setName}";
        }
    }
}
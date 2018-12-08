namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();
        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();
        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public void AddSet(ISet set) => this.sets.Add(set);
        public void AddSong(ISong song) => this.songs.Add(song);
        public void AddPerformer(IPerformer performer) => this.performers.Add(performer);

        public bool HasSet(string name) => this.sets.Any(x => x.Name == name);
        public bool HasSong(string name) => this.songs.Any(x => x.Name == name);
        public bool HasPerformer(string name) => this.performers.Any(x => x.Name == name);

        public ISet GetSet(string name) => this.sets.First(x => x.Name == name);
        public ISong GetSong(string name) => this.songs.First(x => x.Name == name);
        public IPerformer GetPerformer(string name) => this.performers.First(x => x.Name == name);
	}
}
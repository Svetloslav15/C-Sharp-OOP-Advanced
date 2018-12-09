// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class SetControllerTests
    {
        private ISetController setController;
        private IStage stage;

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
        }
        [Test]
	    public void CheckWhenWeHavePerformance()
	    {
            IPerformer performer = new Performer("Pesho", 15);
            ISong song = new Song("First", new TimeSpan(0, 4, 0));
            IInstrument instrument = new Drums();
            ISet set = new Long("LongSet");

            performer.AddInstrument(instrument);
            set.AddPerformer(performer);
            set.AddSong(song);
            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);
            this.stage.AddSet(set);

            string actualResult = setController.PerformSets();
            string expectedResult = "1. LongSet:\r\n-- 1. First (04:00)\r\n-- Set Successful";
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void CheckWhenWeDontHavePerformance()
        {
            IPerformer performer = new Performer("Pesho", 15);
            ISong song = new Song("First", new TimeSpan(0, 4, 0));
            IInstrument instrument = new Drums();
            ISet set = new Long("LongSet");

            set.AddPerformer(performer);
            set.AddSong(song);
            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);
            this.stage.AddSet(set);

            string actualResult = setController.PerformSets();
            string expectedResult = "1. LongSet:\r\n-- Did not perform";
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void CheckInstrument_AfterPerformance_ShouldBeWornDown()
        {
            IPerformer performer = new Performer("Pesho", 15);
            ISong song = new Song("First", new TimeSpan(0, 4, 0));
            IInstrument instrument = new Drums();
            ISet set = new Long("LongSet");

            performer.AddInstrument(instrument);
            set.AddPerformer(performer);
            set.AddSong(song);
            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);
            this.stage.AddSet(set);
            setController.PerformSets();

            Assert.AreEqual(instrument.Wear, 80);
        }
    }
}
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
        private ISetController controller;
        private IStage stage;
        private ISet set;

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
            this.controller = new SetController(this.stage);
            this.set = new Long("Test");
        }
		[Test]
	    public void CheckNotPerform()
	    {
            IPerformer performer = new Performer("Ivan", 23);
            IInstrument instrument = new Drums();
            ISong song = new Song("I am a Dreamer!", new TimeSpan(0, 4, 0));

            performer.AddInstrument(instrument);
            this.set.AddPerformer(performer);
            this.stage.AddSet(set);
            
            string actualResult = this.controller.PerformSets();
            string expectedResult = "1. Test:\r\n-- Did not perform";
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void CheckPerform()
        {
            IPerformer performer = new Performer("Ivan", 23);
            IInstrument instrument = new Drums();
            ISong song = new Song("I am a Dreamer!", new TimeSpan(0, 4, 0));

            performer.AddInstrument(instrument);
            this.set.AddPerformer(performer);
            this.set.AddSong(song);

            this.stage.AddSet(set);
            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);

            string actualResult = this.controller.PerformSets();
            string expectedResult = "1. Test:\r\n-- 1. I am a Dreamer! (04:00)\r\n-- Set Successful";
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void CheckInstrumentWearDown()
        {
            IPerformer performer = new Performer("Ivan", 23);
            IInstrument instrument = new Drums();
            double wear = instrument.Wear;
            ISong song = new Song("I am a Dreamer!", new TimeSpan(0, 4, 0));

            performer.AddInstrument(instrument);
            this.set.AddPerformer(performer);
            this.set.AddSong(song);

            this.stage.AddSet(set);
            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);

            this.controller.PerformSets();
            Assert.AreNotEqual(instrument.Wear, wear);
        }
	}
}
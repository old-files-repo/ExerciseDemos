using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hospital.Tests
{
    [CollectionDefinition("GameState collection")]
    public class GameStateCollection : ICollectionFixture<GameStateFixture>
    {

    }

    public class GameStateFixture : IDisposable
    {
        public Patient Patient { get; }

        public GameStateFixture()
        {
            Patient = new Patient
            {
                FirstName = "Nick",
                LastName = "Carter"
            };
        }

        public void Dispose()
        {
            // Cleanup
        }
    }
}

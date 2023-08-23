using System;
using Specifications.Base;
using Utilities;

namespace Specifications.GameDifficulties
{
    [Serializable]
    public class GameDifficultySpecification : ISpecification
    {
        public DifficultyStages Stage;
        public float AsteroidsSpawnRateShift;
        public float AsteroidsSpeedShift;
    }
}
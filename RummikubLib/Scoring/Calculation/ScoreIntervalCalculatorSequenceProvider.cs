﻿using System.Collections.Generic;
using RummikubLib.Game;

namespace RummikubLib.Scoring.Calculation
{
    public class ScoreIntervalCalculatorSequenceProvider : IScoreIntervalCalculatorSequenceProvider
    {
        public static IScoreIntervalCalculatorSequenceProvider Instance { get; } = new ScoreIntervalCalculatorSequenceProvider();

        const int SmallToLargeThreshold = 50;

        static readonly IScoreIntervalCalculator[] SequenceForSmallTileCollections =
        {
            CombinationSamplingScoreIntervalCalculator.Instance,
            KnownScoringSetsScoreIntervalCalculator.Instance
        };

        static readonly IScoreIntervalCalculator[] SequenceForLargeTileCollections =
        {
            KnownScoringSetsScoreIntervalCalculator.Instance
        };

        ScoreIntervalCalculatorSequenceProvider()
        {
        }

        public IEnumerable<IScoreIntervalCalculator> GetScoreIntervalCalculators(IReadOnlyCollection<ITile> tiles)
        {
            return tiles.Count < SmallToLargeThreshold
                ? SequenceForSmallTileCollections
                : SequenceForLargeTileCollections;
        }
    }
}
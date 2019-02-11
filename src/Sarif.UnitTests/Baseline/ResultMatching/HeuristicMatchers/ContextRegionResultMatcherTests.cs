﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Microsoft.CodeAnalysis.Sarif.Baseline.ResultMatching.HeuristicMatchers
{
    public class ContextRegionResultMatcherTests
    {
        private static ContextRegionHeuristicMatcher matcher = new ContextRegionHeuristicMatcher();

        [Fact]
        public void ContextRegionHeuristicMatcher_NoRegion_DoesNotMatchResults()
        {
            ExtractedResult resultA = new ExtractedResult() { Result = ResultMatchingTestHelpers.CreateMatchingResult("file://test1", "file://test2", null, null) };

            ExtractedResult resultB = new ExtractedResult() { Result = ResultMatchingTestHelpers.CreateMatchingResult("file://test3", "file://test4", null, null) };

            IEnumerable<MatchedResults> matchedResults = matcher.Match(new List<ExtractedResult>() { resultA }, new List<ExtractedResult>() { resultB });

            matchedResults.Should().BeEmpty();
        }

        [Fact]
        public void ContextRegionHeuristicMatcher_DifferentRegion_DoesNotMatchResults()
        {
            ExtractedResult resultA = new ExtractedResult() { Result = ResultMatchingTestHelpers.CreateMatchingResult("file://test1", "file://test2", null, "test one") };

            ExtractedResult resultB = new ExtractedResult() { Result = ResultMatchingTestHelpers.CreateMatchingResult("file://test3", "file://test4", null, "test two") };

            IEnumerable<MatchedResults> matchedResults = matcher.Match(new List<ExtractedResult>() { resultA }, new List<ExtractedResult>() { resultB });

            matchedResults.Should().BeEmpty();
        }


        [Fact]
        public void ContextRegionHeuristicMatcher_SameRegion_MatchesResults()
        {
            ExtractedResult resultA = new ExtractedResult() { Result = ResultMatchingTestHelpers.CreateMatchingResult("file://test1", "file://test2", null, "region contents") };

            ExtractedResult resultB = new ExtractedResult() { Result = ResultMatchingTestHelpers.CreateMatchingResult("file://test3", "file://test4", null, "region contents") };

            IEnumerable<MatchedResults> matchedResults = matcher.Match(new List<ExtractedResult>() { resultA }, new List<ExtractedResult>() { resultB });

            matchedResults.Should().HaveCount(1);
        }
    }
}
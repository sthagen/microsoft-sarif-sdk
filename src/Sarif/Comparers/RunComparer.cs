﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

/// <summary>
/// Warning this comparer may not have all properties compared. Will be replaced by comprehensive
/// comparer generated by JSchema as part of EqualityComparer in a planned comprehensive solution.
/// Tracking by issue: https://github.com/microsoft/jschema/issues/141
/// </summary>
namespace Microsoft.CodeAnalysis.Sarif.Comparers
{
    internal class RunComparer : IComparer<Run>
    {
        internal static readonly RunComparer Instance = new RunComparer();

        public int Compare(Run left, Run right)
        {
            if (ComparerHelper.CompareReference(left, right, out int compareResult))
            {
                return compareResult;
            }

            compareResult = ComparerHelper.CompareList(left.Artifacts, right.Artifacts, ArtifactComparer.Instance);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ToolComponentComparer.Instance.Compare(left?.Tool?.Driver, right?.Tool?.Driver);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ComparerHelper.CompareList(left.Results, right.Results, ResultComparer.Instance);

            if (compareResult != 0)
            {
                return compareResult;
            }

            // Warning there may be properties are not compared.
            return compareResult;
        }
    }
}
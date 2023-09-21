/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2023 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
*/

using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using QuantConnect.Data.UniverseSelection;

namespace QuantConnect.Data.Fundamental
{
    /// <summary>
    /// The growth in the company's operating revenue on a percentage basis. Morningstar calculates the growth percentage based on the underlying operating revenue data reported in the Income Statement within the company filings or reports.
    /// </summary>
    public class OperationRevenueGrowth3MonthAvg : MultiPeriodField
    {
        /// <summary>
        /// The default period
        /// </summary>
        protected override string DefaultPeriod => "OneYear";

        /// <summary>
        /// Gets/sets the OneYear period value for the field
        /// </summary>
        [JsonProperty("1Y")]
        public double OneYear => FundamentalService.Get<double>(Time, SecurityIdentifier, "OperationRatios.OperationRevenueGrowth3MonthAvg.OneYear");

        /// <summary>
        /// Gets/sets the ThreeYears period value for the field
        /// </summary>
        [JsonProperty("3Y")]
        public double ThreeYears => FundamentalService.Get<double>(Time, SecurityIdentifier, "OperationRatios.OperationRevenueGrowth3MonthAvg.ThreeYears");

        /// <summary>
        /// Gets/sets the ThreeMonths period value for the field
        /// </summary>
        [JsonProperty("3M")]
        public double ThreeMonths => FundamentalService.Get<double>(Time, SecurityIdentifier, "OperationRatios.OperationRevenueGrowth3MonthAvg.ThreeMonths");

        /// <summary>
        /// Gets/sets the FiveYears period value for the field
        /// </summary>
        [JsonProperty("5Y")]
        public double FiveYears => FundamentalService.Get<double>(Time, SecurityIdentifier, "OperationRatios.OperationRevenueGrowth3MonthAvg.FiveYears");

        /// <summary>
        /// Returns true if the field contains a value for the default period
        /// </summary>
        public override bool HasValue => FundamentalService.Get<double>(Time, SecurityIdentifier, "OperationRatios.OperationRevenueGrowth3MonthAvg.OneYear") != NoValue;

        /// <summary>
        /// Returns the default value for the field
        /// </summary>
        public override double Value
        {
            get
            {
                var defaultValue = FundamentalService.Get<double>(Time, SecurityIdentifier, "OperationRatios.OperationRevenueGrowth3MonthAvg.OneYear");
                if (defaultValue != NoValue)
                {
                    return defaultValue;
                }
                return base.Value;
            }
        }

        /// <summary>
        /// Gets a dictionary of period names and values for the field
        /// </summary>
        /// <returns>The dictionary of period names and values</returns>
        public override IReadOnlyDictionary<string, double> GetPeriodValues()
        {
            var result = new Dictionary<string, double>();
            foreach (var kvp in new[] { new Tuple<string, double>("1Y",OneYear), new Tuple<string, double>("3Y",ThreeYears), new Tuple<string, double>("3M",ThreeMonths), new Tuple<string, double>("5Y",FiveYears) })
            {
                if(kvp.Item2 != NoValue)
                {
                    result[kvp.Item1] = kvp.Item2;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the value of the field for the requested period
        /// </summary>
        /// <param name="period">The requested period</param>
        /// <returns>The value for the period</returns>
        public override double GetPeriodValue(string period) => FundamentalService.Get<double>(Time, SecurityIdentifier, $"OperationRatios.OperationRevenueGrowth3MonthAvg.{ConvertPeriod(period)}");

        /// <summary>
        /// Creates a new empty instance
        /// </summary>
        public OperationRevenueGrowth3MonthAvg()
        {
        }

        /// <summary>
        /// Creates a new instance for the given time and security
        /// </summary>
        public OperationRevenueGrowth3MonthAvg(DateTime time, SecurityIdentifier securityIdentifier) : base(time, securityIdentifier)
        {
        }
    }
}

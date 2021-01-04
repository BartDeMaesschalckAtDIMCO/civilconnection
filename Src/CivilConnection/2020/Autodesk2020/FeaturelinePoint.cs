// Copyright (c) 2019 DIMCO, N.V All rights reserved.
// Author: de.maesschalck.bart@deme-group.com
// 
// Licensed under the Apache License, Version 2.0 (the "License").
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
using Autodesk.DesignScript.Geometry;

namespace CivilConnection
{
    /// <summary>
    /// FeaturelinePoint object type. Though any point on any featureline can be represented, the puprose of the class is to represent featurelinepoints on corridor featurelines.
    /// </summary>
    [DynamoServices.RegisterForTrace()]
    public class FeatureLinePoint
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The source alignment
        /// </summary>
        Alignment _alignment;
        /// <summary>
        /// The baseline
        /// </summary>
        Alignment _baseline;
        /// <summary>
        /// The code
        /// </summary>
        string _code;
        /// <summary>
        /// The position in real-world coordinates
        /// </summary>
        Point _position;
        /// <summary>
        /// The station on the featureline origin (baseline or offset alignment).
        /// </summary>
        double _station;
        /// <summary>
        /// The station on the baseline.
        /// </summary>
        double _stationOnBaseline;
        /// <summary>
        /// The CoordinateSystem on the featureline for the point
        /// </summary>
        CoordinateSystem _cs;
     
        #endregion

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets the baseline-alignment.
        /// </summary>
        /// <value>
        /// The baseline.
        /// </value>
        public Alignment BaselineAlignment { get { return this._baseline; } }
        /// <summary>
        /// Get the alignment the featureline was based upon.
        /// </summary>
        public Alignment SourceAlignment { get { return this._alignment; } }
        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get { return this._code; } }
        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>
        /// XYZ arraty of the position.
        /// </value>
        public Point Position { get { return this._position; } }
        /// <summary>
        /// Gets the station.
        /// </summary>
        /// <value>
        /// The station.
        /// </value>
        public double Station { get  { return this._station; } }
        /// <summary>
        /// Gets the station on the featureline origin (baseline or offset alignment).
        /// </summary>
        /// <value>
        /// The station.
        /// </value>
        public double StationOnBaseline { get { return this._stationOnBaseline; } }

        ///<summary>
        /// Get the coordinate system at the point
        ///</summary>        
        public CoordinateSystem CoordinateSystem {  get { return this._cs; } }
        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureLinePoint"/> class.
        /// </summary>
        /// <param name="corridorBaseline">The alignment of the corridor baseline.</param>
        /// <param name="sourceAlignment">The alignment on which the featureline is based (corridor baseline or offset alignment).</param>
        /// <param name="pt">The point.</param>
        /// <param name="code">The code.</param>
        /// <param name="station">The station on the alignment (baseline or offset alignment)a.</param>
        /// <param name="stationOnBaseline">The station of the point on the baseline</param>
        internal FeatureLinePoint(Alignment corridorBaseline, Alignment sourceAlignment, Point pt, string code, double station, double stationOnBaseline)
        {
            this._baseline = corridorBaseline;
            this._alignment = sourceAlignment;
            this._position = pt;
            this._code = code;
            this._station = station;
            this._stationOnBaseline = stationOnBaseline;
            this._cs = this._alignment.CoordinateSystemByStation(this._stationOnBaseline);
        }

        #endregion
    }
}

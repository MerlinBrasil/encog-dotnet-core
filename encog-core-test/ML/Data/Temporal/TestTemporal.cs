// Encog(tm) Artificial Intelligence Framework v3.0
// .Net Version
// http://www.heatonresearch.com/encog/
// http://code.google.com/p/encog-java/
// 
// Copyright 2008-2011 by Heaton Research Inc.
// 
// Released under the LGPL.
//
// This is free software; you can redistribute it and/or modify it
// under the terms of the GNU Lesser General Public License as
// published by the Free Software Foundation; either version 2.1 of
// the License, or (at your option) any later version.
//
// This software is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this software; if not, write to the Free
// Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301 USA, or see the FSF site: http://www.fsf.org.
// 
// Encog and Heaton Research are Trademarks of Heaton Research, Inc.
// For information on Heaton Research trademarks, visit:
// 
// http://www.heatonresearch.com/copyright.html

using System;
using System.Collections.Generic;
using Encog.Engine.Network.Activation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encog.ML.Data.Temporal
{
    [TestClass]
    public class TestTemporal
    {
        [TestMethod]
        public void BasicTemporal()
        {
            var temporal = new TemporalMLDataSet(5, 1);
            temporal.AddDescription(new TemporalDataDescription(TemporalDataDescription.Type.Raw, true, false));
            temporal.AddDescription(new TemporalDataDescription(TemporalDataDescription.Type.Raw, true, false));
            temporal.AddDescription(new TemporalDataDescription(TemporalDataDescription.Type.Raw, false, true));
            for (int i = 0; i < 10; i++)
            {
                TemporalPoint tp = temporal.CreatePoint(i);
                tp.Data[0] = 1.0 + (i*3);
                tp.Data[1] = 2.0 + (i*3);
                tp.Data[2] = 3.0 + (i*3);
            }

            temporal.Generate();

            Assert.AreEqual(10, temporal.InputNeuronCount);
            Assert.AreEqual(1, temporal.OutputNeuronCount);
            Assert.AreEqual(10, temporal.CalculateActualSetSize());

            IEnumerator<IMLDataPair> itr = temporal.GetEnumerator();
            itr.MoveNext();
            // set 0
            IMLDataPair pair = itr.Current;
            Assert.AreEqual(10, pair.Input.Count);
            Assert.AreEqual(1, pair.Ideal.Count);
            Assert.AreEqual(1.0, pair.Input.Data[0]);
            Assert.AreEqual(2.0, pair.Input.Data[1]);
            Assert.AreEqual(4.0, pair.Input.Data[2]);
            Assert.AreEqual(5.0, pair.Input.Data[3]);
            Assert.AreEqual(7.0, pair.Input.Data[4]);
            Assert.AreEqual(8.0, pair.Input.Data[5]);
            Assert.AreEqual(10.0, pair.Input.Data[6]);
            Assert.AreEqual(11.0, pair.Input.Data[7]);
            Assert.AreEqual(13.0, pair.Input.Data[8]);
            Assert.AreEqual(14.0, pair.Input.Data[9]);
            Assert.AreEqual(18.0, pair.Ideal[0]);

            // set 1
            itr.MoveNext();
            pair = itr.Current;
            Assert.AreEqual(10, pair.Input.Count);
            Assert.AreEqual(1, pair.Ideal.Count);
            Assert.AreEqual(4.0, pair.Input.Data[0]);
            Assert.AreEqual(5.0, pair.Input.Data[1]);
            Assert.AreEqual(7.0, pair.Input.Data[2]);
            Assert.AreEqual(8.0, pair.Input.Data[3]);
            Assert.AreEqual(10.0, pair.Input.Data[4]);
            Assert.AreEqual(11.0, pair.Input.Data[5]);
            Assert.AreEqual(13.0, pair.Input.Data[6]);
            Assert.AreEqual(14.0, pair.Input.Data[7]);
            Assert.AreEqual(16.0, pair.Input.Data[8]);
            Assert.AreEqual(17.0, pair.Input.Data[9]);
            Assert.AreEqual(21.0, pair.Ideal.Data[0]);

            // set 2
            itr.MoveNext();
            pair = itr.Current;
            Assert.AreEqual(10, pair.Input.Count);
            Assert.AreEqual(1, pair.Ideal.Count);
            Assert.AreEqual(7.0, pair.Input.Data[0]);
            Assert.AreEqual(8.0, pair.Input.Data[1]);
            Assert.AreEqual(10.0, pair.Input.Data[2]);
            Assert.AreEqual(11.0, pair.Input.Data[3]);
            Assert.AreEqual(13.0, pair.Input.Data[4]);
            Assert.AreEqual(14.0, pair.Input.Data[5]);
            Assert.AreEqual(16.0, pair.Input.Data[6]);
            Assert.AreEqual(17.0, pair.Input.Data[7]);
            Assert.AreEqual(19.0, pair.Input.Data[8]);
            Assert.AreEqual(20.0, pair.Input.Data[9]);
            Assert.AreEqual(24.0, pair.Ideal.Data[0]);

            // set 3
            itr.MoveNext();
            pair = itr.Current;
            Assert.AreEqual(10, pair.Input.Count);
            Assert.AreEqual(1, pair.Ideal.Count);
            Assert.AreEqual(10.0, pair.Input.Data[0]);
            Assert.AreEqual(11.0, pair.Input.Data[1]);
            Assert.AreEqual(13.0, pair.Input.Data[2]);
            Assert.AreEqual(14.0, pair.Input.Data[3]);
            Assert.AreEqual(16.0, pair.Input.Data[4]);
            Assert.AreEqual(17.0, pair.Input.Data[5]);
            Assert.AreEqual(19.0, pair.Input.Data[6]);
            Assert.AreEqual(20.0, pair.Input.Data[7]);
            Assert.AreEqual(22.0, pair.Input.Data[8]);
            Assert.AreEqual(23.0, pair.Input.Data[9]);
            Assert.AreEqual(27.0, pair.Ideal.Data[0]);
        }

        [TestMethod]
        public void HiLowTemporal()
        {
            var temporal = new TemporalMLDataSet(5, 1);
            temporal.AddDescription(new TemporalDataDescription(TemporalDataDescription.Type.Raw, true, false));
            temporal.AddDescription(new TemporalDataDescription(TemporalDataDescription.Type.Raw, true, false));
            temporal.AddDescription(new TemporalDataDescription(TemporalDataDescription.Type.Raw, false, true));
            for (int i = 0; i < 10; i++)
            {
                TemporalPoint tp = temporal.CreatePoint(i);
                tp.Data[0] = 1.0 + (i*3);
                tp.Data[1] = 2.0 + (i*3);
                tp.Data[2] = 3.0 + (i*3);
            }

            temporal.HighSequence = 8;
            temporal.LowSequence = 2;
            temporal.Generate();

            Assert.AreEqual(10, temporal.InputNeuronCount);
            Assert.AreEqual(1, temporal.OutputNeuronCount);
            Assert.AreEqual(7, temporal.CalculateActualSetSize());

            IEnumerator<IMLDataPair> itr = temporal.GetEnumerator();
            itr.MoveNext();
            // set 0
            IMLDataPair pair = itr.Current;
            Assert.AreEqual(10, pair.Input.Count);
            Assert.AreEqual(1, pair.Ideal.Count);
            Assert.AreEqual(7.0, pair.Input.Data[0]);
            Assert.AreEqual(8.0, pair.Input.Data[1]);
            Assert.AreEqual(10.0, pair.Input.Data[2]);
            Assert.AreEqual(11.0, pair.Input.Data[3]);
            Assert.AreEqual(13.0, pair.Input.Data[4]);
            Assert.AreEqual(14.0, pair.Input.Data[5]);
            Assert.AreEqual(16.0, pair.Input.Data[6]);
            Assert.AreEqual(17.0, pair.Input.Data[7]);
            Assert.AreEqual(19.0, pair.Input.Data[8]);
            Assert.AreEqual(20.0, pair.Input.Data[9]);
            Assert.AreEqual(24.0, pair.Ideal.Data[0]);
        }

        [TestMethod]
        public void FormatTemporal()
        {
            var temporal = new TemporalMLDataSet(5, 1);
            temporal.AddDescription(new TemporalDataDescription(TemporalDataDescription.Type.DeltaChange, true, false));
            temporal.AddDescription(new TemporalDataDescription(TemporalDataDescription.Type.PercentChange, true, false));
            temporal.AddDescription(new TemporalDataDescription(TemporalDataDescription.Type.Raw, false, true));
            for (int i = 0; i < 10; i++)
            {
                TemporalPoint tp = temporal.CreatePoint(i);
                tp.Data[0] = 1.0 + (i*3);
                tp.Data[1] = 2.0 + (i*3);
                tp.Data[2] = 3.0 + (i*3);
            }

            temporal.Generate();

            IEnumerator<IMLDataPair> itr = temporal.GetEnumerator();
            itr.MoveNext();
            // set 0
            IMLDataPair pair = itr.Current;
            Assert.AreEqual(10, pair.Input.Count);
            Assert.AreEqual(1, pair.Ideal.Count);
            Assert.AreEqual(3.0, pair.Input.Data[0]);
            Assert.AreEqual(1.5, pair.Input.Data[1]);
            Assert.AreEqual(3.0, pair.Input.Data[2]);
            Assert.AreEqual(0.6, pair.Input.Data[3]);
            Assert.AreEqual(3.0, pair.Input.Data[4]);
            Assert.AreEqual(0.375, pair.Input.Data[5]);
            Assert.AreEqual(3.0, pair.Input.Data[6]);
            Assert.AreEqual(0.25, Math.Round(pair.Input.Data[7]*4.0)/4.0);
            Assert.AreEqual(3.0, pair.Input.Data[8]);
            Assert.AreEqual(0.25, Math.Round(pair.Input.Data[9]*4.0)/4.0);
            Assert.AreEqual(18.0, pair.Ideal[0]);
        }

        [TestMethod]
        public void ActivationTemporal()
        {
            var temporal = new TemporalMLDataSet(5, 1);
            temporal.AddDescription(new TemporalDataDescription(new ActivationTANH(), TemporalDataDescription.Type.Raw,
                                                                true, false));
            temporal.AddDescription(new TemporalDataDescription(new ActivationTANH(), TemporalDataDescription.Type.Raw,
                                                                true, false));
            temporal.AddDescription(new TemporalDataDescription(new ActivationTANH(), TemporalDataDescription.Type.Raw,
                                                                false, true));
            for (int i = 0; i < 10; i++)
            {
                TemporalPoint tp = temporal.CreatePoint(i);
                tp.Data[0] = 1.0 + (i*3);
                tp.Data[1] = 2.0 + (i*3);
                tp.Data[2] = 3.0 + (i*3);
            }

            temporal.Generate();

            IEnumerator<IMLDataPair> itr = temporal.GetEnumerator();

            // set 0
            itr.MoveNext();
            IMLDataPair pair = itr.Current;
            Assert.AreEqual(10, pair.Input.Count);
            Assert.AreEqual(1, pair.Ideal.Count);
            Assert.AreEqual(0.75, Math.Round(pair.Input.Data[0]*4.0)/4.0);
            Assert.AreEqual(1.0, Math.Round(pair.Input.Data[1]*4.0)/4.0);
            Assert.AreEqual(1.0, Math.Round(pair.Input.Data[2]*4.0)/4.0);
            Assert.AreEqual(1.0, Math.Round(pair.Input.Data[3]*4.0)/4.0);
        }
    }
}
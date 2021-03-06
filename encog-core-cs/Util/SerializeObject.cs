//
// Encog(tm) Core v3.0 - .Net Version
// http://www.heatonresearch.com/encog/
//
// Copyright 2008-2011 Heaton Research, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//   
// For more information on Heaton Research copyrights, licenses 
// and trademarks visit:
// http://www.heatonresearch.com/copyright
//
#if !SILVERLIGHT
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Encog.Util
{
    /// <summary>
    /// SerializeObject: Load or save an object using DotNet serialization.
    /// </summary>
    public class SerializeObject
    {
        /// <summary>
        /// Private constructor, call everything statically.
        /// </summary>
        private SerializeObject()
        {
        }

        /// <summary>
        /// Load the specified filename.
        /// </summary>
        /// <param name="filename">The filename to load from.</param>
        /// <returns>The object loaded from that file.</returns>
        public static object Load(string filename)
        {
            Stream s = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            var b = new BinaryFormatter();
            object obj = b.Deserialize(s);
            s.Close();
            return obj;
        }

        /// <summary>
        /// Save the specified object.
        /// </summary>
        /// <param name="filename">The filename to save to.</param>
        /// <param name="obj">The object to save.</param>
        public static void Save(string filename, object obj)
        {
            Stream s = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            var b = new BinaryFormatter();
            b.Serialize(s, obj);
            s.Close();
        }
    }
}

#endif

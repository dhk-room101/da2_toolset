﻿/* Copyright (c) 2011 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System.IO;
using Gibbed.IO;

namespace Gibbed.Bioware.FileFormats.GenericFileFormat.Builtins
{
    public class Quaternion : IFieldBuiltinType
    {
        public float A;
        public float B;
        public float C;
        public float D;

        public void Serialize(Stream output, bool littleEndian)
        {
            output.WriteValueF32(this.A, littleEndian);
            output.WriteValueF32(this.B, littleEndian);
            output.WriteValueF32(this.C, littleEndian);
            output.WriteValueF32(this.D, littleEndian);
        }

        public void Deserialize(Stream input, bool littleEndian)
        {
            this.A = input.ReadValueF32(littleEndian);
            this.B = input.ReadValueF32(littleEndian);
            this.C = input.ReadValueF32(littleEndian);
            this.D = input.ReadValueF32(littleEndian);
        }
    }
}

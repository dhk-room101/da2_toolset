using Gibbed.Bioware.FileFormats.GenericFileFormat.Builtins;
using System.Collections.Generic;
using GFF = Gibbed.Bioware.FileFormats.GenericFileFormat;

namespace Gibbed.Bioware.FileFormats
{
     [GFF.StructureDefinition(0x434F4E56)]
     public class CONV
     {
          [GFF.FieldDefinition(30000)]
          public byte u1;

          [GFF.FieldDefinition(30001)]
          public List<LINK> EntriesLinks = new List<LINK>();

          [GFF.FieldDefinition(30002)]
          public List<LINE> Lines = new List<LINE>();

          [GFF.FieldDefinition(30003)]
          public PLOT Plot30003;

          [GFF.FieldDefinition(30004)]
          public float f1;

          [GFF.FieldDefinition(30005)]
          public float f2;

          [GFF.StructureDefinition(0x4C494E4B)]
          public class LINK
          {
               [GFF.FieldDefinition(30100)]
               public ushort index;

               [GFF.FieldDefinition(30101)]
               public TalkString linkTalk;//This is the Line displayed on the wheel

               [GFF.FieldDefinition(30300)]
               public byte u2;

               [GFF.FieldDefinition(30301)]
               public byte u3;

               [GFF.FieldDefinition(30303)]
               public uint ud1;
          }

          [GFF.StructureDefinition(0x4C494E45)]
          public class LINE
          {
               [GFF.FieldDefinition(30200)]
               public ushort uw2;

               [GFF.FieldDefinition(30201)]
               public TalkString lineTalk;//This is the spoken line

               [GFF.FieldDefinition(30202)]
               public PLOT plotCondition;

               [GFF.FieldDefinition(30203)]
               public PLOT plotAction;

               [GFF.FieldDefinition(30204)]
               public List<LINK> repliesList = new List<LINK>();
          }

          [GFF.StructureDefinition(0x504C4F54)]
          public class PLOT
          {
               [GFF.FieldDefinition(30400)]
               public string uuid;

               [GFF.FieldDefinition(30401)]
               public int flagIndex;//Main < 255, Defined > 255

               [GFF.FieldDefinition(30402)]
               public byte u4;
          }
     }
}

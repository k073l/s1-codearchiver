using System.Collections.Generic;

namespace ScheduleOne.Graffiti;
public class Chunk
{
    public UShort2 LowerLeftCorner;
    public UShort2 UpperRightCorner;
    public Dictionary<UShort2, PixelData> paintedPixelData;
    public Chunk(UShort2 lowerLeft, UShort2 upperRight);
    public void SetPixelColor(UShort2 coord, ESprayColor color);
}
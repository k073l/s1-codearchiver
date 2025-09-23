namespace ScheduleOne.Graffiti;
public class PixelData
{
    public UShort2 Coordinate;
    public ESprayColor Color;
    public PixelData(UShort2 coordinate, ESprayColor color);
    public override string ToString();
}
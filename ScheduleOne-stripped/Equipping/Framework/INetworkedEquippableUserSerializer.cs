using FishNet.Object;
using FishNet.Serializing;

namespace ScheduleOne.Equipping.Framework;
public static class INetworkedEquippableUserSerializer
{
    public static void WriteINetworkedEquippableUser(this Writer writer, INetworkedEquippableUser value);
    public static INetworkedEquippableUser ReadINetworkedEquippableUser(this Reader reader);
}
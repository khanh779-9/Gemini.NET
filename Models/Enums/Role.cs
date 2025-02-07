using System.ComponentModel;

namespace Models.Enums
{
    public enum Role : sbyte
    {
        [Description("user")]
        User,

        [Description("model")]
        Model
    }
}

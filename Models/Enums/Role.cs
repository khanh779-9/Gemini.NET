using System.ComponentModel;

namespace Models.Enums
{
    /// <summary>
    /// Enum representing different roles.
    /// </summary>
    public enum Role : sbyte
    {
        /// <summary>
        /// User role.
        /// </summary>
        [Description("user")]
        User,

        /// <summary>
        /// Model role.
        /// </summary>
        [Description("model")]
        Model
    }
}

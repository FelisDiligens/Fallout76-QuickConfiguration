namespace Fo76ini.Tweaks
{
    /// <summary>
    /// Represents an *.ini tweak. May change more than one value in more than one file.
    /// </summary>
    public interface ITweak<T>
    {
        T GetValue();

        void SetValue(T value);

        /// <summary>
        /// Reset the tweak to default values.
        /// </summary>
        void ResetValue();

        T DefaultValue { get; }
    }

    /// <summary>
    /// Stores info about an *.ini tweak.
    /// </summary>
    public interface ITweakInfo
    {
        string Identifier { get; }

        string Description { get; }

        string AffectedFiles { get; }

        string AffectedValues { get; }
    }

    /// <summary>
    /// Makes it possible to interface with an ITweak<CustomEnum> using integer.
    /// </summary>
    public interface IEnumTweak
    {
        int GetInt();

        void SetInt(int value);

        /// <summary>
        /// Get the amount of names in an enum.
        /// </summary>
        int Count { get; }
    }
}

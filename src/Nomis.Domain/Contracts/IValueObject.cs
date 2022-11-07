namespace Nomis.Domain.Contracts
{
    /// <summary>
    /// Value object.
    /// </summary>
    // https://habr.com/ru/post/275599/
    public interface IValueObject
    {
    }

    /// <inheritdoc cref="IValueObject"/>
    /// <typeparam name="TValueObject">The value object type.</typeparam>
    public interface IValueObject<TValueObject> :
        IValueObject,
        IEquatable<TValueObject>
    {
    }

    /// <inheritdoc cref="IValueObject{TValueObject}"/>
    /// <typeparam name="TValueObject">The value object type.</typeparam>
    /// <typeparam name="TValue">The value object value type.</typeparam>
    public interface IValueObject<TValueObject, out TValue> :
        IValueObject<TValueObject>
    {
        /// <summary>
        /// Value object value.
        /// </summary>
        TValue? Value { get; }
    }
}
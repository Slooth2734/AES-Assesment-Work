namespace AssessmentApp
{
    /// <summary>
    ///     This is a pre-existing library being used to convert 
    ///     the string input describing an operator such as '='
    ///     to the actual '=' character so that it can be used
    ///     within the codes logic.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class StringValueAttribute : Attribute
    {
        public string StringValue { get; }

        public StringValueAttribute(string value)
        {
            StringValue = value;
        }
    }

    public static class OperatorsHelper
    {
        public static string GetStringValue(Operators value)
        {
            var type = typeof(Operators);
            var field = type.GetField(value.ToString());
            var attribute = (StringValueAttribute)Attribute.GetCustomAttribute(field, typeof(StringValueAttribute));
            return attribute != null ? attribute.StringValue : null;
        }
    }
}
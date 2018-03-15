namespace KS.Word.Expressions
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    ///     A helper class for <see cref="Expression" />.
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        ///     Compiles an expression and gets the functions return value.
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <param name="lambdaExpression">The <see cref="Expression" /> to compile</param>
        /// <returns>
        ///     Returns value
        ///     <typeparam name="T">T</typeparam>
        ///     from
        ///     <param name="lambdaExpression">Expression</param>
        /// </returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambdaExpression)
        {
            return lambdaExpression.Compile().Invoke();
        }

        /// <summary>
        ///     Sets the underlying properties value to the given value, from an <see cref="Expression" />
        ///     that contains the property.
        /// </summary>
        /// <typeparam name="T">The type of value to set</typeparam>
        /// <param name="lambdaExpression">The expression</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambdaExpression, T value)
        {
            // Convert a lambda () => Foo.Property, to Foo.Property
            var expression = lambdaExpression.Body as MemberExpression;

            // Get the property information so we can set it
            var propertyInfo = (PropertyInfo) expression?.Member;
            var target = Expression.Lambda(expression?.Expression ?? throw new InvalidOperationException()).Compile()
                .DynamicInvoke();

            propertyInfo?.SetValue(target, value);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Extensions
{
	/// <summary>
	/// Class ExpressionExtensions.
	/// </summary>
	public static class ExpressionExtensions
	{
		/// <summary>
		/// Builds the predicate.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="comparison">The comparison.</param>
		/// <param name="value">The value.</param>
		/// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
		public static Expression<Func<T, bool>> BuildPredicate<T>(string propertyName, string comparison, object value)
        {
            var parameter = Expression.Parameter(typeof(T));
            var left = propertyName.Split('.').Aggregate((Expression)parameter, Expression.PropertyOrField);
            var body = MakeComparison(left, comparison, value);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

		/// <summary>
		/// Makes the comparison.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="comparison">The comparison.</param>
		/// <param name="value">The value.</param>
		/// <returns>Expression.</returns>
		/// <exception cref="NotSupportedException">Comparison operator '{comparison}' only supported on string.</exception>
		/// <exception cref="NotSupportedException">Invalid comparison operator '{comparison}'.</exception>
		static Expression MakeComparison(Expression left, string comparison, object value)
        {
            var constant = Expression.Constant(value, left.Type);
            switch (comparison)
            {
                case "==":
                    return Expression.MakeBinary(ExpressionType.Equal, left, constant);
                case "!=":
                    return Expression.MakeBinary(ExpressionType.NotEqual, left, constant);
                case ">":
                    return Expression.MakeBinary(ExpressionType.GreaterThan, left, constant);
                case ">=":
                    return Expression.MakeBinary(ExpressionType.GreaterThanOrEqual, left, constant);
                case "<":
                    return Expression.MakeBinary(ExpressionType.LessThan, left, constant);
                case "<=":
                    return Expression.MakeBinary(ExpressionType.LessThanOrEqual, left, constant);
                case "Contains":
                case "StartsWith":
                case "EndsWith":
                    if (value is string)
                        return Expression.Call(left, comparison, Type.EmptyTypes, constant);

                    throw new NotSupportedException($"Comparison operator '{comparison}' only supported on string.");
                default:
                    throw new NotSupportedException($"Invalid comparison operator '{comparison}'.");
            }
        }

		/// <summary>
		/// Makes the string.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <returns>Expression.</returns>
		private static Expression MakeString(Expression source)
        {
            return source.Type == typeof(string) ? source : Expression.Call(source, "ToString", Type.EmptyTypes);
        }

		/// <summary>
		/// Makes the binary.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="left">The left.</param>
		/// <param name="value">The value.</param>
		/// <returns>Expression.</returns>
		private static Expression MakeBinary(ExpressionType type, Expression left, string value)
        {
            object typedValue = value;
            if (left.Type != typeof(string))
            {
                if (string.IsNullOrEmpty(value))
                {
                    typedValue = null;
                    if (Nullable.GetUnderlyingType(left.Type) == null)
                        left = Expression.Convert(left, typeof(Nullable<>).MakeGenericType(left.Type));
                }
                else
                {
                    var valueType = Nullable.GetUnderlyingType(left.Type) ?? left.Type;
                    typedValue = valueType.IsEnum ? Enum.Parse(valueType, value) :
                        valueType == typeof(Guid) ? Guid.Parse(value) :
                        Convert.ChangeType(value, valueType);
                }
            }
            var right = Expression.Constant(typedValue, left.Type);
            return Expression.MakeBinary(type, left, right);
        }

        /// <summary>
        /// Combines the first predicate with the second using the logical "and".
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1">The expr1.</param>
        /// <param name="expr2">The expr2.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            if (expr2 == null && expr1 != null)
                return expr1;

            if (expr1 == null && expr2 != null)
                return expr2;

            var secondBody = expr2.Body.Replace(expr2.Parameters[0], expr1.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, secondBody), expr1.Parameters);
        }

        /// <summary>
        /// Combines the first predicate with the second using the logical "or".
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1">The expr1.</param>
        /// <param name="expr2">The expr2.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            if (expr2 == null && expr1 != null)
                return expr1;

            if (expr1 == null && expr2 != null)
                return expr2;

            var secondBody = expr2.Body.Replace(expr2.Parameters[0], expr1.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, secondBody), expr1.Parameters);
        }

        /// <summary>
        /// Negates the predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var negated = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
        }

        /// <summary>
        /// Replaces the specified search ex.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="searchEx">The search ex.</param>
        /// <param name="replaceEx">The replace ex.</param>
        /// <returns></returns>
        public static Expression Replace(this Expression expression, Expression searchEx, Expression replaceEx)
        {
            return new ReplaceVisitor(searchEx, replaceEx).Visit(expression);
        }

		/// <summary>
		/// Class ReplaceVisitor.
		/// Implements the <see cref="System.Linq.Expressions.ExpressionVisitor" />
		/// </summary>
		/// <seealso cref="System.Linq.Expressions.ExpressionVisitor" />
		internal class ReplaceVisitor : ExpressionVisitor
        {
            private readonly Expression from, to;

			/// <summary>
			/// Initializes a new instance of the <see cref="ReplaceVisitor"/> class.
			/// </summary>
			/// <param name="from">From.</param>
			/// <param name="to">To.</param>
			public ReplaceVisitor(Expression from, Expression to)
            {
                this.from = from;
                this.to = to;
            }

			/// <summary>
			/// Dispatches the expression to one of the more specialized visit methods in this class.
			/// </summary>
			/// <param name="node">The expression to visit.</param>
			/// <returns>The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.</returns>
			public override Expression Visit(Expression node)
            {
                return node == from ? to : base.Visit(node);
            }
        }
    }
}
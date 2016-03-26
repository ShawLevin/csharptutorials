using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials
{
    /// <summary>
    /// http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Bovium
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="parameterName"></param>
        public static void ThrowIfArgumentIsNull<T>(this T obj, string parameterName) where T : class
        {
            if (obj == null) throw new ArgumentNullException(parameterName + " not allowed to be null");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool In<T>(this T source, params T[] list)
        {
            if (null == source) throw new ArgumentNullException("source");
            return list.Contains(source);
        }


        /// <summary>
        /// Olmo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string str) where T : struct
        {
            return (T)Enum.Parse(typeof(T), str);
        }


        /// <summary>
        /// Olmo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToString<T>(this IEnumerable<T> collection, string separator)
        {
            return ToString(collection, t => t.ToString(), separator);
        }

        /// <summary>
        /// Olmo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="stringElement"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToString<T>(this IEnumerable<T> collection, Func<T, string> stringElement, string separator)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in collection)
            {
                sb.Append(stringElement(item));
                sb.Append(separator);
            }
            return sb.ToString(0, Math.Max(0, sb.Length - separator.Length));  // quita el ultimo separador
        }

        public static bool EqualsIgnoreCase(this string a, string b)
        {
            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsNullOrEmpty(this ICollection obj)
        {
            return (obj == null || obj.Count == 0);
        }


        /// <summary>
        /// Returns a Subset string starting at the specified start index and ending and the specified end
        /// index.
        /// </summary>
        /// <param name="s">The string to retrieve the subset from.</param>
        /// <param name="startIndex">The specified start index for the subset.</param>
        /// <param name="endIndex">The specified end index for the subset.</param>
        /// <returns>A Subset string starting at the specified start index and ending and the specified end
        /// index.</returns>
        public static string Subsetstring(this string s, int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
            {
                throw new InvalidOperationException("End Index must be after Start Index.");
            }

            if (startIndex < 0)
            {
                throw new InvalidOperationException("Start Index must be a positive number.");
            }

            if (endIndex < 0)
            {
                throw new InvalidOperationException("End Index must be a positive number.");
            }

            return s.Substring(startIndex, (endIndex - startIndex));
        }

        /// <summary> BFREE
        /// Finds the specified Start Text and the End Text in this string instance, and returns a string
        /// containing all the text starting from startText, to the begining of endText. (endText is not
        /// included.)
        /// </summary>
        /// <param name="s">The string to retrieve the subset from.</param>
        /// <param name="startText">The Start Text to begin the Subset from.</param>
        /// <param name="endText">The End Text to where the Subset goes to.</param>
        /// <param name="ignoreCase">Whether or not to ignore case when comparing startText/endText to the string.</param>
        /// <returns>A string containing all the text starting from startText, to the begining of endText.</returns>
        public static string Subsetstring(this string s, string startText, string endText, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(startText) || string.IsNullOrEmpty(endText))
            {
                throw new ArgumentException("Start Text and End Text cannot be empty.");
            }
            string temp = s;
            if (ignoreCase)
            {
                temp = s.ToUpperInvariant();
                startText = startText.ToUpperInvariant();
                endText = endText.ToUpperInvariant();
            }
            int start = temp.IndexOf(startText);
            int end = temp.IndexOf(endText, start);
            return Subsetstring(s, start, end);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAD {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// String Routine
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static class StringRoutine {
    #region Private Data

    private static readonly Dictionary<char, char> s_EnglishToRussian = new() {
      { 'a', 'а' },
      { 'c', 'с' },
      { 'e', 'е' },
      { 'k', 'к' },
      { 'l', '1' },
      { 'o', 'о' },
      { 'p', 'р' },
      { 'x', 'х' },
      { 'y', 'у' },

      { 'A', 'А' },
      { 'B', 'В' },
      { 'C', 'С' },
      { 'E', 'Е' },
      { 'H', 'Н' },
      { 'I', '1' },
      { 'K', 'К' },
      { 'M', 'М' },
      { 'N', 'Н' },
      { 'O', 'О' },
      { 'P', 'Р' },
      { 'T', 'Т' },
      { 'X', 'Х' },
      { 'Y', 'У' },

    };

    private static readonly Dictionary<char, char> s_RussianToEnglish = new() {
      { 'а', 'a' },
      { 'с', 'c' },
      { 'е', 'e' },
      { 'з', '3' },
      { 'к', 'k' },
      { 'о', 'o' },
      { 'р', 'p' },
      { 'х', 'x' },
      { 'у', 'y' },

      { 'А', 'A' },
      { 'В', 'B' },
      { 'С', 'C' },
      { 'Е', 'E' },
      { 'З', '3' },
      { 'Н', 'H' },
      { 'К', 'K' },
      { 'М', 'M' },
      { 'О', 'O' },
      { 'Р', 'P' },
      { 'Т', 'T' },
      { 'Х', 'X' },
      { 'У', 'Y' },
    };

    #endregion Private Data

    #region Public

    /// <summary>
    /// English to Russian
    /// </summary>
    public static string EnglishToRussian(string value) {
      if (string.IsNullOrEmpty(value))
        return value;

      return string.Concat(value.Select(c => s_EnglishToRussian.TryGetValue(c, out char v) ? v : c));
    }

    /// <summary>
    /// Russian to English
    /// </summary>
    public static string RussianToEnglish(string value) {
      if (string.IsNullOrEmpty(value))
        return value;

      return string.Concat(value.Select(c => s_RussianToEnglish.TryGetValue(c, out char v) ? v : c));
    }

    #endregion Public
  }

}

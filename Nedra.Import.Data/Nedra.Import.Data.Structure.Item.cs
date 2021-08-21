using AzureAD;

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nedra.Import.Data {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public sealed class StructureImportUser : IEquatable<StructureImportUser> {
    #region Private Data

    private readonly List<string> m_Hierarchy;

    #endregion Private Data

    #region Algorithm

    private static string NormalizeToRussian(object item) {
      string value = Convert.ToString(item);

      if (string.IsNullOrEmpty(value))
        return "";

      value = StringRoutine.EnglishToRussian(value);
      value = Regex.Replace(value, @"\s+", " ").Trim();

      return value;
    }

    private static string NormalizeToEnglish(object item) {
      string value = Convert.ToString(item);

      if (string.IsNullOrEmpty(value))
        return "";

      value = StringRoutine.RussianToEnglish(value);
      value = Regex.Replace(value, @"\s+", " ").Trim();

      return value;
    }

    #endregion Algorithm

    #region Create

    internal StructureImportUser(StructureImport master, IDataRecord data) {
      Master = master ?? throw new ArgumentNullException(nameof(master));

      m_Hierarchy = new string[] {
        Convert.ToString(data[0]),
        Convert.ToString(data[1]),
        Convert.ToString(data[2]),
        Convert.ToString(data[3])
      }.Where(item => !string.IsNullOrWhiteSpace(item))
       .Select(item => NormalizeToRussian(item))
       .ToList();

      JobTitle = NormalizeToRussian(data[4]);

      string value = NormalizeToRussian(data[5]);

      IsPartTime = value.Contains('(');
      Name = Regex.Replace(Regex.Replace(value, @"\([^)]+\)", ""), @"\s+", "").Trim();
      Mail = NormalizeToEnglish(data[6]);

      if (data.IsDBNull(7))
        HiredAt = null;
      else
        HiredAt = Convert.ToDateTime(data[7]);

      value = NormalizeToEnglish(data[8]);

      if (DateTime.TryParseExact(value, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var date))
        FiredAt = date;
      else
        FiredAt = null;

      value = NormalizeToRussian(data[14]);

      ManagerName = Regex.Replace(Regex.Replace(value, @"\([^)]+\)", ""), @"\s+", "").Trim();
      ManagerMail = NormalizeToEnglish(data[15]);

      Id = Guid.NewGuid().ToString();
    }

    #endregion Create

    #region Public

    /// <summary>
    /// Master
    /// </summary>
    public StructureImport Master { get; }

    /// <summary>
    /// Id
    /// </summary>
    public string Id { get; internal set; }

    /// <summary>
    /// User Principal Name
    /// </summary>
    public string UserPrincipalName { get; internal set; }

    /// <summary>
    /// Hierarchy
    /// </summary>
    public IReadOnlyList<string> Hierarchy => m_Hierarchy;

    /// <summary>
    /// Job Title
    /// </summary>
    public string JobTitle { get; }

    /// <summary>
    /// Department
    /// </summary>
    public string Department => Hierarchy.LastOrDefault() ?? "";

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Is Part Time
    /// </summary>
    public bool IsPartTime { get; }

    /// <summary>
    /// Mail
    /// </summary>
    public string Mail { get; }

    /// <summary>
    /// Hired At
    /// </summary>
    public DateTime? HiredAt { get; }

    /// <summary>
    /// Fired At
    /// </summary>
    public DateTime? FiredAt { get; }

    /// <summary>
    /// Is Fired
    /// </summary>
    public bool IsFired => FiredAt.HasValue && FiredAt < DateTime.Today;

    /// <summary>
    /// Manager Name
    /// </summary>
    public string ManagerName { get; }

    /// <summary>
    /// Manager Mail
    /// </summary>
    public string ManagerMail { get; }

    /// <summary>
    /// To String
    /// </summary>
    public override string ToString() =>
      $"{Name}, {JobTitle} ({Mail})";

    #endregion Public

    #region IEquatable<StructureImportUser>

    /// <summary>
    /// Equals
    /// </summary>
    public bool Equals(StructureImportUser other) =>
      ReferenceEquals(this, other) || Id == other?.Id;

    /// <summary>
    /// Equlas
    /// </summary>
    public override bool Equals(object obj) => obj is StructureImportUser other && Equals(other);

    /// <summary>
    /// Hash code
    /// </summary>
    public override int GetHashCode() => Id is null
      ? -1
      : Id.GetHashCode(StringComparison.OrdinalIgnoreCase);

    #endregion IEquatable<StructureImportUser>
  }

}

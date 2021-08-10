using AzureAD;
using AzureAD.Structure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAD.WinForms {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Enterprise Controller
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static class AzureADEnterpriseController {
    #region Public

    /// <summary>
    /// Create and Load Enterprise
    /// </summary>
    public static async Task<AzureEnterprise> LoadAsync(string application,
                                                        string login,
                                                        string password,
                                                        string tenant,
                                                        IEnumerable<string> permissions) {
      var connection = AzureADConnectionController.Connect(
        application, login, password, tenant, permissions);

      if (connection is null || !connection.IsConnected)
        return null;

      return await AzureEnterprise.Create(connection);
    }

    #endregion Public
  }

}

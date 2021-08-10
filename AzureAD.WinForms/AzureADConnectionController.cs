using AzureAD;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAD.WinForms {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static class AzureADConnectionController {
    #region Public

    public static AzureADConnection Connect(string application,
                                            string login, 
                                            string password, 
                                            string tenant, 
                                            IEnumerable<string> permissions) {
      using AzureADConnectionForm form = new (application, login, password, tenant, permissions);

      form.ShowDialog();

      return form.Connection;
    }

    #endregion Public
  }

}

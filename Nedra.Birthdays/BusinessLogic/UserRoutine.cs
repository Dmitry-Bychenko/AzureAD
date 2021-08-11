using AzureAD;
using AzureAD.Structure;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nedra.Birthdays.BusinessLogic {

//  POST https://graph.microsoft.com/v1.0/me/extensions
//  {
//     "@odata.type": "microsoft.graph.openTypeExtension",
//     "extensionName": "Nedra.HR.Birthday",

//     "employeeBirthday": "1974-07-08T00:00:00.000Z",
//     "employeeGreetings": ["a", "b", "c" ]
//  }

public static class UserRoutine {
    #region Constants

    private const string EXTENSION_NAME = "Nedra.HR.Birthday";

    #endregion Constants

    #region Public

    public static DateTime? GetBirthday(this AzureUser user) {
      if (user is null)
        return null;

      if (user.User.Extensions is null)
        return null;

      foreach (var ext in user.User.Extensions) {
        if (string.Equals(ext.Id, EXTENSION_NAME, StringComparison.OrdinalIgnoreCase)) {
          if (!ext.AdditionalData.TryGetValue("employeeBirthday", out var st))
            return null;

          if (st is JsonElement json) {
            if (json.ValueKind == JsonValueKind.Null)
              return null;

            return json.GetDateTime();
          }

          return null;
        }
      }

      return null;
    }

    #endregion Public
  }

}

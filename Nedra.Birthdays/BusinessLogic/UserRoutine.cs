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
      var json = user?.ExtensionValue(EXTENSION_NAME, "employeeBirthday") ?? new JsonElement();

      return (json.ValueKind == JsonValueKind.Null || json.ValueKind == JsonValueKind.Undefined)
        ? null
        : json.GetDateTime();
    }

    public static string[] GetGreetings(this AzureUser user) {
      var json = user?.ExtensionValue(EXTENSION_NAME, "employeeGreetings") ?? new JsonElement();

      if (json.ValueKind != JsonValueKind.Array)
        return Array.Empty<string>();

      string[] result = new string[json.GetArrayLength()];

      for (int i = 0; i < result.Length; ++i)
        result[i] = json[i].GetString();

      return result;
    }

    #endregion Public
  }

}

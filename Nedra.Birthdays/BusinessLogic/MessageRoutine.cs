using Microsoft.Graph;

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
  
  public static class MessageRoutine {
    #region Algorithm

    private static ChatMessage CreateMessage(AzureUser user, string message) {
      var result = new ChatMessage {
        CreatedDateTime = DateTime.Now,
        From = new ChatMessageFromIdentitySet {
          User = new Identity {
            //Id = "id-value",
            DisplayName = user.User.DisplayName,
          }
        },
        Body = new ItemBody {
          ContentType = BodyType.Html,
          Content = message
        }
      };

      return result;
    }

    #endregion Algorithm

    #region Public

    /// <summary>
    /// Send HTML message into team's primary channel
    /// </summary>
    /// <param name="user"></param>
    /// <param name="teamId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<bool> SendMessage(this AzureUser user, string teamId, string message) {
      if (string.IsNullOrWhiteSpace(teamId))
        return false;

      var team = user
        .GraphClient
        .Teams[teamId];

      if (team is null)
        return false;

      var channel = await team
        .PrimaryChannel
        .Request()
        .GetAsync();

      if (channel is null)
        return false;

      ChatMessage chatMessage = CreateMessage(user, message);

      await user
        .GraphClient
        .Teams[teamId]
        .Channels[channel.Id]
        .Messages
        .Request()
        .AddAsync(chatMessage);

      return true;
    }

    #endregion Public
  }

}

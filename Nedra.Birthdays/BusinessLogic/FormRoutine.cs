using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nedra.Birthdays.BusinessLogic {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Form Routine
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static class FormRoutine {
    #region Public

    public static void ApplyGridUI(DataGridView grid) {
      if (grid is null)
        return;

      grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Thistle;
      grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = grid.ColumnHeadersDefaultCellStyle.BackColor;
      grid.EnableHeadersVisualStyles = false;

      grid.RowsDefaultCellStyle.BackColor = Color.White;
      grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;

      grid.DefaultCellStyle.SelectionBackColor = Color.Gold;
      grid.DefaultCellStyle.SelectionForeColor = Color.Black;
    }

    #endregion Public
  }

}

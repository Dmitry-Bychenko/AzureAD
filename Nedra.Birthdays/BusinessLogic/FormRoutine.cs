using System;
using System.Collections;
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
    #region Inner Class

    private sealed class ColumnComparerClass : IComparer {
      public int Compare(object x, object y) {
        if (ReferenceEquals(x, y))
          return 0;

        return StringComparer.OrdinalIgnoreCase.Compare(x?.ToString(), y?.ToString());
      }
    }

    #endregion Inner Class

    #region Public

    /// <summary>
    /// Apply Grid UI
    /// </summary>
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

    /// <summary>
    /// Ask Question
    /// </summary>
    public static bool AskQuestion(string question) {
      if (string.IsNullOrEmpty(question))
        return false;

      string title = Application
        .OpenForms
        .OfType<Form>()
        .FirstOrDefault(f => f.Focused)
       ?.Text;

      if (title is null)
        title = Application
          .OpenForms
          .OfType<Form>()
          .FirstOrDefault()
         ?.Text ?? "Question";

      return MessageBox.Show(question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    /// <summary>
    /// Comparer
    /// </summary>
    public static IComparer ColumnComparer { get; } = new ColumnComparerClass();

    #endregion Public
  }

}

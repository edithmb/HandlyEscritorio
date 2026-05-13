using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace handlyAdminScreens.Helpers
{
    public static class GridFormat
    {
        // Notice the 'this DataGridView grid' parameter
        public static void ConfigureCol(this DataGridView grid, string name, string header, int index, bool frozen = false)
        {
            if (grid.Columns.Contains(name))
            {
                var col = grid.Columns[name];
                col.HeaderText = header;
                col.DisplayIndex = index;
                col.Frozen = frozen;
            }
        }

        // Let's also make a reusable method for hiding columns!
        // The 'params' keyword lets you pass as many strings as you want separated by commas.
        public static void HideCol(this DataGridView grid, params string[] columnsToHide)
        {
            foreach (string colName in columnsToHide)
            {
                if (grid.Columns.Contains(colName))
                {
                    grid.Columns[colName].Visible = false;
                }
            }
        }
    }
}

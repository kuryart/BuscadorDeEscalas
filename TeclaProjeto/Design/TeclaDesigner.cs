using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TeclaProjeto.Design
{

    [ToolboxItemFilter("TeclaProjeto.MarqueeBorder", ToolboxItemFilterType.Require)]
    [ToolboxItemFilter("TeclaProjeto.MarqueeText", ToolboxItemFilterType.Require)]
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    class TeclaDesigner : DocumentDesigner
    {
        public TeclaDesigner()
        {
            Trace.WriteLine("TeclaDesigner ctor");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;
using DevExpress.XtraTreeList.Nodes;

namespace SinoSZClientBase.Organize
{
        public class OrgEventArgs: EventArgs
        {
                public SinoOrganize Organize = null;
                public TreeListNode SelectedNode = null;
                public OrgEventArgs() { }
                public OrgEventArgs(TreeListNode _node,SinoOrganize _org)
                {
                        this.SelectedNode = _node;
                        this.Organize = _org;
                }

        }
}

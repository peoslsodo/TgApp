using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TgApp.Model;

namespace TgApp.Util
{
    public class FormUtil
    {

        #region tree

        public static void BindTree(TreeView tree, List<Node> list)
        {
            tree.Nodes.Clear();
            var root = list.First(n => n.IsRoot);
            var rootNode = new TreeNode()
            {
                Text = root.Value,
                Name = root.Name
            }; ;
            tree.Nodes.Add(rootNode);

            BindTree(rootNode, list, root.Id);
            tree.ExpandAll();

        }

        public static void BindTree(TreeNode parentNode, List<Node> list, int parentId)
        {
            var childList = list.Where(t => t.ParentId == parentId)
                .OrderBy(c => c.Id);
            foreach (var c in childList)
            {
                var node = new TreeNode
                {
                    Text = c.Value,
                    Name = c.Name,
                    Tag = c.FormName
                };
                parentNode.Nodes.Add(node);
                BindTree(node, list, c.Id);
            }

        }

        #endregion

    }
}

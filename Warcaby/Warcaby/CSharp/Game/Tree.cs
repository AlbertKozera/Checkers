using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

public class TreeNode : IEnumerable<TreeNode>
{
    private readonly Dictionary<string, TreeNode> _children =
                                        new Dictionary<string, TreeNode>();

    public readonly string ID;
    public TreeNode Parent { get; private set; }

    public TreeNode(string id)
    {
        this.ID = id;
    }

    public TreeNode GetChild(string id)
    {
        return this._children[id];
    }

    public void Add(TreeNode item)
    {
        if (item.Parent != null)
        {
            item.Parent._children.Remove(item.ID);
        }

        item.Parent = this;
        this._children.Add(item.ID, item);
    }

    public IEnumerator<TreeNode> GetEnumerator()
    {
        return this._children.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    public int Count
    {
        get { return this._children.Count; }
    }
}
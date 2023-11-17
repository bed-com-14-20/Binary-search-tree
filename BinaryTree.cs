public class BinaryTree<T> where T : IComparable<T>
{
    private Node<T> root;

    public void Insert(T data)
    {
        root = InsertRec(root, data);
    }

    private Node<T> InsertRec(Node<T> root, T data)
    {
        if (root == null)
            return new Node<T>(data);

        if (data.CompareTo(root.Data) < 0)
            root.Left = InsertRec(root.Left, data);
        else if (data.CompareTo(root.Data) > 0)
            root.Right = InsertRec(root.Right, data);

        return root;
    }

    public bool Search(T data, out Node<T> foundNode, out Node<T> parentNode)
    {
        foundNode = null;
        parentNode = null;
        return SearchRec(root, data, ref foundNode, ref parentNode);
    }

    private bool SearchRec(Node<T> root, T data, ref Node<T> foundNode, ref Node<T> parentNode)
    {
        if (root == null)
            return false;

        if (data.CompareTo(root.Data) == 0)
        {
            foundNode = root;
            return true;
        }
        else if (data.CompareTo(root.Data) < 0)
        {
            parentNode = root;
            return SearchRec(root.Left, data, ref foundNode, ref parentNode);
        }
        else
        {
            parentNode = root;
            return SearchRec(root.Right, data, ref foundNode, ref parentNode);
        }
    }

    public void Remove(T data)
    {
        root = RemoveRec(root, data);
    }

    private Node<T> RemoveRec(Node<T> root, T data)
    {
        if (root == null)
            return root;

        if (data.CompareTo(root.Data) < 0)
            root.Left = RemoveRec(root.Left, data);
        else if (data.CompareTo(root.Data) > 0)
            root.Right = RemoveRec(root.Right, data);
        else
        {
            if (root.Left == null)
                return root.Right;
            else if (root.Right == null)
                return root.Left;

            root.Data = MinValue(root.Right);
            root.Right = RemoveRec(root.Right, root.Data);
        }

        return root;
    }

    private T MinValue(Node<T> root)
    {
        T minValue = root.Data;
        while (root.Left != null)
        {
            minValue = root.Left.Data;
            root = root.Left;
        }
        return minValue;
    }

    private void InorderTraversal(Node<T> node)
    {
        if (node != null)
        {
            InorderTraversal(node.Left);
            Console.Write(node.Data + " ");
            InorderTraversal(node.Right);
        }
    }

    private void PostorderTraversal(Node<T> node)
    {
        if (node != null)
        {
            PostorderTraversal(node.Left);
            PostorderTraversal(node.Right);
            Console.Write(node.Data + " ");
        }
    }

    public void PrintInorder()
    {
        Console.Write("Inorder Traversal: ");
        InorderTraversal(root);
        Console.WriteLine();
    }

    public void PrintPostorder()
    {
        Console.Write("Postorder Traversal: ");
        PostorderTraversal(root);
        Console.WriteLine();
    }
}

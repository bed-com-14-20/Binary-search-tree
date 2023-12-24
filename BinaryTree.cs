 public class BinaryTree<T> where T : IComparable<T>
{
    private Node<T> root;

    public void Insert_Value(T data)
    {
        root = InsertOperation(root, data);
    }

// To insert a value in the tree,,, make sure that the node is null first 
    private Node<T> InsertOperation(Node<T> node, T data)
    {
        if (node == null)
            return new Node<T>(data);

        int compareResult = data.CompareTo(node.Data);
        if (compareResult < 0)
            node.Left = InsertOperation(node.Left, data);
        else if (compareResult > 0)
            node.Right = InsertOperation(node.Right, data);

        return node;
    }
//search for a node 

    public bool Search_Node(T data, out Node<T> Available_Node, out Node<T> parentNode)
    {
        Available_Node = null;
        parentNode = null;
        return SearchOperation(root, data, ref Available_Node, ref parentNode); 
    }

    private bool SearchOperation(Node<T> node, T data, ref Node<T> Available_Node, ref Node<T> parentNode)
    {
        if (node == null)
            return false;

        int compareResult = data.CompareTo(node.Data);
        if (compareResult == 0)
        {
            Available_Node = node;
            return true;
        }

        parentNode = node;
        return SearchOperation(compareResult < 0 ? node.Left : node.Right, data, ref Available_Node, ref parentNode);
    }

// remove

    public void Remove(T data)
    {
        root = Remove_Function(root, data);
    }

    private Node<T> Remove_Function(Node<T> node, T data)
    {
        if (node == null)
            return node;

        int compareOutcome = data.CompareTo(node.Data);
        if (compareOutcome < 0)
            node.Left = Remove_Function(node.Left, data);
        else if (compareOutcome > 0)
            node.Right = Remove_Function(node.Right, data);
        else
        {
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;

            node.Data = MinimumValue(node.Right);
            node.Right = Remove_Function(node.Right, node.Data);
        }

        return node ;
        
    }

    private T MinimumValue(Node<T> node)
    {
        T minValue = node.Data;
        while (node.Left != null)
        {
            minValue = node.Left.Data;
            node = node.Left;
        }
        return minValue;
    }

// in order traversal it visit left child first, the root and right child

    private void InorderTraversal(Node<T> node, Action<T> response)
    {
        if (node != null)
        {
            InorderTraversal(node.Left, response);
            response(node.Data);
            InorderTraversal(node.Right, response);
        }
    }

//printing in order

    public void PrintInorder()
    {
        Console.Write("Inorder Traversal Result is: ");
        InorderTraversal(root, data => Console.Write($"{data} "));
        Console.WriteLine();
    }

// post oder, thios visit the left child then right and root last

    private void PostorderTraversal(Node<T> node, Action<T> result)
    {
        if (node != null)
        {
            PostorderTraversal(node.Left, result);
            PostorderTraversal(node.Right, result);
            result(node.Data);
        }
    }

// printing post order

    public void PrintPostorder()
    {
        Console.Write("Postorder Traversal Result is : ");
        PostorderTraversal(root, data => Console.Write($"{data} "));
        Console.WriteLine();
    }
}
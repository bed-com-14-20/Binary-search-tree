 using System;

class Program
{
    static void Main()
    {
        // Create a BinaryTree of integers
        BinaryTree<int> binaryTree = new BinaryTree<int>();

        // Prompt the user to enter values
        Console.WriteLine("Enter values to insert into the binary tree (enter a non-integer to stop):");

        while (true)
        {
            Console.Write("Enter an integer value (or a non-integer to stop): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            {
                // Insert the user-entered value into the binary tree
                binaryTree.Insert(value);
            }
            else
            {
                // Stop input if the user enters a non-integer value
                break;
            }
        }

        // Print inorder and postorder traversals
        binaryTree.PrintInorder();
        binaryTree.PrintPostorder();

        // Prompt the user to search for a node
        Console.Write("Enter a value to search in the binary tree: ");
        if (int.TryParse(Console.ReadLine(), out int searchKey))
        {
            if (binaryTree.Search(searchKey, out Node<int> foundNode, out Node<int> parentNode))
            {
                Console.WriteLine($"Node {searchKey} found.");
                if (parentNode != null)
                    Console.WriteLine($"Immediate parent: {parentNode.Data}");
                if (foundNode.Left != null)
                    Console.WriteLine($"Left child: {foundNode.Left.Data}");
                if (foundNode.Right != null)
                    Console.WriteLine($"Right child: {foundNode.Right.Data}");
            }
            else
            {
                Console.WriteLine($"Node {searchKey} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for search key.");
        }

        // Prompt the user to remove a node
        Console.Write("Enter a value to remove from the binary tree: ");
        if (int.TryParse(Console.ReadLine(), out int removeKey))
        {
            binaryTree.Remove(removeKey);

            // Print inorder and postorder traversals after removal
            binaryTree.PrintInorder();
            binaryTree.PrintPostorder();
        }
        else
        {
            Console.WriteLine("Invalid input for removal key.");
        }
    }
}

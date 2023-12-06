 class Program
{
    static void Main()
    {
        // Create an instance of BinaryTree to perform operations on a binary tree of integers
        BinaryTree<int> binaryTree = new BinaryTree<int>();

        while (true)
        {
            // Display menu for binary tree operations
            Console.WriteLine("Binary Tree Operations please select 1 option at a time:");
            Console.WriteLine("1. Insert a value in the tree");
            Console.WriteLine("2. Search for a value in the tree");
            Console.WriteLine("3. Remove a value from the tree");
            Console.WriteLine("4. Print In--order and Post--order Traversal");
            Console.WriteLine("5. Exit.........");

            // Prompt the user to enter their choice
            Console.Write("Enter your choice (1-5): Please enter within given range ");
            string choice = Console.ReadLine();

            // Perform actions based on user's choice 
            // switch statement
            switch (choice)
            {
                case "1":
                    // Insert operation
                    Console.Write("Enter an integer value to insert into the Tree: ");
                    if (int.TryParse(Console.ReadLine(), out int insertValue))
                        binaryTree.Insert(insertValue);
                    else
                        Console.WriteLine("Invalid input for insertion please TRY again.");
                    break;


                case "2":
                    // Search operation
                    Console.Write("Enter a value to search in the binary tree: ");
                    if (int.TryParse(Console.ReadLine(), out int searchKey))
                    {
                        if (binaryTree.Search(searchKey, out Node<int> foundNode, out Node<int> parentNode))
                        {
                            Console.WriteLine($"Node {searchKey} succesfully found.");
                            Console.WriteLine(parentNode != null ? $"Immediate parent: {parentNode.Data}" : "No parent");
                            Console.WriteLine(foundNode.Left != null ? $"Left child: {foundNode.Left.Data}" : "No left child");
                            Console.WriteLine(foundNode.Right != null ? $"Right child: {foundNode.Right.Data}" : "No right child");
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
                    break;

                case "3":
                    // Remove operation
                    Console.Write("Enter a value to remove from the binary tree: ");
                    if (int.TryParse(Console.ReadLine(), out int removeKey))
                        binaryTree.Remove(removeKey);
                    else
                        Console.WriteLine("Invalid input for removal key or The value does not found.");
                    break;

                case "4":
                    // Print Inorder and Postorder Traversal
                    binaryTree.PrintInorder();
                    binaryTree.PrintPostorder();
                    break;

                case "5":
                    // Exit the program
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    // Invalid choice
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}

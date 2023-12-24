 using System;
 class Program
{
    static void Main()
    {
        //  instance of operations on a binary tree of integers
        BinaryTree<int> binaryTree = new BinaryTree<int>();

        // infirnity loop that keep on repeating the operations below if they are true
        while (true)
        {
            // Display menu for binary tree operations
            Console.WriteLine("\n");
            Console.WriteLine("Binary Tree Operations please select 1 option at a time:\n ");
            Console.WriteLine("1. Insert a value in the Tree");
            Console.WriteLine("2. Search for a value in the Tree");
            Console.WriteLine("3. Remove a value from the Tree");
            Console.WriteLine("4. Print In--order");
            Console.WriteLine("5. Print post--order");
            Console.WriteLine("6. Exit The program \n ");

            // Prompt the user to enter their choice
            Console.Write("Enter your choice (1-6): Please enter within given range : ");
            string selection = Console.ReadLine();

            // Perform actions based on user's choice 
            // switch statement in this case we are switching choice
            switch (selection)
            {
                
                case "1":

                    // Insert operation
                    Console.Write("Enter an integer value to insert into the Tree: ");

                    if (int.TryParse(Console.ReadLine(), out int insertValue))
                        binaryTree.Insert_Value(insertValue);

                    else
                        Console.WriteLine("Invalid input for insertion please TRY again.");
                    break;
                   
                
                case "2":

                    // Search operation
                    // it check if the value is in tree , if yes return it if no says the value not found or invalid option
                    Console.Write("Enter a value to search in the binary tree: ");

                    if (int.TryParse(Console.ReadLine(), out int search_pointer))
                    {
                        if (binaryTree.Search_Node(search_pointer, out Node<int> Available_Node, out Node<int> parentNode))
                        {
                            Console.WriteLine($"Node {search_pointer} succesfully found in the Tree.");
                            Console.WriteLine(parentNode != null ? $"parent: {parentNode.Data}" : "No parent");
                            Console.WriteLine(Available_Node.Left != null ? $"Left child: {Available_Node.Left.Data}" : "No left child");
                            Console.WriteLine(Available_Node.Right != null ? $"Right child: {Available_Node.Right.Data}" : "No right child");
                        }

                        else
                        {
                            Console.WriteLine($"Node {search_pointer} not found in the Tree.");
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
                    if (int.TryParse(Console.ReadLine(), out int removeValue)){
                        binaryTree.Remove(removeValue );

                        string Removed_Node = removeValue +    " successfully removed from the Tree";
                        Console.WriteLine(Removed_Node);
                    }
                    
                    else

                        Console.WriteLine("Invalid input for removal The value does not found.");
                    break;


                case "4":

                    // Printing Inorder 
                    binaryTree.PrintInorder();
                    break;

                    
                case "5":
                    //Postorder Traversal
                    binaryTree.PrintPostorder();
                    break;

                case "6":
                    // Exit the program
                    Console.WriteLine("The program Exit succesfully");
                    return;

                default:

                    
                    // Invalid choice
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }
}

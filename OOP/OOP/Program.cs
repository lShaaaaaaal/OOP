using System;
using OOP;

class MainProgram
{
    static void Main()
    {
        bool isAuthenticated = false; // To track if the admin is successfully authenticated
        AdminLogin login = new AdminLogin();

        while (!isAuthenticated)
        {
            Console.Clear();
            Console.WriteLine(@"
 _    _      _                             ___      _           _       
| |  | |    | |                           / _ \    | |         (_)      
| |  | | ___| | ___ ___  _ __ ___   ___  / /_\ \ __| |_ __ ___  _ _ __  
| |/\| |/ _ | |/ __/ _ \| '_ ` _ \ / _ \ |  _  |/ _` | '_ ` _ \| | '_ \ 
\  /\  |  __| | (_| (_) | | | | | |  __/ | | | | (_| | | | | | | | | | |
 \/  \/ \___|_|\___\___/|_| |_| |_|\___| \_| |_/\__,_|_| |_| |_|_|_| |_|    
========================================================================
                          ADMIN LOGIN 
========================================================================
        ");

            Console.Write("Enter Admin Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Admin Password: ");
            string password = Console.ReadLine();

            string result = login.AuthenticateAdmin(username, password);

            Console.WriteLine(result); // Output the result of the authentication attempt

            if (result == "Authentication successful!")
            {
                Console.Clear();
                Console.WriteLine(@"
==========================================
         ADMIN LOGIN SUCCESSFUL!
==========================================
                ");

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine(@"
==========================================
         ADD 2 PRODUCTS TO INVENTORY 
==========================================
                ");

                OOP.ManageProduct.InsertNewProduct newProduct = new OOP.ManageProduct.InsertNewProduct();

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine($"\n Enter details for Product {i + 1}:");

                    Console.Write("Enter Product Name: ");
                    string productName = Console.ReadLine();

                    Console.Write("Enter Product Price: ");
                    int productPrice;
                    while (!int.TryParse(Console.ReadLine(), out productPrice))
                    {
                        Console.WriteLine("Invalid input. Enter a valid price.");
                        Console.Write("Enter Product Price: ");
                    }

                    Console.Write("Enter Product Description: ");
                    string productDescription = Console.ReadLine();

                    bool inserted = newProduct.InsertData(productName, productPrice, productDescription);
                    Console.WriteLine(inserted ? "Product added successfully!\n" : "Failed to add product.\n");
                }

                Console.Clear();
                Console.WriteLine(@"
===================================================
     PRODUCTS HAVE BEEN INSERTED SUCCESSFULLY! 
===================================================
                ");

                isAuthenticated = true; // Set this to true to break out of the loop and end the program
            }
            else
            {
                // If admin credentials are not found, display the error message and ask again
                Console.Clear();
                Console.WriteLine(@"
==========================================
        ADMIN NOT FOUND! ACCESS DENIED!
==========================================
                ");
                Console.WriteLine(result);  // Output the error message from AuthenticateAdmin
                Console.WriteLine("\nPress any key to try again...");
                Console.ReadKey();  // Wait for user input to try again
            }
        }

        // Optionally, after the process is complete, wait for the user to exit
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

using System;
using System.Collections.Generic;

class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}

class Program
{
    static List<Contact> contacts = new List<Contact>();

    static string fileName;
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Search Contact");
            Console.WriteLine("5. Export Contact");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddContact();
                    break;
                case 2:
                    EditContact();
                    break;
                case 3:
                    DeleteContact();
                    break;
                case 4:
                    SearchContact();
                    break;
                case 5:
                    export();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
    static void exportAppend()
    {
        contacts.Sort((x, y) => x.Name.CompareTo(y.Name));
        /*Console.WriteLine("Enter file name:");*/
        /*fileName = Console.ReadLine();*/
        string og = @"C:\Users\Administrator\source\repos\ContactManager\ContactManager\" + "contacts.txt";

        try
        {
            FileStream aFile = new FileStream(og, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(aFile);
            foreach (Contact c in contacts)
            {
                writer.WriteLine(c.Name + ":" + c.PhoneNumber);
            }
            writer.Close();
            Console.WriteLine("The file has been successfully created");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
        }
        /*foreach(var con in contacts)
        {
            Console.WriteLine(con.Name + " "+ con.PhoneNumber);
        }*/
    }
    static void export()
    {
        contacts.Sort((x, y) => x.Name.CompareTo(y.Name));
        /*Console.WriteLine("Enter file name:");*/
        /*fileName = Console.ReadLine();*/
        string og = @"C:\Users\Administrator\source\repos\ContactManager\ContactManager\" + "contacts.txt";

        try
        {

            StreamWriter writer = new StreamWriter(og);
            foreach (Contact c in contacts)
            {
                writer.WriteLine(c.Name + ":" + c.PhoneNumber);
            }
            writer.Close();
            Console.WriteLine("The file has been successfully created");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
        }

    }
    static void AddContact()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine();

        Contact contact = new Contact { Name = name, PhoneNumber = phoneNumber };
        contacts.Add(contact);

        Console.WriteLine("Contact added successfully");
    }

    static void EditContact()
    {
        Console.Write("Enter name or phone number to search for contact: ");
        string searchTerm = Console.ReadLine();

        Contact contact = SearchContactByTerm(searchTerm);
        if (contact == null)
        {
            Console.WriteLine("Contact not found");
            return;
        }

        Console.WriteLine("Contact found:");
        Console.WriteLine("Name: {0}, Phone Number: {1}", contact.Name, contact.PhoneNumber);

        Console.Write("Enter new name (or press Enter to keep existing name): ");
        string newName = Console.ReadLine();

        Console.Write("Enter new phone number (or press Enter to keep existing phone number): ");
        string newPhoneNumber = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newName))
        {
            contact.Name = newName;
        }

        if (!string.IsNullOrWhiteSpace(newPhoneNumber))
        {
            contact.PhoneNumber = newPhoneNumber;
        }
        export();

        Console.WriteLine("Contact updated successfully");
    }

    static void DeleteContact()
    {
        Console.Write("Enter name or phone number to search for contact: ");
        string searchTerm = Console.ReadLine();

        Contact contact = SearchContactByTerm(searchTerm);
        if (contact == null)
        {

            Console.WriteLine("Contact not found");
            return;
        }
        contacts.Remove(contact);
        export();
        Console.WriteLine("Contact deleted successfully");
        /*foreach(Contact c in contacts)
        {
            Console.WriteLine(c.Name);
        }*/
    }

    static void SearchContact()
    {
        Console.Write("Enter name or phone number to search for contact: ");
        string searchTerm = Console.ReadLine();

        Contact contact = SearchContactByTerm(searchTerm);
        if (contact == null)
        {
            Console.WriteLine("Contact not found");
            return;
        }

        Console.WriteLine("Contact found:");
        Console.WriteLine("Name: {0}, Phone Number: {1}", contact.Name, contact.PhoneNumber);
    }

    static Contact SearchContactByTerm(string searchTerm)
    {
        Contact contact = contacts.Find(c => c.Name.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)
        || c.PhoneNumber.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));

        return contact;
    }
}
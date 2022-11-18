using System;

namespace doubble_link_list
{
    class Node
    {
        /*node class represent the node of doubly linked list
         * it consists of the information part and links to
         * it succesting and precenting 
         * in tern of next and previous */
        public int noMhs;
        public string name;
        // point to the sucedding node
        public Node next;
        public Node prev;

    }
    class DoubleLinkedList
    {
        Node START;

        // constructor

        public void addNote()
        {
            int nim;
            string nm;
            Console.WriteLine("\nEnter the rol number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.noMhs = nim;
            newNode.name = nm;

            // check if the list empty
            if (START == null || nim <= START.noMhs)
            {
                if ((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.next = null;
                START = newNode;
                return;
            }
            /*if the node is to be inserted at between two node*/
            Node previous, current;
            for (current = previous = START;
                 current != null && nim >= current.noMhs;
                 previous = current, current = current.next)
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed ");
                }
            }
            /*On the execute of the above for loop, prev and 
            * current will point to those nodes
            * between which the new node is to be inserted*/
            newNode.next = current;
            newNode.prev = previous;

            // if the node is to be inserted at the end of the list
            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.prev = current;    
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = current = START;
            while (current != null &&
                rollNo != current.noMhs)
            {
                previous.next = current;    
                current = current.next;
            }
            return (current != null);
        }
        public bool dellNode (int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            // the begining of data
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            // node between two nodes in the list
            if(current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            /* if the to be deleted is in between the list then the following lines of is executed.*/
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the Descending order of" + "Roll number are:\n");
                Node currentNode;
                //membawa currentNode ke node paling belakang
                currentNode = START;
                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }
                //membawa data dari last node ke first node
                while (currentNode != null)
                {
                    Console.Write(currentNode.noMhs + " " + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\n Record in the Descanding order of" + "roll number are\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                { }

                while (currentNode != null)
                {
                    Console.WriteLine(currentNode.noMhs + "" + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from to the list");
                    Console.WriteLine("3. View all record in the asceding order of roll number");
                    Console.WriteLine("4. View all record in  the descending order of roll number");
                    Console.WriteLine("5. Search for a record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.WriteLine("Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.WriteLine("\nEnter the roll number of the student" +
                                    "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number " + rollNo + "deleted \n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("\nEnter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.noMhs);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("invalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered");
                }
            }
        }
    }
}
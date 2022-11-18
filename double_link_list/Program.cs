using System

namespace doubble_linked_list
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
}
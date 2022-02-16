using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lab02
{
    public class GenericList<T>
    {
        Node<T> Head;

        void InsertNew(T value) 
        {
            Node<T> NewNode = new Node<T>();
            NewNode.data = value;
            NewNode.next = Head;
            if (Head != null)
            {
                Head.previous = NewNode;
            }
            Head = NewNode;
            
        }

    }
}

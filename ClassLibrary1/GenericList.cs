using System.Collections.Generic;

namespace ClassLibrary1
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

        void InsertNew(T value, int index)
        {
            if (index == 0)
            {
                InsertNew(value);
            }
            else
            {
                Node<T> NewNode = new Node<T>();
                NewNode.data = value;
                int CurrentPos = 0;
                Node<T> CurrentNode = Head;
                while (CurrentPos < index)
                {
                    CurrentNode = CurrentNode.next;
                    CurrentPos++;
                }
                NewNode.next = CurrentNode;
                CurrentNode.previous.next = NewNode;
                NewNode.previous = CurrentNode.previous;
                if (NewNode.next != null)
                {
                    CurrentNode.next.previous = NewNode;
                }
            }
        }

        int Search(T value)
        {
            int count = 0;
            for (Node<T> index = Head; index != null; index = index.next)
            {
                if (EqualityComparer<T>.Default.Equals(index.data, value))
                {
                    return count;
                }
                count++;
            }
            return -1;
        }

        bool Delete(T value)
        {
            Node<T> Current = Head;
            int index = Search(value);
            if (index == -1)
            {
                return false;
            }
            else if (index == 0)
            {
                Current = Head;
                Head.next.previous = null;
                Head = Head.next;
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    Current = Current.next;
                }
                Current.previous.next = Current.next;
                Current.next.previous = Current.previous;
            }
            //Hay que eliminar el nodo current
            return true;
        }
    }
}

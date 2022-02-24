using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class GenericList<T> : IEnumerable<T>, IEnumerable
    {
        Node<T> Head;
        public int Length = 0;

        public void Add(T value)
        {
            Node<T> NewNode = new Node<T>();
            NewNode.data = value;
            NewNode.next = Head;
            if (Head != null)
            {
                Head.previous = NewNode;
            }
            Head = NewNode;
            this.Length++;
        }

        void Add(T value, int index)
        {
            if (index == 0)
            {
                Add(value);
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

        public T SearchObject(int index)
        {
            if (index >= 0 && index < Length)
            {
                Node<T> CurrentNode = Head;
                int ubicacion = 0;

                while (ubicacion < index)
                {
                    CurrentNode = CurrentNode.next;
                    ubicacion++;
                }
                return CurrentNode.data;
            }
            return default(T);
        }

        public bool Delete(T value)
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
            this.Length--;
        }

        public bool DeleteP(int index)
        {
            Node<T> Current = Head;
            
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
            this.Length--;
        }
        //public IEnumerator<T> GetEnumerator()
        //{
        //    Node<T> node = Head;
        //    while (node != null)
        //    {
        //        yield return node.data;
        //        node = node.next;
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}

        private GenericList<T>.LinkedListEnumerator GetEnumerator()
        {
            return new LinkedListEnumerator(this.Head, this.Length);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }

        public struct LinkedListEnumerator : IEnumerator<T>, IEnumerator
        {
            private Node<T> head;
            private Node<T> currentLink;
            private int length;
            private bool startedFlag;

            public LinkedListEnumerator(Node<T> head, int length)
            {
                this.head = head;
                this.currentLink = null;
                this.length = length;
                this.startedFlag = false;
            }

            public T Current
            {
                get { return this.currentLink.data; }
            }

            public void Dispose()
            {
                this.head = null;
                this.currentLink = null;
            }

            object IEnumerator.Current
            {
                get { return this.currentLink.data; }
            }

            public bool MoveNext()
            {
                if (this.startedFlag == false)
                {
                    this.currentLink = this.head;
                    this.startedFlag = true;
                }
                else
                {
                    this.currentLink = this.currentLink.next;
                }

                return this.currentLink != null;
            }

            public void Reset()
            {
                this.currentLink = this.head;
            }
        }
    }
}

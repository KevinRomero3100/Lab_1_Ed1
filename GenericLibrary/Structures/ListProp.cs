using System;
using Genericos.Interfeces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Genericos.Structures
{
    public class ListProp<T>: StructutreBase<T>, IEnumerable<T>
    {
        public Node<T> Head { get; set; }

        public void Add (T value)
        {
            Insert(value);
        }
		public void Del(T value)
		{
			Delete(value);
		}


        protected override void Insert(T value)
        {

			Node<T> NewNode = new Node<T>();
			NewNode.Value = value;

			if (Head == null)
			{
				Head = NewNode;
			}
			else
			{
				Node<T> search;

				search = Head;
				while (search.Next != null)
				{
					search = search.Next;
				}
				search.Next = NewNode;
			}
		}

		protected override void Delete(T value)
		{
			Node<T> search;
			Node<T> last = null;
			search = Head;

			if (Head.Value.Equals(value))
			{
				Head = Head.Next;
			}
			else
			{
				while (!search.Value.Equals(value))
				{
					last = search;
					search = search.Next;
				}
				if (search.Next == null)
				{
					last.Next = null;
				}
				else
				{
					last.Next = search.Next;
				}

			}
		}

		



		public IEnumerator<T> GetEnumerator()
		{
			Node<T> search;
			search = Head;
			while (search.Next != null)
			{
				yield return search.Value;
				search = search.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

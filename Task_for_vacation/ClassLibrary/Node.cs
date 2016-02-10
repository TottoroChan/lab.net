
namespace ClassLibrary
{
	public class Node<T>
	{
		public T info;
		public Node<T> next;
		public Node<T> previous;

		public Node(T t)
		{
			info = t;
			next = null;
			previous = null;
		}

	}
}

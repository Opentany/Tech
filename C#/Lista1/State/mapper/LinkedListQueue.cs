using System.Collections.Generic;

namespace State.mapper
{
    public class LinkedListQueue<T> : Queue<T> {
	
	private LinkedList<T> backingList;

	public LinkedListQueue() {
		this.backingList = new LinkedList<T>();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.util.Queue#offer(java.lang.Object)
	 */
	public bool offer(T e)
	{
	    return this.backingList.Contains(e);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.util.Queue#peek()
	 */
	public T peek() {

		if (backingList.Count!=0)
		{
		    return this.backingList.First.Value;
		}
		return default(T);

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.util.Queue#poll()
	 */

	public T poll() {
		T el = this.backingList.First.Value;
	    this.backingList.Remove(el);
		return el;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.util.AbstractCollection#iterator()
	 */

	public IEnumerator<T> iterator()
	{
	    return this.backingList.GetEnumerator();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.util.AbstractCollection#size()
	 */

	public int size() {

		return this.backingList.Count;
	}
}
}
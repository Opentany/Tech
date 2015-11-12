namespace State.mapper
{
    public class LinkedListQueue<T> extends AbstractQueue<T> {
	
	private LinkedList<T> backingList;

	public LinkedListQueue() {
		this.backingList = new LinkedList<T>();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.util.Queue#offer(java.lang.Object)
	 */
	@Override
	public boolean offer(T e) {
		return this.backingList.add(e);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.util.Queue#peek()
	 */
	@Override
	public T peek() {

		if (!this.backingList.isEmpty()) {
			return this.backingList.getFirst();
		}
		return null;

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.util.Queue#poll()
	 */
	@Override
	public T poll() {
		T el = this.backingList.getFirst();
		this.backingList.removeFirst();
		return el;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.util.AbstractCollection#iterator()
	 */
	@Override
	public Iterator<T> iterator() {
		return this.backingList.iterator();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.util.AbstractCollection#size()
	 */
	@Override
	public int size() {

		return this.backingList.size();
	}
}
}
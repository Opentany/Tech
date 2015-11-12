using System;
using Flyweight.model;

namespace Flyweight.dao
{
    public interface Dao<T> where T : ModelObject {

	/**
	 * @param property
	 * @param value
	 * @return
	 */
	T findBy(String property, String value);

}
}
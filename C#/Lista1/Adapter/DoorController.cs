using System;
using Adapter.model;

namespace Adapter
{
    public interface IDoorController
    {
        /**
	 * Add a controlled door
	 * @param targetDoor
	 */
        void AddDoor(IDoor targetDoor);

        /**
	 * @param mocekedDoor
	 * @throws DoorNotManagedException 
	 * @throws IncorrectDoorCodeException 
	 */
        void OpenDoor(IDoor door, String doorCode); // throws DoorNotManagedException, IncorrectDoorCodeException;

        void CloseDoor(IDoor door); // DoorNotManagedException;

        /**
	 * @return
	 */
        int CountManagedDoors();
    }
}

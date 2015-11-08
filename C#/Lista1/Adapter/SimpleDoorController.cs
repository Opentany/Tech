using System;
using System.Collections.Generic;
using System.Linq;
using Adapter.model;

namespace Adapter
{
    public class SimpleDoorController : IDoorController
    {
        private readonly List<IDoor> _managedDoors;

        public SimpleDoorController()
        {
            this._managedDoors = CreateManagedDoorsComposite();
        }

        /*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.structural.adapter.DoorController
	 * #addDoor
	 * (eu.jpereira.trainings.designpatterns.structural.adapter.model.Door)
	 */

        public void AddDoor(IDoor managedDoor)
        {
            if (!_managedDoors.Contains(managedDoor))
            {
                _managedDoors.Add(managedDoor);
            }
        }

        /*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.structural.adapter.DoorController
	 * #openDoor
	 * (eu.jpereira.trainings.designpatterns.structural.adapter.model.Door)
	 */

        public void OpenDoor(IDoor door, String doorCode)
        {
// throws DoorNotManagedException, IncorrectDoorCodeException{
            GetDoor(door).Open(doorCode);
        }

        /**
	 * FActory method
	 * 
	 * @return
	 */

        protected List<IDoor> CreateManagedDoorsComposite()
        {
            return new List<IDoor>();
        }

        /* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.structural.adapter.DoorController#countManagedDoors()
	 */

        public int CountManagedDoors()
        {
            return _managedDoors.Count;
        }

        /* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.structural.adapter.DoorController#closeDoor(eu.jpereira.trainings.designpatterns.structural.adapter.model.Door)
	 */

        public void CloseDoor(IDoor door)
        {
// throws DoorNotManagedException {
            GetDoor(door).Close();
        }


        private IDoor GetDoor(IDoor door)
        {
// throws DoorNotManagedException {
            if (_managedDoors.Contains(door))
            {
                return _managedDoors.ElementAt(_managedDoors.IndexOf(door));
            }
            throw new DoorNotManagedException();
        }
    }
}
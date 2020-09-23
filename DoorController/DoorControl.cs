using System;
using System.Collections.Generic;
using System.Text;

namespace DoorController
{
    class DoorControl
    {
        public IAlarm Alarm
        {
            get;
            set;
        }

        public IDoor Door
        {
            get;
            set;
        }

        public IEntryNotification EntryNotification
        {
            get;
            set;
        }

        public IUserValidation UserValidation
        {
            get;
            set;
        }

        public DoorControl(IAlarm alarm, IDoor door, IEntryNotification entryNotification, IUserValidation userValidation)
        {
            Alarm = alarm;
            Door = door;
            EntryNotification = entryNotification;
            UserValidation = userValidation;
        }

        public void RequestEntry(string id)
        {
            if (UserValidation.ValidateEntryRequest(id))
            {
                EntryNotification.NotifyEntryGranted();
                Door.Open();
            }
            else
            {
                EntryNotification.NotifyEntryDenied();
            }
        }

        public void DoorOpen()
        {
            Door.Close();
        }

        public void DoorOpened()
        {
            Door.Close();
            Alarm.RaiseAlaram();
        }

        public void DoorClosed()
        {

        }

    }
}

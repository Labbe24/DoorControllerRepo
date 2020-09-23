using System;
using System.Collections.Generic;
using System.Text;

namespace DoorController
{
    public interface IEntryNotification
    {
        void NotifyEntryGranted();

        void NotifyEntryDenied();
    }
}

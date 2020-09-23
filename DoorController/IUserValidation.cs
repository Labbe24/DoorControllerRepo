using System;
using System.Collections.Generic;
using System.Text;

namespace DoorController
{
    public interface IUserValidation
    {
        bool ValidateEntryRequest(string id);
    }
}

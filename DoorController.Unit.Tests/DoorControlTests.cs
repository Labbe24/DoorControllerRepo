using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;


namespace DoorController.Unit.Tests
{
    [TestFixture]
    class DoorControlTests
    {
        private DoorControl _uut;
        private IAlarm _alarm;
        private IDoor _door;
        private IEntryNotification _entryNotification;
        private IUserValidation _userValidation;

        [SetUp]
        public void Setup()
        {
            _alarm = Substitute.For<IAlarm>();
            _door = Substitute.For<IDoor>();
            _entryNotification = Substitute.For<IEntryNotification>();
            _userValidation = Substitute.For<IUserValidation>();

            _uut = new DoorControl(_alarm, _door, _entryNotification, _userValidation);
        }


        // **** RequestEntry ****

        [Test]
        public void RequestEntryTest_ValidateEntryTrue_NotifyEntryGranted()
        {
            _userValidation.ValidateEntryRequest("id").Returns(true);
            _uut.RequestEntry("id");
            _entryNotification.Received(1).NotifyEntryGranted();
        }
        [Test]
        public void RequestEntryTest_ValidateEntryTrue_Open()
        {
            _userValidation.ValidateEntryRequest("id").Returns(true);
            _uut.RequestEntry("id");
            _door.Received(1).Open();
        }
        [Test]
        public void RequestEntryTest_ValidateEntryFalse_NotifyEntryDenied()
        {
            _userValidation.ValidateEntryRequest("id").Returns(false);
            _uut.RequestEntry("id");
            _entryNotification.Received(1).NotifyEntryDenied();
        }


        // ***** DoorOpen *****
        [Test]
        public void DoorOpenTest_DoorOpen_DoorClose()
        {
            _uut.DoorOpen();
            _door.Received(1).Close();
        }

        // ***** DoorOpened *****
        [Test]
        public void DoorOpenedTest_DoorOpen_DoorClose()
        {
            _uut.DoorOpened();
            _door.Received(1).Close();
        }
        [Test]
        public void DoorOpenedTest_DoorOpen_RaiseAlaram()
        {
            _uut.DoorOpened();
            _alarm.Received(1).RaiseAlaram();
        }

        // ***** DoorClosed *****
        //[Test]
        //public void DoorClosedTest_DoorClosed_
    }


}

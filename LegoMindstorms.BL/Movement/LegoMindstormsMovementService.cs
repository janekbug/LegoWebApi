using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LegoMindstorms.BL.Movement
{
    public class LegoMindstormsMovementService : IMovementService
    {
        private Brick _brick;

        public LegoMindstormsMovementService()
        {
            _brick = new Brick(new BluetoothCommunication("COM4"));
            Task.WaitAll(this.Connect());
        }

        private Task Connect()
        {
            return _brick.ConnectAsync();
        }

        public async Task MoveBackward()
        {
            await _brick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.B | OutputPort.C, -100);
        }

        public async Task MoveForward()
        {
            await _brick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.B | OutputPort.C, 100);
        }

        public async Task Stop()
        {
            await _brick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.C | OutputPort.B, 0);
        }

        public async Task TurnRight()
        {
            Task t1 = _brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.C, 100, 660, false);
            Task t2 = _brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.B, -100, 660, false);
            await Task.WhenAll(t1, t2);
        }

        public async Task TurnLeft()
        {
            Task t1 = _brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.C, -100, 660, false);
            Task t2 = _brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.B, 100, 660, false);
            await Task.WhenAll(t1, t2);
        }
    }
}

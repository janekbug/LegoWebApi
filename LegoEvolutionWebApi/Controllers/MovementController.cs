using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LegoMindstorms.BL.Movement;

namespace LegoEvolutionWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Movement")]
    public class MovementController : Controller
    {
        private IMovementService _service;

        public MovementController(IMovementService service)
        {
            _service = service;
        }

        [HttpPost("forward")]
        public async Task Forward()
        {
            await _service.MoveForward();
        }

        [HttpPost("backward")]
        public async Task Backward()
        {
            await _service.MoveBackward();
        }

        [HttpPost("stop")]
        public async Task Stop()
        {
            await _service.Stop();
        }

        [HttpPost("left")]
        public async Task Left()
        {
            await _service.TurnLeft();
        }

        [HttpPost("right")]
        public async Task Right()
        {
            await _service.TurnRight();
        }
    }
}
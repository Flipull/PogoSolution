using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PogoWebCore;
using PogoWebCore.Models;

namespace PogoWebCore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandmarksController : ControllerBase
    {
        private readonly PogoContext _context;

        public LandmarksController(PogoContext context)
        {
            _context = context;
        }

        // GET: api/LandmarkTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Landmark>>> 
            GetLandmarks([FromQuery]double? longitude, [FromQuery] double? lattitude)
        {
            return await _context.Landmarks.ToListAsync();
        }
    }
}

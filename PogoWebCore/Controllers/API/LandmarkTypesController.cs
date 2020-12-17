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
    public class LandmarkTypesController : ControllerBase
    {
        private readonly PogoContext _context;

        public LandmarkTypesController(PogoContext context)
        {
            _context = context;
        }

        // GET: api/LandmarkTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LandmarkType>>> GetLandmarkTypes()
        {
            return await _context.LandmarkTypes.ToListAsync();
        }
    }
}

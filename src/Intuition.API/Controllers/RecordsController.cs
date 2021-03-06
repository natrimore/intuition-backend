using Intuition.Services;
using Intuition.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intuition.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "CustomerPolicy", AuthenticationSchemes = "Bearer")]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordService _service;
        private readonly ILogger<RecordsController> _logger;

        public RecordsController(IRecordService service, ILogger<RecordsController> logger)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));

            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] DateTime searchDate)
        {
            if (searchDate != null)
            {
                return Ok(_service.GetByDateAsync(searchDate));
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RecordToAddDTO record)
        {
            var userId = Guid.Parse(User.Claims.SingleOrDefault(w => w.Type == "id").Value);

            var model = await _service.AddAsync(userId, record.Data);

            if (model == null)
            {
                return BadRequest();
            }

            return Ok(model);
        }
    }
}

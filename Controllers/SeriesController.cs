﻿using Microsoft.AspNetCore.Mvc;
using Api.MyFlix.Models;
using Api.MyFlix.Services.Interfaces;
using Api.MyFlix.Models.Object;


namespace Api.MyFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;
        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        // GET: api/Series
        [HttpGet]
        public async Task<ActionResult<Result>> GetSerie([FromQuery] string search = null, [FromQuery]string keys = null, [FromQuery] int currentPage = 1, [FromQuery] int pageSize = 15, [FromQuery] string sortOrder = "title")
        {
            var baseUrl = string.Concat(Request.Scheme,"://",Request.Host.ToUriComponent());
            return await _seriesService.GetSerie(search, keys,currentPage, pageSize, sortOrder, baseUrl);
        }

        // GET: api/Series/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReturnSerie>> GetSerieById(int id)
        {
            return await _seriesService.GetSerieById(id);
        }

        // GET: api/Series/one-piece
        [HttpGet("{key}")]
        public async Task<ActionResult<ReturnSerie>> GetSerieByKey(string key)
        {
            var baseUrl = string.Concat(Request.Scheme, "://", Request.Host.ToUriComponent());
            return await _seriesService.GetSerieByKey(key, baseUrl);
        }

        // PUT: api/Series/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerie(int id, Serie Serie)
        {
            return await _seriesService.PutSerie(id, Serie);
        }

        // POST: api/Series
        [HttpPost]
        public async Task<ActionResult<Serie>> PostSerie(ParamSerie paramSerie)
        {
            return await _seriesService.PostSerie(paramSerie);
        }
        // POST: api/Series/List
        [HttpPost("List")]
        public async Task<ActionResult<Serie>> PostSeries(List<ParamSerie> paramSeries)
        {
            return await _seriesService.PostSeries(paramSeries);
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            return await _seriesService.DeleteSerie(id);    
        }
    }
}

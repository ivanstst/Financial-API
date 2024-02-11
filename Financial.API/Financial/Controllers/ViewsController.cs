using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Financial.Data;
using Financial.Data.Models;
using Financial.Services;
using Financial.Services.Interfaces;
namespace Financial.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewsController : ControllerBase
    {
        private readonly IViewService _viewService;

        public ViewsController(IViewService viewService)
        {
            _viewService = viewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<View>>> GetViews()
        {
            var views = await _viewService.GetViewsAsync(1);
            if (views == null)
            {
                return NotFound();
            }
            return views;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<View>> GetView(int id)
        {
            var view = await _viewService.GetViewAsync(id, 2);
            if (view == null)
            {
                return NotFound();
            }

            return view;
        }

        [HttpPost]
        public async Task<ActionResult<View>> PostView(View view)
        {
            await _viewService.CreateViewAsync(view);

            return CreatedAtAction("GetView", new { id = view.Id }, view);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteView(int id)
        {
            await _viewService.DeleteViewAsync(id);

            return NoContent();
        }
    }
}

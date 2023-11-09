using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StudForum.Attributes;
using StudForum.Repositories.Interfaces;

namespace StudForum.Controllers
{
    [ApiController]
    [EnableCors("ReactPolicy")]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _rep;

        public CategoryController(ICategoryRepository rep)
        {
            _rep = rep;
        }

        [Route("getlist")]
        [HttpGet]
        [JwtAuth]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var result = new List<Dtos.Category.CategoryResDto>();
                foreach(var c in await _rep.GetAllAsync())
                {
                    result.Add(new Dtos.Category.CategoryResDto() { Id = c.Id, Name = c.Name  });

                    foreach(var s in c.Subcategories)
                    {
                        result.Last().Subcategories.Add(new Dtos.Category.SubcategoryRes() { Id = s.Id, Name = s.Name });
                    }
                }

                return Ok(
                    result
                   );
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}

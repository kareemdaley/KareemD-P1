using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace CreateAPI.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrderController : ControllerBase
    {
        private readonly IRepository _repository;

        public OrderController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: /api/orders/?name= "???"
        [HttpGet]
        public async Task<IActionResult> GetAllByNameAsync([FromQuery] string name)
        {
            IEnumerable<Transaction> Transactions = await _repository.GetOrderDetailsAsync(name);

            

            return new JsonResult(Transactions);
        }

       
    }
}


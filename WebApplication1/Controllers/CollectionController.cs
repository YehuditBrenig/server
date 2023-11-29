using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService _CollectionService;

        public CollectionController(ICollectionService CollectionService)
        {
            _CollectionService = CollectionService;
        }
        // GET: api/<CollectionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CollectionController>/5
        [HttpGet("{collectionSymbolization}")]
        public IActionResult  Get(string collectionSymbolization)
        {
            try{

              Collection res =_CollectionService.get(collectionSymbolization);

                return Ok(res);

            }
            catch( Exception error)
            {

                throw new Exception (collectionSymbolization, error);
            }

        }


        //POST api/<CollectionController>
        [HttpPost]


        public IActionResult Post([FromBody] MyImage[] images)
        {
            try
            {
                bool res = _CollectionService.post(images);
                return Ok(res);

            }
            catch (Exception error)
            {
                throw new Exception("can't save ", error);
            }

        }

        //put api/<CollectionController>
        [HttpPut]


        public IActionResult put([FromBody] Collection collection)
        {
            try
            {
                bool res = _CollectionService.put(collection);
                return Ok(res);

            }
            catch (Exception error)
            {
                throw new Exception("can't save ", error);
            }

        }




    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReserveIt.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class WordListController : ControllerBase
   {
      private static readonly List<string> allwords = new List<string>
      {
         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
      };
      [HttpGet]
      public async Task<IActionResult> GET(int n)
      {
         if (allwords.Count > 0)
         {
            var st = string.Join(" ", allwords);
            var words = st.ToCharArray();
            var result = "";
            var counter = 0;
            foreach (var word in words)
            {

               if (counter >= n)
               {
                  result += "\n";
                  result += word;
                  counter = 0;
               }
               else
               {
                  result += word;
                  counter++;
               }
            }
            return Ok(result);

         }
         else
         {
            allwords.Add("First");
            return Ok(allwords);
         }



      }
      [HttpPost]
      public IActionResult Post([FromBody] IEnumerable<string> items)
      {

         allwords.AddRange(items);

         string i = "";

         if (Request.Headers.TryGetValue("page-size", out var pz))
         {
            //use testId value
            i = pz;
         }

         return Created("", pz);
      }
   }
}

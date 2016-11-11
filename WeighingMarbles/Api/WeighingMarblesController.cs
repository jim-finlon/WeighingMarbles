using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using WeighingMarbles.Services;
using WeighingMarbles.ViewModels;

namespace WeighingMarbles.Api
{
    public class WeighingMarblesController : ApiController
    {
        [HttpGet]
        [ActionName("WeighMarbles")]
        [ResponseType(typeof(List<MarbleWeighing>))]
        public List<MarbleWeighing> WeighMarbles(int numberOfMarbles, int heavyMarbleId)
        {
            var service = new MarbleService();
            var vm = service.StartProcess(numberOfMarbles, heavyMarbleId);
            return vm;
        }

    }
}

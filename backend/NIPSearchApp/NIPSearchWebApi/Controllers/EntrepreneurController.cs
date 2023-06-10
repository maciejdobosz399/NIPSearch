using Microsoft.AspNetCore.Mvc;
using NIPSearch.WebApi.Interfaces;
using NIPSearchApp.Data.Interfaces;
using NIPSearchWebApi.Contracts;
using NIPSearchWebApi.Utils;

namespace NIPSearchWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntrepreneurController : ControllerBase
    {
        private readonly ILogger<EntrepreneurController> _logger;
        private readonly ISearchRepository _searchRepository;
        private readonly IEnterpreneurService _enterpreneurService;

        public EntrepreneurController(ILogger<EntrepreneurController> logger, ISearchRepository searchRepository, IEnterpreneurService enterpreneurService)
        {
            _logger = logger;
            _searchRepository = searchRepository;
            _enterpreneurService = enterpreneurService;
        }

        [HttpGet]
        [Route("{nip}")]
        public async Task<IActionResult> GetAsync(string nip)
        {
            try
            {
                _logger.LogInformation(String.Format("Getting data, nip: {0}", nip));

                if (!NIPUtils.CheckNIPFormat(nip))
                    return NotFound("Niepoprawny NIP");

                var (result, isSuccess) = await _searchRepository.SearchAsync(nip);

                if(!isSuccess)
                    return NotFound("Nie znaleziono.");

                _enterpreneurService.Create(result);

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(String.Format("Error at {0}, exception: {1}", DateTime.Now, e.Message));
                return BadRequest("Coœ posz³o nie tak");
            }
        }
    }
}
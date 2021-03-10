using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSI.API.Dtos;
using MSI.API.Services;
using MSI.Domain;
using System;
using System.Collections.Generic;

namespace MSI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectAddressController : ControllerBase
    {
        private readonly ILogger<SubjectAddressController> _logger;
        private readonly IContactRepository _contactRepository;

        public SubjectAddressController(ILogger<SubjectAddressController> logger, IContactRepository contactRepository)
        {
            _logger = logger;
            _contactRepository = contactRepository;
        }

        [HttpGet("{id}", Name = "GetSubjectAddress")]
        public ActionResult<SubjectAddressDto> GetSubjectAddress(int id)
        {
            var model = _contactRepository.GetSubjectAddressById(id);

            if (model == null)
            {
                _logger.LogInformation($"Cannot find the subject address with id {id}");
                return NotFound();
            }

            var addressModel = model.Address;
            var nameModel = model.Subject;

            try
            {
                var dto = new SubjectAddressDto
                {
                    Address = new AddressDto
                    {
                        Address = string.Join(" ", addressModel.StreetNumber, addressModel.Direction, addressModel.StreetName, addressModel.StreetType),
                        City = addressModel.City,
                        State = addressModel.State,
                        Zip = addressModel.Zip
                    },
                    Subject = new NameDto
                    {
                        FirstName = nameModel.FirstName,
                        LastName = nameModel.LastName,
                        Mi = nameModel.Mi,
                        Suffix = nameModel.Suffix
                    }
                };
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult<IList<SubjectAddressDto>> GetAllSubjectAddresses()
        {
            var models = _contactRepository.GetAllSubjectAddresses();

            if (models == null)
            {
                _logger.LogInformation($"Cannot find any subject addresses");
                return NotFound();
            }


            var results = new List<SubjectAddressDto>();

            try
            {
                foreach (var model in models)
                {
                    var addressModel = model.Address;
                    var nameModel = model.Subject;
                    var dto = new SubjectAddressDto
                    {
                        Address = new AddressDto
                        {
                            Address = string.Join(" ", addressModel.StreetNumber, addressModel.Direction, addressModel.StreetName, addressModel.StreetType),
                            City = addressModel.City,
                            State = addressModel.State,
                            Zip = addressModel.Zip
                        },
                        Subject = new NameDto
                        {
                            FirstName = nameModel.FirstName,
                            LastName = nameModel.LastName,
                            Mi = nameModel.Mi,
                            Suffix = nameModel.Suffix
                        }
                    };

                    results.Add(dto);
                }
                
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult<SubjectAddressDto> Post([FromBody] SubjectAddressDto subjectAddress)
        {
            var addressDto = subjectAddress.Address;
            var nameDto = subjectAddress.Subject;


            try
            {
                if(addressDto.Address == null)
                {
                    return BadRequest("Address is mandatory");
                }
                var addressDetails = addressDto.Address.Split(' ');
                var addressModel = new Address
                {
                    StreetNumber = addressDetails.Length > 0 ? addressDetails[0] : "",
                    Direction = addressDetails.Length > 1 ? addressDetails[1] : "",
                    StreetName = addressDetails.Length > 2 ? addressDetails[2] : "",
                    StreetType = addressDetails.Length > 3 ? addressDetails[3] : "",
                    City = addressDto.City,
                    State = addressDto.State,
                    Zip = addressDto.Zip
                };

                var nameModel = new Name
                {
                    FirstName = nameDto.FirstName,
                    LastName = nameDto.LastName,
                    Mi = nameDto.Mi,
                    Suffix = nameDto.Suffix
                };

                var subjectAddressModel = new SubjectAddress
                {
                    Address = addressModel,
                    Subject = nameModel
                };

                _contactRepository.AddSubjectAddress(subjectAddressModel);

                return CreatedAtAction(nameof(GetSubjectAddress), new { id = subjectAddressModel.SubjectAddressId }, subjectAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crm.Application.Interfaces;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.Insurance;

namespace Crm.Application.Services
{
    public class IntroducedService: IIntroducedService
    {
        private readonly IIntroducedRepository _introducedRepository;

        public IntroducedService(IIntroducedRepository introducedRepository)
        {
            _introducedRepository = introducedRepository;
        }

        public List<Introduced> GetIntroducedsByInsuredId(int insuredId)
        {
            return _introducedRepository.GetIntroducedsByInsuredId(insuredId);
        }
    }
}

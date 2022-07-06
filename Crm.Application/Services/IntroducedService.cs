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

        public void AddIntroduced(Introduced introduced)
        {
            _introducedRepository.AddIntroduced(introduced);
        }

        public Introduced? GetIntroducedByIntroducedId(int introducedId)
        {
            return _introducedRepository.GetIntroducedByIntroducedId(introducedId);
        }

        public void UpdateIntroduced(Introduced introduced)
        {
            introduced.UpdateDate=DateTime.Now;
            _introducedRepository.UpdateIntroduced(introduced);
        }

        public void DeleteIntroduced(int introducedId, int userId)
        {
            var introduced = GetIntroducedByIntroducedId(introducedId);

            if(introduced==null)
                return;

            introduced.DeleteDate=DateTime.Now;
            introduced.UserId = userId;

            UpdateIntroduced(introduced);
        }
    }
}

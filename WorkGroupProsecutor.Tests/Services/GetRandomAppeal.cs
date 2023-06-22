using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Tests.Services
{
    public static class GetRandomAppeal
    {
        public static IEnumerable<RedirectedAppealModelDTO> GetTestRedirectedAppealModelDTOs(int capacity)
        {
            var resultList = new RedirectedAppealModelDTO[capacity];
            for (int i = 0; i < capacity; i++)
            {
                resultList[i] = GenerateAppealModelDTO();
            }
            return resultList;
        }

        public static RedirectedAppealModelDTO GenerateAppealModelDTO()
        {
            return new RedirectedAppealModelDTO()
            {
                Id = GetRandom.Id(),
                RegistrationNumber = GetRandom.String(),
                NadzorHyperlink = GetRandom.String(),
                ApplicantFullName = GetRandom.String(),
                DepartmentId = GetRandom.Byte(),
                DepartmentAssessment = GetRandom.String(),
                YearInfo = GetRandom.Byte(),
                PeriodInfo = GetRandom.String(),
                District = GetRandom.String(),
                RecipientAgency = GetRandom.String(),
                DecisionBasis = GetRandom.String()
            };
        }
    }
}

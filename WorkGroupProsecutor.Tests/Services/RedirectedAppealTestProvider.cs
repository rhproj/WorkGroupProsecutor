using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Tests.Services
{
    internal class RedirectedAppealTestProvider
    {
        internal static IEnumerable<RedirectedAppealModel> RedirectedAppealModelTestCollection()
        {
            var resultList = new RedirectedAppealModel[]
            {
                GenerateAppealModel(1,2020, "period1", "district1", "K01"),
                GenerateAppealModel(2,2020, "period1", "district1", "K02", assessment:"A"),
                                    
                GenerateAppealModel(3,2020, "period2", "district2", "K01"),
                GenerateAppealModel(4,2030, "period1", "district3", "D01", assessment:"B"),
                                    
                GenerateAppealModel(5,2030, "period1", "district3", "K01"),
                GenerateAppealModel(6,2030, "period2", "district2", "D01"),
                                    
                GenerateAppealModel(7,2030, "period1", "district3", "D01"),
                GenerateAppealModel(8,2030, "period3", "district3", "K01", assessment:"A"),
                                   
                GenerateAppealModel(9,2030, "period1", "district2", "D01", assessment:"B"),
                GenerateAppealModel(10,2030, "period1", "district3", "K01")
            };
            return resultList;
        }

        private static RedirectedAppealModel GenerateAppealModel(int id, int year, string period, string district, string department, string? assessment = null)
        {
            return new RedirectedAppealModel()
            {
                Id = id,
                RegistrationNumber = GetRandom.String(),
                NadzorHyperlink = GetRandom.String(),
                ApplicantFullName = GetRandom.String(),
                RecipientAgency = GetRandom.String(),
                DecisionBasis = GetRandom.String(),

                YearInfo = year,
                PeriodInfo = period,
                District = district,
                Department = GenerateDepartment(department),
                DepartmentAssessment = assessment
            };
        }

        private static Department GenerateDepartment(string departmentIndex)
        {
            return new Department()
            {
                Id = GetRandom.Id(),
                DepartmentIndex = departmentIndex,
                DepartmentName = GetRandom.String()
            };
        }


        internal static IEnumerable<RedirectedAppealModelDTO> GetTestRedirectedAppealModelDTOs(int capacity)
        {
            var resultList = new RedirectedAppealModelDTO[capacity];
            for (int i = 0; i < capacity; i++)
            {
                resultList[i] = GenerateAppealModelDTO();
            }
            return resultList;
        }

        internal static RedirectedAppealModelDTO GenerateAppealModelDTO()
        {
            return new RedirectedAppealModelDTO()
            {
                Id = GetRandom.Id(),
                RegistrationNumber = GetRandom.String(),
                NadzorHyperlink = GetRandom.String(),
                ApplicantFullName = GetRandom.String(),
                DepartmentAssessment = GetRandom.String(),
                YearInfo = GetRandom.Byte(),
                PeriodInfo = GetRandom.String(),
                District = GetRandom.String(),
                RecipientAgency = GetRandom.String(),
                DecisionBasis = GetRandom.String(),
                Department = GenerateDepartment(GetRandom.String(3))
            };
        }
    }
}

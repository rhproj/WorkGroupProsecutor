using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Tests.Services
{
    internal class NoSolutionReturnsAppealTestProvider
    {
        internal static IEnumerable<NoSolutionAppealModel> NoSolutionReturnsAppealModelTestCollection()
        {
            var resultList = new NoSolutionAppealModel[]
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

        private static NoSolutionAppealModel GenerateAppealModel(int id, int year, string period, string district, string department, string? assessment = null)
        {
            return new NoSolutionAppealModel()
            {
                Id = id,
                RegistrationNumber = GetRandom.String(),
                NadzorHyperlink = GetRandom.String(),
                ApplicantFullName = GetRandom.String(),
                DecisionBasis = GetRandom.String(),
                DepartmentResolution = GetRandom.String(),

                YearInfo = year,
                PeriodInfo = period,
                District = district,
                Department = DepartmentGenerator.GenerateDepartment(department),
                DepartmentAssessment = assessment
            };
        }
    }
}
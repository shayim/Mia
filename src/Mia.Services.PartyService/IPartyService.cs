using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mia.Common.ViewModels.Applicants;

namespace Mia.Services.PartyService
{
    public interface IApplicantService
    {
        Task<IEnumerable<ApplicantListItemVm>> GetAll(string user);
        Task<ApplicantDetailVm> Get(string user, Guid applicantId);
        Task<ApplicantDetailVm> Add(string user, NewApplicantVm newApplicant);
        Task<IServiceResult<ApplicantDetailVm>> Update(string user, UpdateApplicantVm updateApplicant);
        Task<IServiceResult> Delete(string user, Guid applicantId);
    }

    public interface IServiceResult<T> : IServiceResult
    {
      T Entity { get; set; }
    }

    public interface IServiceResult
    {
        bool Sucess { get; set; }
        string ErrorMessage { get; set; }
    }
}

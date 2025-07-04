﻿using amsAPI.Models.AssignmentModel;
using amsAPI.Repositories.AssignmentRepository;
using Domain.Models.AssetModel;

namespace amsAPI.Services.AssignmentServ
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepo _assignmentRepo;

        public AssignmentService(IAssignmentRepo assignmentRep)
        {
            this._assignmentRepo = assignmentRep; 
        }
        public async Task AssignAssetAsync(AssignAssetRequestDto request)
        {
            var isAssetAssigned = await _assignmentRepo.IsAssetAlreadyAssignedAsync(request.AssetId);

            if (isAssetAssigned)
                if (isAssetAssigned)
                    throw new InvalidOperationException("Asset is already assigned.");
           
            try
            {
                var assigment = new AssignmentMdl
                {
                    AssetId = request.AssetId,
                    AdminId = request.AdminId,
                    EmployeeId = request.EmployeeId,
                    AssignedDate = DateTime.Now,
                    IsLinked = true
                };
               
                await _assignmentRepo.Add(assigment);
            }
            catch (Exception ex)
            {
         
                throw;
            }
        }
    }
}

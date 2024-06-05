using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Data_Access_Layer
{
    public class DALMission
    {
        private readonly AppDbContext _cIDbContext;

        public DALMission(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public List<DropDown> GetMissionThemeList()
        {
            return _cIDbContext.MissionTheme
                .Where(mt => !mt.IsDeleted) // Filter out deleted themes
                .Select(mt => new DropDown { Value = mt.Id, Text = mt.ThemeName })
                .ToList();
        }

        public List<DropDown> GetMissionSkillList()
        {
            return _cIDbContext.MissionSkill
                .Where(ms => !ms.IsDeleted) // Filter out deleted skills
                .Select(ms => new DropDown { Value = ms.Id, Text = ms.SkillName })
                .ToList();
        }

        public async Task<List<Missions>> MissionListAsync()
        {
            return await _cIDbContext.Missions
                                     .Where(ms => !ms.IsDeleted)
                                     .ToListAsync();
        }

        public string AddMission(Missions mission)
        {
            string result = "";

            mission.MissionOrganisationName = "";
            mission.CityName = "";
            mission.CountryName = "";
            mission.CreatedDate = DateTime.Now.ToUniversalTime();
            mission.MissionOrganisationDetail = "";
            mission.MissionApplyStatus = "";
            mission.MissionApproveStatus = "";
            mission.MissionAvilability = "";
            mission.MissionDateStatus = "";
            mission.MissionDeadLineStatus = "";
            mission.MissionDocuments = "";
            mission.MissionFavouriteStatus = "";
            mission.MissionSkillName = "";
            mission.MissionStatus = "";
            mission.MissionThemeName = "";
            mission.MissionType = "";
            mission.MissionVideoUrl = "";
            mission.ModifiedDate = DateTime.Now.ToUniversalTime();

            try
            {
                _cIDbContext.Missions.Add(mission);
                _cIDbContext.SaveChanges();
                result = "Mission added successfully.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Missions MissionDetailById(int id)
        {
            return _cIDbContext.Missions
                .FirstOrDefault(m => m.Id == id && !m.IsDeleted);
        }

        public async Task<string> UpdateMissionAsync(Missions mission)
        {
            try
            {
                var existingMission = await _cIDbContext.Missions.FirstOrDefaultAsync(mt => mt.Id == mission.Id && !mt.IsDeleted);
                if (existingMission != null)
                {
                    existingMission.MissionTitle = mission.MissionTitle;
                    existingMission.MissionDescription = mission.MissionDescription;
                    existingMission.MissionOrganisationName = mission.MissionOrganisationName;
                    existingMission.MissionOrganisationDetail = mission.MissionOrganisationDetail;
                    existingMission.CountryId = mission.CountryId;
                    existingMission.CityId = mission.CityId;
                    existingMission.StartDate = mission.StartDate;
                    existingMission.EndDate = mission.EndDate;
                    existingMission.MissionType = mission.MissionType;
                    existingMission.TotalSheets = mission.TotalSheets;
                    existingMission.RegistrationDeadLine = mission.RegistrationDeadLine;
                    existingMission.MissionThemeId = mission.MissionThemeId;
                    existingMission.MissionSkillId = mission.MissionSkillId;
                    existingMission.MissionImages = mission.MissionImages;
                    existingMission.MissionDocuments = mission.MissionDocuments;
                    existingMission.MissionAvilability = mission.MissionAvilability;
                    existingMission.MissionVideoUrl = mission.MissionVideoUrl;
                    existingMission.ModifiedDate = DateTime.Now;

                    await _cIDbContext.SaveChangesAsync();

                    return "Update Mission Detail Successfully.";
                }
                else
                {
                    throw new Exception("Mission not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in updating mission.", ex);
            }
        }

        public async Task<string> DeleteMissionAsync(int id)
        {
            try
            {
                var existingMission = await _cIDbContext.Missions.FirstOrDefaultAsync(mt => mt.Id == id && !mt.IsDeleted);
                if (existingMission != null)
                {
                    existingMission.IsDeleted = true;
                    await _cIDbContext.SaveChangesAsync();
                    return "Delete Mission Details Successfully.";
                }
                else
                {
                    throw new Exception("Mission not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting mission details.", ex);
            }
        }
    }
}

using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;

namespace Business_logic_Layer
{
    public class BALMission
    {
        private readonly DALMission _dalMission;     
        public BALMission(DALMission dalMission)
        {
            _dalMission = dalMission;
        }
        public List<DropDown> GetMissionThemeList()
        {
            return _dalMission.GetMissionThemeList();
        }
        public List<DropDown> GetMissionSkillList()
        {
            return _dalMission.GetMissionSkillList();
        }
       
        public async Task<List<Missions>> MissionListAsync()
        {
            return await _dalMission.MissionListAsync();
        }
        public string AddMission(Missions  mission)
        {
            return _dalMission.AddMission(mission);
        }       
        public Missions MissionDetailById(int id)
        {
            return _dalMission.MissionDetailById(id);
        }
       
        public async Task<string> UpdateMissionAsync(Missions mission)
        {
            return await _dalMission.UpdateMissionAsync(mission);
        }
        public async Task<string> DeleteMissionAsync(int id)
        {
            return await _dalMission.DeleteMissionAsync(id);
        }
    }
}

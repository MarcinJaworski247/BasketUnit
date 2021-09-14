import api from "@/http-common";

class clubsService {
  getCoachesToLookup() {
    return api.get("/administration/clubs/getCoachesToLookup");
  }
  getArenasToLookup() {
    return api.get("/administration/clubs/getArenasToLookup");
  }
  addTeam(data) {
    return api.post("/administration/clubs/addTeam", data);
  }
  setTeamDetails(teamId) {
    return api.get(`/administration/clubs/setTeamDetails/${teamId}`);
  }
  editTeam(data) {
    return api.post("/administration/clubs/editTeam", data);
  }
  getTeams() {
    return api.get("/administration/clubs/getTeams");
  }
  getArenas() {
    return api.get("/administration/clubs/getArenas");
  }
  editArena(data) {
    return api.post("/administration/clubs/editArena", data);
  }
  setArenaDetails(arenaId) {
    return api.get(`/administration/clubs/setArenaDetails/${arenaId}`);
  }
  addArena(data) {
    return api.post("/administration/clubs/addArena", data);
  }
  deleteArena(arenaId) {
    return api.post(`/administration/clubs/deleteArena/${arenaId}`);
  }
  deleteTeam(teamId) {
    return api.post(`/administration/clubs/deleteTeam/${teamId}`);
  }
  getCollegesList() {
    return api.get(`/administration/clubs/getCollegesList`);
  }
  deleteCollege(collegeId) {
    return api.post(`/administration/clubs/deleteCollege/${collegeId}`);
  }
  getCollegeDetails(collegeId) {
    return api.get(`/administration/clubs/getCollegeDetails/${collegeId}`);
  }
  addCollege(data) {
    return api.post(`/administration/clubs/addCollege`, data);
  }
  editCollege(data) {
    return api.post(`/administration/clubs/editCollege`, data);
  }
}

export default new clubsService();

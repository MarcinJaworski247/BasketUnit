import api from "@/http-common";

class humanResourcesService {
  getPlayers() {
    return api.get("/administration/humanResources/getPlayers");
  }
  getCoaches() {
    return api.get("/administration/humanResources/getCoaches");
  }
  getReferees() {
    return api.get("/administration/humanResources/getReferees");
  }
  getTeamsToLookup() {
    return api.get("/administration/humanResources/getTeamsToLookup");
  }
  getPositionsToLookup() {
    return api.get("/administration/humanResources/getPositionsToLookup");
  }
  getPlayerDetails(playerId) {
    return api.get(
      `/administration/humanResources/getPlayerDetails/${playerId}`
    );
  }
  getCoachDetails(coachId) {
    return api.get(`/administration/humanResources/getCoachDetails/${coachId}`);
  }
  getRefereeDetails(refereeId) {
    return api.get(
      `/administration/humanResources/getRefereeDetails/${refereeId}`
    );
  }
  editPlayer(data) {
    return api.post("/administration/humanResources/editPlayer", data);
  }
  editCoach(data) {
    return api.post("/administration/humanResources/editCoach", data);
  }
  editReferee(data) {
    return api.post("/administration/humanResources/editReferee", data);
  }
  getPlayerDataToDetails(playerId) {
    return api.get(
      `/administration/humanResources/getPlayerDataToDetails/${playerId}`
    );
  }
  getLastPlayerStatistics(playerId) {
    return api.get(
      `/administration/humanResources/getLastPlayerStatistics/${playerId}`
    );
  }
  getAvarageStatsToChart(playerId) {
    return api.get(
      `/administration/humanResources/getAvarageStatsToChart/${playerId}`
    );
  }
  addPlayer(data) {
    return api.post("/administration/humanResources/addPlayer", data);
  }
  addCoach(data) {
    return api.post("/administration/humanResources/addCoach", data);
  }
  addReferee(data) {
    return api.post("/administration/humanResources/addReferee", data);
  }
  getNationalitiesToLookup() {
    return api.get("/administration/humanResources/getNationalities");
  }
  deleteReferee(refereeId) {
    return api.get(`/administration/humanResources/deleteReferee/${refereeId}`);
  }
  deleteCoach(coachId) {
    return api.get(`/administration/humanResources/deleteCoach/${coachId}`);
  }
  deletePlayer(playerId) {
    return api.get(`/administration/humanResources/deletePlayer/${playerId}`);
  }
  getNationalitiesList() {
    return api.get(`/administration/humanResources/getNationalitiesList`);
  }
  getNationalityDetails(nationalityId) {
    return api.get(
      `/administration/humanResources/getNationalityDetails/${nationalityId}`
    );
  }
  editNationality(data) {
    return api.post(`/administration/humanResources/editNationality`, data);
  }
  addNationality(data) {
    return api.post(`/administration/humanResources/addNationality`, data);
  }
  deleteNationality(nationalityId) {
    return api.post(
      `/administration/humanResources/deleteNationality/${nationalityId}`
    );
  }
  getCollegesToLookup() {
    return api.get(`/administration/clubs/getCollegesToLookup`);
  }
}

export default new humanResourcesService();

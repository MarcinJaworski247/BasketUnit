import axios from "../../../../http-common";

class humanResourcesService {
    getPlayers() {
        return axios.get("/administration/humanResources/getPlayers");
    }
    getCoaches() {
        return axios.get("/administration/humanResources/getCoaches");
    }
    getReferees() {
        return axios.get("/administration/humanResources/getReferees");
    }
    getTeamsToLookup() {
        return axios.get("/administration/humanResources/getTeamsToLookup");
    }
    getPositionsToLookup() {
        return axios.get("/administration/humanResources/getPositionsToLookup");
    }
    getPlayerDetails(playerId) {
        return axios.get(`/administration/humanResources/getPlayerDetails/${playerId}`);
    }
    getCoachDetails(coachId) {
        return axios.get(`/administration/humanResources/getCoachDetails/${coachId}`);
    }
    getRefereeDetails(refereeId) {
        return axios.get(`/administration/humanResources/getRefereeDetails/${refereeId}`);
    }
    editPlayer(data) {
        return axios.post("/administration/humanResources/editPlayer", data);
    }
    editCoach(data) {
        return axios.post("/administration/humanResources/editCoach", data);
    }
    editReferee(data) {
        return axios.post("/administration/humanResources/editReferee", data);
    }
    getPlayerDataToDetails(playerId) {
        return axios.get(`/administration/humanResources/getPlayerDataToDetails/${playerId}`);
    }
    getLastPlayerStatistics(playerId) {
        return axios.get(`/administration/humanResources/getLastPlayerStatistics/${playerId}`);
    }
    getAvarageStatsToChart(playerId) {
        return axios.get(`/administration/humanResources/getAvarageStatsToChart/${playerId}`);
    }
    addPlayer(data) {
        return axios.post("/administration/humanResources/addPlayer", data);
    }
    addCoach(data) {
        return axios.post("/administration/humanResources/addCoach", data);
    }
    addReferee(data) {
        return axios.post("/administration/humanResources/addReferee", data);
    }
    getNationalitiesToLookup() {
        return axios.get("/administration/humanResources/getNationalities");
    }
    deleteReferee(refereeId) {
        return axios.get(`/administration/humanResources/deleteReferee/${refereeId}`);
    }
    deleteCoach(coachId) {
        return axios.get(`/administration/humanResources/deleteCoach/${coachId}`);
    }
    deletePlayer(playerId) {
        return axios.get(`/administration/humanResources/deletePlayer/${playerId}`);
    }
    getNationalitiesList() {
        return axios.get(`/administration/humanResources/getNationalitiesList`);
    }
    getNationalityDetails(nationalityId) {
        return axios.get(`/administration/humanResources/getNationalityDetails/${nationalityId}`);
    }
    editNationality(data) {
        return axios.post(`/administration/humanResources/editNationality`, data);
    }
    addNationality(data) {
        return axios.post(`/administration/humanResources/addNationality`, data);
    }
    deleteNationality(nationalityId) {
        return axios.post(`/administration/humanResources/deleteNationality/${nationalityId}`);
    }
    getCollegesToLookup() {
        return axios.get(`/administration/clubs/getCollegesToLookup`);
    }
}

export default new humanResourcesService();
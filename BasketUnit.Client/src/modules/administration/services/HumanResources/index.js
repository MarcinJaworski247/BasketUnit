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
    setPlayerDetails(playerId) {
        return axios.get("/administration/humanResources/setPlayerDetails", playerId);
    }
    setCoachDetails(coachId) {
        return axios.get("/administration/humanResources/setCoachDetails", coachId);
    }
    setRefereeDetails(refereeId) {
        return axios.get("/administration/humanResources/setRefereeDetails", refereeId);
    }
    editPlayer(data) {
        return axios.get("/administration/humanResources/editPlayer", data);
    }
    editCoach(data) {
        return axios.get("/administration/humanResources/editCoach", data);
    }
    editReferee(data) {
        return axios.get("/administration/humanResources/editReferee", data);
    }
    getPlayerDataToDetails(playerId) {
        return axios.get("/administration/humanResources/getPlayerDataToDetails", playerId);
    }
    getLastPlayerStatistics(playerId) {
        return axios.get("/administration/humanResources/getLastPlayerStatistics", playerId);
    }
    getAvarageStatsToChart(playerId) {
        return axios.get("/administration/humanResources/getAvarageStatsToChart", playerId);
    }
}

export default new humanResourcesService();
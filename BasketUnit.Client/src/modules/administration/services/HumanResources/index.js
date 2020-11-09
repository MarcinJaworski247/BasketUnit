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
}

export default new humanResourcesService();
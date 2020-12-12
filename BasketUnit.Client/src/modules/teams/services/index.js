import axios from "../../../http-common";

class teamsService {
    getPlayersList() {
        return axios.get("/team/getPlayersList");
    }
    getFirstLineupPlayers() {
        return axios.get("/team/getFirstLineupPlayers");
    }
    getPlayerDetails(playerId) {
        return axios.get(`/team/getPlayerDetails/${playerId}`);
    }
    editPlayer(data) {
        return axios.post("/team/editPlayer", data)
    }
    getPositionsToLookup() {
        return axios.get("/administration/humanResources/getPositionsToLookup");
    }
    getPlayersByPosition(positionId) {
        return axios.get(`/team/getPlayersByPosition/${positionId}`);
    }
    getFirstLineupPlayer(positionId) {
        return axios.get(`/team/getFirstLineupPlayer/${positionId}`);
    }
    saveFirstLineup(data) {
        return axios.post("/team/saveFirstLineup", data);
    }
    getNationalitiesToLookup() {
        return axios.get("/administration/humanResources/getNationalities");
    }
    getLastGamesStats(playerId) {
        return axios.get(`/team/getPlayerLastGamesStats/${playerId}`);
    }    
    getDataToPlayerDetailsChart(playerId) {
        return axios.get(`/team/getDataToPlayerDetailsChart/${playerId}`);
    }
    getEditForm() {
        return axios.get("/team/getEditForm");
    }
    getPlayerInjuries(playerId) {
        return axios.get(`/team/getPlayerInjuries/${playerId}`);
    }
    addInjury(data) {
        debugger
        return axios.post("/team/addPlayerInjury", data);
    }
}

export default new teamsService();
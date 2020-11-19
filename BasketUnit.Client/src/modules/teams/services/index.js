import axios from "../../../http-common";

class teamsService {
    getPlayersList() {
        return axios.get("/team/getPlayersList");
    }
    getFirstLineupPlayers() {
        return axios.get("/team/getFirstLineupPlayers");
    }
    getPlayerDetails(playerId) {
        return axios.get("/team/setPlayerDetails", playerId);
    }
    editPlayer(data) {
        return axios.post("/team/editPlayer", data)
    }
    getPositionsToLookup() {
        return axios.get("/administration/humanResources/getPositionsToLookup");
    }
    getPlayersByPosition(positionId) {
        return axios.get("/team/getPlayersByPosition", positionId);
    }
    getFirstLineupPlayer(positionId) {
        return axios.get("/team/getFirstLineupPlayer", positionId);
    }
    saveFirstLineup(pointGuardId, shootingGuard, smallForwardId, powerForwardId, centerId) {
        return axios.post("/teams/saveFirstLineup", pointGuardId, shootingGuard, smallForwardId, powerForwardId, centerId);
    }
    
}

export default new teamsService();
import axios from "../../../http-common";

class teamsService {
    getPlayersList() {
        return axios.get("/teams/getPlayersList");
    }
    getFirstLineupPlayers() {
        return axios.get("/teams/getFirstLineupPlayers");
    }
    setPlayerDetails(playerId) {
        return axios.get("/teams/setPlayerDetails", playerId);
    }
    editPlayer(data) {
        return axios.post("/teams/editPlayer", data)
    }
}

export default new teamsService();
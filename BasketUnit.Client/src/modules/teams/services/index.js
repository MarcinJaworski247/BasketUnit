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
}

export default new teamsService();
import axios from "../../../http-common";

class protocolsService {
    getGamesList() {
        return axios.get("/game/getGamesList")
    }
    getGameStatistics(gameId) {
        debugger
        return axios.get(`/game/getGameStatistics/${gameId}`);
    }
    getGamePlayerStatistics(playerId, gameId) {
        debugger
        return axios.get(`/game/getGamePlayerStatistics/${playerId}/${gameId}`);
    }
    saveGamePlayerStatistics(data) {
        return axios.post("/game/saveGamePlayerStatistics", data);
    }
}

export default new protocolsService();
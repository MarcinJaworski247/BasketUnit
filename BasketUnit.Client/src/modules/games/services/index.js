import axios from "../../../http-common";

class gamesService {
    getGamesList() {
        return axios.get("/game/getGamesList")
    }
    getTeamsToLookup() {
        return axios.get("/game/getTeamsToLookup")
    }
    getGameDetails(gameId) {
        return axios.get(`/game/getGameDetails/${gameId}`)
    }
    getGamePlayersStats(gameId) {
        return axios.get(`/game/getGamePlayersStats/${gameId}`)
    }
}

export default new gamesService();
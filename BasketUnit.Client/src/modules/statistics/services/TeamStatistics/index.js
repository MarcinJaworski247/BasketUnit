import axios from "../../../../http-common";

class statisticsSerivce {
    getPlayers() {
        return axios.get("/statistics/getPlayersList");
    }
    getPlayersStats() {
        return axios.get("/statistics/getPlayersStasts");
    }
    getTeamStats() {
        return axios.get("/statistics/getTeamStats");
    } 
}

export default new statisticsSerivce();
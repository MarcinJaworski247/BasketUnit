import axios from "../../../../http-common";

class statisticsSerivce {
    getPlayers() {
        return axios.get("/statistics/teamStatistics/getPlayersList");
    }
    getPlayersStats() {
        return axios.get("/statistics/teamStatistics/getPlayersStasts");
    }
    getTeamStats() {
        return axios.get("/statistics/teamStatistics/getTeamStats");
    } 
}

export default new statisticsSerivce();
import axios from "../../../http-common";

class statisticsService {
    getTeamAverages() {
        return axios.get("/statistics/getTeamAverages");
    }
    getTeamScoreAndLosePoints() {
        return axios.get("/statistics/getTeamScoreAndLosePoints");
    }
    getTeamForm() {
        return axios.get("/statistics/getTeamForm");
    }
    getFutureGames() {
        return axios.get("/statistics/getFutureGames")
    }
}

export default new statisticsService();
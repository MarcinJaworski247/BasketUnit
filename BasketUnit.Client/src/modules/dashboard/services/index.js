import axios from "../../../http-common";

class dashboardService {
    getLastGames() {
        return axios.get("/dashboard/getLastGames")
    }
    getFutureGames() {
        return axios.get("/dashboard/getFutureGames")
    }
    getInjuredPlayers() {
        return axios.get("/dashboard/getInjuredPlayers")
    }
    getTeamStats() {
        return axios.get("/dashboard/getTeamStats")
    }
    getFutureWorkouts() {
        return axios.get("/dashboard/getFutureWorkouts")
    }
}

export default new dashboardService();
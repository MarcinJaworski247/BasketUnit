import api from "@/http-common";

class dashboardService {
  getLastGames() {
    return api.get("/dashboard/getLastGames");
  }
  getFutureGames() {
    return api.get("/dashboard/getFutureGames");
  }
  getInjuredPlayers() {
    return api.get("/dashboard/getInjuredPlayers");
  }
  getTeamStats() {
    return api.get("/dashboard/getTeamStats");
  }
  getFutureWorkouts() {
    return api.get("/dashboard/getFutureWorkouts");
  }
}

export default new dashboardService();

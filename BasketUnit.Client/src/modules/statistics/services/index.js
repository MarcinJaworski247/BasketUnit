import api from "../../../http-common";

class statisticsService {
  getTeamAverages() {
    return api.get("/statistics/getTeamAverages");
  }
  getTeamScoreAndLosePoints() {
    return api.get("/statistics/getTeamScoreAndLosePoints");
  }
  getTeamForm() {
    return api.get("/statistics/getTeamForm");
  }
  getFutureGames() {
    return api.get("/statistics/getFutureGames");
  }
}

export default new statisticsService();

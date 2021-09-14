import api from "@/http-common";

class gamesService {
  getGamesList() {
    return api.get("/game/getGamesList");
  }
  getTeamsToLookup() {
    return api.get("/game/getTeamsToLookup");
  }
  getGameDetails(gameId) {
    return api.get(`/game/getGameDetails/${gameId}`);
  }
  getGamePlayersStats(gameId) {
    return api.get(`/game/getGamePlayersStats/${gameId}`);
  }
}

export default new gamesService();

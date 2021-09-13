import api from "../../../http-common";

class protocolsService {
  getGamesList() {
    return api.get("/game/getGamesProtocolsList");
  }
  getGameStatistics(gameId) {
    return api.get(`/game/getGameStatistics/${gameId}`);
  }
  getGamePlayerStatistics(playerId, gameId) {
    return api.get(`/game/getGamePlayerStatistics/${playerId}/${gameId}`);
  }
  saveGamePlayerStatistics(data) {
    return api.post("/game/saveGamePlayerStatistics", data);
  }
}

export default new protocolsService();

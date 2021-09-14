import api from "../../../http-common";

class teamsService {
  getPlayersList() {
    return api.get("/team/getPlayersList");
  }
  getFirstLineupPlayers() {
    return api.get("/team/getFirstLineupPlayers");
  }
  getPlayerDetails(playerId) {
    return api.get(`/team/getPlayerDetails/${playerId}`);
  }
  editPlayer(data) {
    return api.post("/team/editPlayer", data);
  }
  getPositionsToLookup() {
    return api.get("/administration/humanResources/getPositionsToLookup");
  }
  getPlayersByPosition(positionId) {
    return api.get(`/team/getPlayersByPosition/${positionId}`);
  }
  getFirstLineupPlayer(positionId) {
    return api.get(`/team/getFirstLineupPlayer/${positionId}`);
  }
  saveFirstLineup(data) {
    return api.post("/team/saveFirstLineup", data);
  }
  getNationalitiesToLookup() {
    return api.get("/administration/humanResources/getNationalities");
  }
  getLastGamesStats(playerId) {
    return api.get(`/team/getPlayerLastGamesStats/${playerId}`);
  }
  getDataToPlayerDetailsChart(playerId) {
    return api.get(`/team/getDataToPlayerDetailsChart/${playerId}`);
  }
  getEditForm() {
    return api.get("/team/getEditForm");
  }
  getPlayerInjuries(playerId) {
    return api.get(`/team/getPlayerInjuries/${playerId}`);
  }
  addInjury(data) {
    return api.post("/team/addPlayerInjury", data);
  }
  getPlayerAvgs(playerId) {
    return api.get(`/team/getPlayerAvgs/${playerId}`);
  }
  getPlayerRecords(playerId) {
    return api.get(`/team/getPlayerRecords/${playerId}`);
  }
  getAllPlayerGames(playerId) {
    return api.get(`/team/getAllPlayerGames/${playerId}`);
  }
  getDataToSpiderWeb(playerId) {
    return api.get(`/team/getDataToSpiderWeb/${playerId}`);
  }
  getPlayerCondition(playerId) {
    return api.get(`/team/getPlayerCondition/${playerId}`);
  }
  getSubstitutePlayers() {
    return api.get("/team/getSubstitutePlayers");
  }
}

export default new teamsService();

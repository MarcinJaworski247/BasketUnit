import axios from "../../../../http-common";

class clubsService {
    getCoachesToLookup() {
        return axios.get("/administration/clubs/getCoachesToLookup");
    }
    getArenasToLookup() {
        return axios.get("/administration/clubs/getArenasToLookup");
    }
    addTeam(data) {
        return axios.put("/administration/clubs/addTeam", data);
    }
    setTeamDetails(teamId) {
        return axios.get("/administration/clubs/setTeamDetails", teamId);
    }
    editTeam(data) {
        return axios.put("/administration/clubs/editTeam", data);
    }
    getTeams() {
        return axios.get("/administration/clubs/getTeams");
    }
    getArenas() {
        return axios.get("/administration/clubs/getArenas");
    }
    editArena(data) {
        return axios.put("/administration/clubs/editArena", data);
    }
    setArenaDetails(arenaId) {
        return axios.get("/administration/clubs/setArenaDetails", arenaId);
    }
}

export default new clubsService();
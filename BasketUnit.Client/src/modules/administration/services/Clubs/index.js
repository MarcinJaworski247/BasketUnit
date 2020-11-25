import axios from "../../../../http-common";

class clubsService {
    getCoachesToLookup() {
        return axios.get("/administration/clubs/getCoachesToLookup");
    }
    getArenasToLookup() {
        return axios.get("/administration/clubs/getArenasToLookup");
    }
    addTeam(data) {
        return axios.post("/administration/clubs/addTeam", data);
    }
    setTeamDetails(teamId) {
        return axios.get(`/administration/clubs/setTeamDetails/${teamId}`);
    }
    editTeam(data) {
        return axios.post("/administration/clubs/editTeam", data);
    }
    getTeams() {
        return axios.get("/administration/clubs/getTeams");
    }
    getArenas() {
        return axios.get("/administration/clubs/getArenas");
    }
    editArena(data) {
        return axios.post("/administration/clubs/editArena", data);
    }
    setArenaDetails(arenaId) {
        return axios.get(`/administration/clubs/setArenaDetails/${arenaId}`);
    }
    addArena(data) {
        return axios.post("/administration/clubs/addArena", data);
    }
    deleteArena(arenaId) {
        return axios.post(`/administration/clubs/deleteArena/${arenaId}`);
    }
    deleteTeam(teamId) {
        return axios.post(`/administration/clubs/deleteTeam/${teamId}`);
    }
}

export default new clubsService();
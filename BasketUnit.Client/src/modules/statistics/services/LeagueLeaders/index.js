import axios from "../../../../http-common";

class leagueLeadersService {
    getPointsLeaders() {
        return axios.get("/statistics/leagueLeaders/getPointsLeaders");
    }
    getAssistsLeaders() {
        return axios.get("/statistics/leagueLeaders/getAssistsLeaders");
    }
    getReboundsLeaders() {
        return axios.get("/statistics/leagueLeaders/getReboundsLeaders");
    }
    getBlocksLeaders() {
        return axios.get("/statistics/leagueLeaders/getBlocksLeaders");
    }
    getStealsLeaders() {
        return axios.get("/statistics/leagueLeaders/getStealsLeaders");
    }
}

export default new leagueLeadersService();
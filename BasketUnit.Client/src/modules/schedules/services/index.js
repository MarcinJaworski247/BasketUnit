import axios from "../../../http-common";

class schedulesService {
    getActivities() {
        return axios.get("/schedules/getActivities");
    }
    getExcercisesToLookup() {
        return axios.get("/schedules/getExcercisesToLookup");
    }
    getTeamsToLookup() {
        return axios.get("/schedules/getTeamsToLookup");
    }
}

export default new schedulesService();
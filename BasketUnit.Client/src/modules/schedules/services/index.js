import axios from "../../../http-common";

class schedulesService {
    getActivitiesToShow() {
        return axios.get("/schedules/getActivitiesToShow");
    }
    getExcercisesToLookup() {
        return axios.get("/schedules/getExcercisesToLookup");
    }
    getTeamsToLookup() {
        return axios.get("/schedules/getTeamsToLookup");
    }
    getArenasToLookup() {
        return axios.get("/schedules/getArenasToLookup");
    }
    getRefereesToLookup() {
        return axios.get("/schedules/getRefereesToLookup");
    }
    addGame(data) {
        return axios.post("/schedules/addGame", data);
    }
    addWorkout(data) {
        return axios.post("/schedules/addWorkout", data);
    }
}

export default new schedulesService();
import axios from "../../../http-common";

class workoutsService {
    getExcersises() {
        return axios.get("/workouts/getExcersises");
    }
    getWorkoutTypesToLookup() {
        return axios.get("/workouts/getWorkoutTypesToLookup");
    }
    addExcersise(data) {
        return axios.post("/workouts/addExcersise", data);
    }
    editExcersise(data) {
        return axios.post("/workouts/editExcersise", data);
    }
    setExcersiseDetails(excersiseId) {
        return axios.get("/workouts/setExcersiseDetails", excersiseId)
    }
    getWorkoutTypes() {
        return axios.get("/workouts/getWorkoutTypes");
    }
    addWorkoutType(data) {
        return axios.post("/workouts/addWorkoutType", data);
    }
    editWorkoutType(data) {
        return axios.post("/workout/editWorkoutType", data);
    }
    setWorkoutTypeDetails(workoutTypeId) {
        return axios.get("/workout/setWorkoutTypeDetails", workoutTypeId);
    }
}

export default new workoutsService();
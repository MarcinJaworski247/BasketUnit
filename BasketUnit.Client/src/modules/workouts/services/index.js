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
    getExcersiseDetails(excersiseId) {
        return axios.get(`/workouts/getExcersiseDetails/${excersiseId}`)
    }
    getWorkoutTypes() {
        return axios.get("/workouts/getWorkoutTypes");
    }
    addWorkoutType(data) {
        return axios.post("/workouts/addWorkoutType", data);
    }
    editWorkoutType(data) {
        return axios.post("/workouts/editWorkoutType", data);
    }
    getWorkoutTypeDetails(workoutTypeId) {
        return axios.get(`/workouts/getWorkoutTypeDetails/${workoutTypeId}`);
    }
    deleteWorkoutType(workoutTypeId) {
        return axios.post(`/workouts/deleteWorkoutType/${workoutTypeId}`);
    }
    deleteExcercise(workoutId) {
        return axios.post(`/workouts/deleteWorkout/${workoutId}`);
    }
}

export default new workoutsService();
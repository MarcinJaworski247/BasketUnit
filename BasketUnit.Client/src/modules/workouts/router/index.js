import Index from '../views/Index.vue';
import Excercises from '../views/Excercises/Index.vue';
import WorkoutTypes from '../views/WorkoutTypes/Index.vue';

const routes = [
    {
        path: `/workouts`,
        name: `workouts.index`,
        component: Index
    },
    {
        path: `/workouts/excercises`,
        name: `workouts.excercises.index`,
        component: Excercises
    },
    {
        path: `/workouts/workoutTypes`,
        name: `workouts.workoutTypes.index`,
        component: WorkoutTypes
    }
]

export default routes;
import Index from "../views/Index.vue";
import Edit from "../views/Edit.vue";

const routes = [
  {
    path: `/protocols`,
    name: `protocols.index`,
    component: Index,
  },
  {
    path: `/protocols/edit/:gameId`,
    name: `protocols.edit`,
    component: Edit,
  },
];

export default routes;

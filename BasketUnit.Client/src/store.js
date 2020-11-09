import Vue from 'vue'
import Vuex from 'vuex'
import AdministrationTeamStore from './modules/administration/store/Clubs/Teams/index'
import AdministrationEditTeamStore from './modules/administration/store/Clubs/Teams/edit'
import AdministrationArenaStore from './modules/administration/store/Clubs/Arenas/index'
import AdministrationEditArenaStore from './modules/administration/store/Clubs/Arenas/edit'
import AdministrationCoachStore from './modules/administration/store/HumanResources/Coach/index'
import AdministrationEditCoachStore from './modules/administration/store/HumanResources/Coach/edit'
import AdministrationPlayerStore from './modules/administration/store/HumanResources/Player/index'
import AdministrationEditPlayerStore from './modules/administration/store/HumanResources/Player/edit'
import AdministrationRefereeStore from './modules/administration/store/HumanResources/Referee/index'
import AdministrationEditRefereeStore from './modules/administration/store/HumanResources/Referee/edit'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        AdministrationTeamStore,
        AdministrationEditTeamStore,
        AdministrationArenaStore,
        AdministrationEditArenaStore,
        AdministrationCoachStore,
        AdministrationEditCoachStore,
        AdministrationPlayerStore,
        AdministrationEditPlayerStore,
        AdministrationRefereeStore,
        AdministrationEditRefereeStore
    }
});
import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    vaults: [],
    keeps: [],
    vaultKeeps: []
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setKeeps(state, keeps){
      state.keeps = keeps
    },
    setVaults(state, vaults){
      state.vaults = vaults
    },
  },
  actions: {
    async getProfile({ commit }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getKeeps({commit}) {
      try {
        let res = await api.get("keeps");
        commit("setKeeps",res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getProfileVaults({commit}, profileId) {
      try {
        let res = await api.get("profiles/" + profileId + "/vaults");
        commit("setVaults",res.data);
      } catch (error) {
        console.error(error);
      }
    },
  },
});

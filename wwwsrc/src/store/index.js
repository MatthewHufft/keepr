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
    deleteVault(state, vault){
      state.vaults = state.vaults.filter(v => v.id != vault.id)
    },
    deleteKeep(state, keep){
      state.keeps = state.keeps.filter(k => k.id != keep.id)
    },
    createVault(state, vault){
      state.vaults.push(vault)
    },
    createKeep(state, keep){
      state.keeps.push(keep)
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
    async deleteVault({commit}, vaultId) {
      try {
        let res = await api.delete("vaults/" + vaultId);
        commit("deleteVault", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({commit}, keepId) {
      try {
        let res = await api.delete("keeps/" + keepId);
        commit("deleteKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async createVault({commit}, newVault) {
      try {
        let res = await api.post("vaults", newVault);
        commit("createVault", res.data);
        // @ts-ignore
        $("#newVaultModal").hide()
        // @ts-ignore
        $(".modal-backdrop").hide()
      } catch (error) {
        console.error(error);
      }
    },
    async createKeep({commit}, newKeep) {
      try {
        let res = await api.post("keeps", newKeep);
        commit("createKeep", res.data);
        // @ts-ignore
        $("#newKeepModal").hide()
        // @ts-ignore
        $(".modal-backdrop").hide()
      } catch (error) {
        console.error(error);
      }
    },
  },
});

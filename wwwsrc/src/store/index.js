import Vue from "vue";
import Vuex from "vuex";
import router from "../router/index.js"
import { api } from "../services/AxiosService.js";
import ns from "../services/NotificationService";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    activeProfile: {},
    vaults: [],
    keeps: [],
    activeKeeps: [],
    activeVault: {}
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setActiveProfile(state, profile){
      state.activeProfile = profile;
    },
    setKeeps(state, keeps){
      state.keeps = keeps
    },
    setActiveKeeps(state, keeps){
      state.activeKeeps = keeps
    },
    setVaults(state, vaults){
      state.vaults = vaults
    },
    setActiveVault(state, vault){
      state.activeVault = vault;
    },
    deleteVault(state, vault){
      state.vaults = state.vaults.filter(v => v.id != vault.id)
    },
    deleteKeep(state, keep){
      state.keeps = state.keeps.filter(k => k.id != keep.id)
    },
    deleteVaultKeep(state, VKId){
      state.activeKeeps = state.activeKeeps.filter(k => k.vaultKeepId != VKId)
    },
    createVault(state, vault){
      state.vaults.push(vault)
    },
    createKeep(state, keep){
      state.keeps.push(keep)
    },
    updateKeep(state, update){
      let currentKeep = state.keeps.find(k => k.id == update.id)
      currentKeep = update;
    }
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
    async getActiveProfile({commit}, profileId) {
      try {
        let res = await api.get("profiles/" + profileId);
        commit("setActiveProfile",res.data);
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
    async getVault({commit}, vaultId) {
      try {
        let res = await api.get("vaults/" + vaultId);
        let userRes = await api.get("profiles");
        if(res.data.isPrivate == true && userRes.data.id != res.data.creatorId){
          router.push({ name: "Home" });
        }
        commit("setActiveVault",res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async getActiveKeeps({commit}, vaultId) {
      try {
        let res = await api.get("vaults/" + vaultId + "/keeps");
        commit("setActiveKeeps", res.data);
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
    async getProfileKeeps({commit}, profileId) {
      try {
        let res = await api.get("profiles/" + profileId + "/keeps");
        commit("setKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteVault({commit}, vaultId) {
      try {
        if(await ns.confirmAction("Are you sure you want to delete this vault?")){
          let res = await api.delete("vaults/" + vaultId);
          commit("deleteVault", res.data);
          ns.toast("Vault deleted successfully", 1500)
          router.push({ name: "Home" });
        }
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({commit}, keepId) {
      try {
        if(await ns.confirmAction("Are you sure you want to delete this keep?", "This will remove it from all vaults")){
          let res = await api.delete("keeps/" + keepId);
          commit("deleteKeep", res.data);
          ns.toast("Keep deleted successfully", 1500)
        }
      } catch (error) {
        console.error(error);
      }
    },
    async deleteVaultKeep({commit}, VKId) {
      try {
        if(await ns.confirmAction("Are you sure you want to remove this keep?")){
          await api.delete("vaultkeeps/" + VKId, VKId);
          commit("deleteVaultKeep", VKId);
          // @ts-ignore
          $("#newKeepModal").hide()
          // @ts-ignore
          $(".modal-backdrop").hide()
          ns.toast("Keep removed from vault")
        }
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
    async createKeep({commit, dispatch}, payload) {
      try {
        let res = await api.post("keeps", payload.newKeep);
        console.log(res.data);
        payload.newVK.keepId = res.data.id;
        commit("createKeep", res.data);
        dispatch("createVaultKeep", payload.newVK);
        // @ts-ignore
        $("#newKeepModal").hide()
        // @ts-ignore
        $(".modal-backdrop").hide()
      } catch (error) {
        console.error(error);
      }
    },
    async createVaultKeep({commit}, newVK) {
      try {
        await api.post("vaultkeeps", newVK);
        ns.toast("Added to vault successfully")
      } catch (error) {
        console.error(error);
      }
    },
    
    async updateKeep({commit}, update){
      try {
        await api.put("keeps/"+ update.id, update);
        commit("updateKeep", update);
      } catch (error) {
        console.error(error);
      }
    }
  },
});

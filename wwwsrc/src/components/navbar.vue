<template>
  <nav class="navbar navbar-expand-lg d-flex justify-content-between sticky-top">
      <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
        <div class="d-flex align-items-center">
          <img src="../assets/lock.png" width="50px" alt="lockLogo">
        </div>
      </router-link>
      
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse justify-content-end" id="navbarText">
      <router-link class="navbar-brand d-flex" :to="{ name: 'Profile', params: {profileId: this.profile.id}}">
        <div class="d-flex flex-column align-items-center">
          <img :src="this.profile.picture" class="rounded-circle w-50" alt="">
        </div>
      </router-link>
      <span class="navbar-text">
        <!-- Consider changing this to a profile picture -->
        <button
          class="btn btn-success"
          @click="login"
          v-if="!$auth.isAuthenticated"
        >
          Login
        </button>
        <button class="btn btn-danger" @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import { getUserData } from "@bcwdev/auth0-vue";
import { setBearer, resetBearer } from "../services/AxiosService";
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      if (this.$auth.isAuthenticated) {
        setBearer(this.$auth.bearer);
        this.$store.dispatch("getProfile");
      }
    },
    async logout() {
      resetBearer();
      await this.$auth.logout({ returnTo: window.location.origin });
    },
  },
  computed:{
    profile(){
      return this.$store.state.profile
    }
  }
};
</script>

<style>
.navbar {
  background-color:hsla(210, 3%, 15%, 0.904);
}
</style>

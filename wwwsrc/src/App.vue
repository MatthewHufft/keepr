<template>
  <div id="app" class="app-background">
    <navbar />
      <router-view />
  </div>
</template>

<script>
import Navbar from "@/components/navbar";
import { onAuth } from "@bcwdev/auth0-vue";
import { setBearer } from "./services/AxiosService";
export default {
  name: "App",
  async beforeCreate() {
    await onAuth();
    if (this.$auth.isAuthenticated) {
      setBearer(this.$auth.bearer);
      this.$store.dispatch("getProfile")
      this.$store.dispatch("getProfileVaults", this.$auth.userInfo.id);
      //NOTE if you want to do something everytime the user logs in, do so here
    }
  },
  components: {
    Navbar
  },
};
</script>
<style lang="scss">
@import "./assets/_variables.scss";
@import "bootstrap";
@import "./assets/_overrides.scss";
.app-background{
  background: rgb(37, 38, 39);
  // background: linear-gradient(127deg, rgba(238,244,249,1) 0%, rgba(231,236,240,1) 50%, rgba(238,244,249,1) 100%);
}
#app{
  min-height: 100vh;
}
</style>

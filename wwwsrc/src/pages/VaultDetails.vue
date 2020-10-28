<template>
  <div class="vault container-fluid">
    <div class="row">
      <div class="col-12 d-flex justify-content-center text-light mt-3 " >
        <h1>{{this.activeVault.name}}</h1>
        <div class="btn-group dropright">
          <i  class="fa fa-ellipsis-v btn text-light" aria-hidden="true" role="button" data-toggle="dropdown"></i>
          <div class="dropdown-menu ml-1 text-center">
            <p class="btn" @click="deleteVault">Delete Vault</p>
          </div>
        </div>
      </div>
    </div>
    <div class="row mt-5" v-if="activeKeeps.length == 0">
      <div class="col-12 text-center text-light mt-5 "  >
        <h1>Sorry, there's nothing here 😬</h1>
      </div>
    </div>
    <div class="row">
      <div class="card-columns w-75 offset-1">
        <KeepComponent v-for="keep in activeKeeps" :key="keep.id" :keepProp="keep"/>
      </div>
    </div>
  </div>
</template>

<script>
import KeepComponent from "../components/KeepComponent.vue";
export default {
name: "vault-details",
  mounted(){
      this.$store.dispatch("getVault", this.$route.params.vaultId);
      this.$store.dispatch("getActiveKeeps", this.$route.params.vaultId);
  },
  data(){
    return{
      }
  },
  computed:{
    activeKeeps(){
      return this.$store.state.activeKeeps;
    },
    activeVault(){
      return this.$store.state.activeVault;
    },
  },
  methods:{
    deleteVault(){
      this.$store.dispatch("deleteVault", this.activeVault.id)
    }
  },
  props: ["keepProp"],
  components:{KeepComponent}
}
</script>

<style scoped>
  .vault{
    min-height: 90vh;
  }
</style>
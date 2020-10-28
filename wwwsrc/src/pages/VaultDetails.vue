<template>
  <div class="vault container-fluid d-flex justify-content-center">
    <div class="no-content text-light mt-5" v-if="activeKeeps.length == 0">
      <h1>Sorry, there's nothing here</h1>
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
      // this.$store.dispatch("getVault", this.$route.params.vaultId);
      this.$store.dispatch("getActiveKeeps", this.$route.params.vaultId);
  },
  data(){
    return{
      }
  },
  computed:{
    activeKeeps(){
      return this.$store.state.activeKeeps;
    }
  },
  methods:{

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
<template>
  <div class="container-fluid">
    <div class="row">
      <div class="card-columns">
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
      this.$store.dispatch("getActiveKeeps", this.$route.params.vaultId);
  },
  data(){
    return{}
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

<style>

</style>